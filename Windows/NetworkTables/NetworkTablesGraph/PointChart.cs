//----------------------------------------------------------------------------
//
//  $Workfile: PointChart.cs$
//
//  $Revision: X$
//
//  Project:    Robot Network Data Objects
//
//                            Copyright (c) 2016
//                              James A Wright
//                            All Rights Reserved
//
//  Modification History:
//  $Log:
//  $
//
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace NetworkTablesGraph
{
    //----------------------------------------------------------------------------
    //  Class Declarations
    //----------------------------------------------------------------------------
    //
    // Class Name: PointChart
    // 
    // Purpose:
    //      The class that draws the chart
    //
    //----------------------------------------------------------------------------
    class PointChart
    {
        const int CIRCLE_SIZE = 2;
//        const double MAX_POINTS = mMaxPoint - MIN_POINT;

        double mMinPoint = -100;
        double mMaxPoint = 100;
        int mCountDivSize = 50;
        int mNumberOfDiv = 0;
        int mTopOffset = 0;
        int mLeftOffset = 0;
        int mWidth = 0;
        int mHeight = 0;
        int mYMidPoint = 0;
        double mYScale = 0;
        List<Channel> mChannels = new List<Channel>();
        Brush mBackground = new SolidBrush(Color.AliceBlue);

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Constructor
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public PointChart()
        {

        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Constructor
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public PointChart(int leftOffset, int topOffset, int width, int height)
        {
            Resize(leftOffset, topOffset, width, height);
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Constructor
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public void Resize(int leftOffset, int topOffset, int width, int height)
        {
            mTopOffset = topOffset;
            mLeftOffset = leftOffset;
            mWidth = width;
            mHeight = height;
            mYMidPoint = height / 2;
            mYScale = 2;
            mNumberOfDiv = mWidth / mCountDivSize;
            mMinPoint = -(mYMidPoint/mYScale);
            mMaxPoint = mYMidPoint/mYScale;
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Add a Channel to the list of channels
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public void AddChannel(Channel channel)
        {
            if(false == mChannels.Contains(channel))
            {
                mChannels.Add(channel);
            }
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      remove a Channel from the list of channels
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public void RemoveChannel(Channel channel)
        {
            mChannels.Remove(channel);
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Draw the Chart to the Screen
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public void Draw(Graphics graph)
        {
            // Draw the background
            graph.FillRectangle(mBackground, mLeftOffset, mTopOffset, mWidth, mHeight);

            // Draw center line
            graph.DrawLine(Pens.Gray, mLeftOffset, mTopOffset + mYMidPoint + 1, mLeftOffset + mWidth, mTopOffset + mYMidPoint + 1);
            graph.DrawLine(Pens.Gray, mLeftOffset, mTopOffset + mYMidPoint, mLeftOffset + mWidth, mTopOffset + mYMidPoint);
            graph.DrawLine(Pens.Gray, mLeftOffset, mTopOffset + mYMidPoint - 1, mLeftOffset + mWidth, mTopOffset + mYMidPoint - 1);

            // Draw the major lines
            graph.DrawLine(Pens.Gray, mLeftOffset, mTopOffset + mYMidPoint - 400, mLeftOffset + mWidth, mTopOffset + mYMidPoint - 400);
            graph.DrawLine(Pens.LightGray, mLeftOffset, mTopOffset + mYMidPoint - 300, mLeftOffset + mWidth, mTopOffset + mYMidPoint - 300);
            graph.DrawLine(Pens.Gray, mLeftOffset, mTopOffset + mYMidPoint - 200, mLeftOffset + mWidth, mTopOffset + mYMidPoint - 200);
            graph.DrawLine(Pens.LightGray, mLeftOffset, mTopOffset + mYMidPoint - 100, mLeftOffset + mWidth, mTopOffset + mYMidPoint - 100);
            graph.DrawLine(Pens.Gray, mLeftOffset, mTopOffset + mYMidPoint, mLeftOffset + mWidth, mTopOffset + mYMidPoint);
            graph.DrawLine(Pens.LightGray, mLeftOffset, mTopOffset + mYMidPoint + 100, mLeftOffset + mWidth, mTopOffset + mYMidPoint + 100);
            graph.DrawLine(Pens.Gray, mLeftOffset, mTopOffset + mYMidPoint + 200, mLeftOffset + mWidth, mTopOffset + mYMidPoint + 200);
            graph.DrawLine(Pens.LightGray, mLeftOffset, mTopOffset + mYMidPoint + 300, mLeftOffset + mWidth, mTopOffset + mYMidPoint + 300);
            graph.DrawLine(Pens.Gray, mLeftOffset, mTopOffset + mYMidPoint + 400, mLeftOffset + mWidth, mTopOffset + mYMidPoint + 400);

            for (int i = 0; i < mNumberOfDiv; i++)
            {
                graph.DrawLine(Pens.LightGray,
                            mLeftOffset + (i * mCountDivSize),
                            mTopOffset,
                            mLeftOffset + (i * mCountDivSize),
                            mTopOffset + mHeight);
            }

            // Draw the points
            for (int i = 0; i <= mWidth; i++)
            {
                for (int j = 0; j < mChannels.Count; j++)
                {
                    if (double.MaxValue != mChannels[j].GetPoint(i))
                    {
                        double point = mChannels[j].GetPoint(i);
                        if ((point <= mMaxPoint) && (point >= mMinPoint))
                        {
                            graph.DrawEllipse(mChannels[j].mPen,
                                                mLeftOffset + i,
                                                mTopOffset + (mYMidPoint - (int)(point * mYScale)),
                                                CIRCLE_SIZE,
                                                CIRCLE_SIZE);

                        }
                    }
                }
            }
            graph.DrawRectangle(Pens.Black, mLeftOffset, mTopOffset, mWidth, mHeight);

        }
    }

    //----------------------------------------------------------------------------
    //  Class Declarations
    //----------------------------------------------------------------------------
    //
    // Class Name: Channel
    // 
    // Purpose:
    //      The class that holds the data to draw to the chart
    //
    //----------------------------------------------------------------------------
    public class Channel
    {
        double[] mData = new double[0];
        int mNumberPoints = 0;
        const double MAX_VALUE = double.MaxValue;
        public Color mColor = Color.Red;
        public Pen mPen = new Pen(Color.Red);
        string mFilename = "";
        StreamWriter mStreamWriter;
        bool mFileOpen = false;

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Constructor
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public Channel()
        {

        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Constructor
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public Channel(int numberOfPoints)
        {
            SetPoints(numberOfPoints);
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Constructor
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public Channel(Color color, int numberOfPoints)
        {
            mColor = color;
            mPen = new Pen(mColor);
            SetPoints(numberOfPoints);
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Open a new file
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public void OpenFile(string name)
        {
            mFilename = name;
            mStreamWriter = new StreamWriter(mFilename);
            mFileOpen = true;
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Set a new number of points
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public void SetPoints(int numberOfPoints)
        {
            mNumberPoints = numberOfPoints;
            mData = new double[mNumberPoints];
            ClearPoints();
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Set all the points to the max number so they will not be displayed
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        private void ClearPoints()
        {
            int i = 0;
            for (i = 0; i < mNumberPoints; i++)
            {
                mData[i] = double.MaxValue;
            }
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Move all the points down and add a new point
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public void AddPoint(double point)
        {
            int i = 0;
            for (i = 0; i < mNumberPoints - 1; i++)
            {
                mData[i] = mData[i + 1];
            }
            mData[i] = point;

            if(true == mFileOpen)
            {
                mStreamWriter.WriteLine(point.ToString("F8"));
            }
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Return a point
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public double GetPoint(int index)
        {
            if ((index >= 0) && (index < mNumberPoints))
            {
                return mData[index];
            }

            return MAX_VALUE;
        }
    }


}
