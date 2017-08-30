//----------------------------------------------------------------------------
//
//  $Workfile: PointChart.cs$
//
//  $Revision: X$
//
//  Project:    Robot Network Data Objects
//
//                            Copyright (c) 2017
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
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using NetworkTablesInterface;

namespace NetworkTablesGraph
{
    //----------------------------------------------------------------------------
    //  Purpose:
    //      Draw the chart
    //
    //  Notes:
    //      None
    //
    //----------------------------------------------------------------------------
    public partial class NetworkTablesGraph : Form
    {
        //----------------------------------------------------------------------------
        //  Class constants
        //----------------------------------------------------------------------------
        public const int MAX_DATA_POINTS = 800;
        const int BOTTOM_OFFSET = 280;
        const int SIDE_OFFSET = 80;
        const int TOP_OFFSET = 20;
        const int LEFT_OFFSET = 20;
        const string CHANNEL_FILE = "Channels.xml";
        public const int LV_COL_KEY = 0;
        public const int LV_COL_COLOR = 1;
        public const int LV_COL_MULT = 2;
        public const int LV_COL_OFFSET = 3;
        public const int LV_COL_CUR_VALUE = 4;
        public const int LV_COL_MIN = 5;
        public const int LV_COL_MEAN = 6;
        public const int LV_COL_MAX = 7;
        public const int LV_COL_LAST_TIME = 8;

        public const string CHANNELS_TAG = "Channels";

        //----------------------------------------------------------------------------
        //  Class Attributes
        //----------------------------------------------------------------------------
        PointChart mPointChart = new PointChart();
        List<DataChannel> mChannels = new List<DataChannel>();
        ConfigureFile mConfig = new ConfigureFile();
        ConfigureFile mIPConfig = new ConfigureFile();

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Constructor
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public NetworkTablesGraph()
        {
            InitializeComponent();

            NetworkTable.StartClient(mIPConfig.mIPAddress, mIPConfig.mPort);

            mPointChart = new PointChart(LEFT_OFFSET, TOP_OFFSET, GetPoints(), this.Size.Height - BOTTOM_OFFSET);

            cbColor.Items.Clear();
            cbColor.Items.Add("Black");
            cbColor.Items.Add("Green");
            cbColor.Items.Add("Blue");
            cbColor.Items.Add("Red");
            cbColor.Items.Add("Purple");
            cbColor.Items.Add("Orange");
            cbColor.Items.Add("Gray");
            cbColor.Items.Add("RoyalBlue");
            cbColor.Items.Add("Goldenrod");
            cbColor.Items.Add("DarkCyan");
            cbColor.Items.Add("Magenta");
            cbColor.Items.Add("Maroon");
            cbColor.Items.Add("DarkMagenta");
            cbColor.Items.Add("Firebrick");
            cbColor.Items.Add("ForestGreen");
            cbColor.Items.Add("BlueViolet");
            cbColor.Items.Add("Salmon");
            cbColor.Items.Add("DarkSalmon");
            cbColor.Items.Add("DarkViolet");
            cbColor.SelectedIndex = 0;

            LoadChannels();
            this.Text = "Graphing - " + mConfig.mIPAddress + ":" + mConfig.mPort.ToString();

            tDisplay.Enabled = true;
        }
        
        //----------------------------------------------------------------------------
        //  Purpose:
        //      Add a channel
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        void AddChannel(string key, Color color, double mult, double offset)
        {
            DataChannel newChannel = new DataChannel(key, mult, offset, new Channel(color, GetPoints()));
            mChannels.Add(newChannel);
            mPointChart.AddChannel(newChannel.mNTItem);

            AddListViewRow(newChannel);

            SaveChannels();
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Return the number of points
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        int GetPoints()
        {
            return this.Width - SIDE_OFFSET;
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Add a channel to the list view
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        void AddListViewRow(DataChannel channel)
        {
            ListViewItem item = new ListViewItem(channel.mKey);
            item.SubItems.Add(channel.mNTItem.mColor.Name);
            item.SubItems.Add(channel.mMult.ToString("F3"));
            item.SubItems.Add(channel.mOffset.ToString("F3"));
            item.SubItems.Add("0.0");
            item.SubItems.Add("0.0");
            item.SubItems.Add("0.0");
            item.SubItems.Add("0.0");
            item.SubItems.Add("0.0");
            channel.SetLVItem(lvChannels.Items.Add(item));
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Delete Channels
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        void DeleteChannel(string key)
        {
            for(int i=0;i<mChannels.Count;i++)
            {
                if(key == mChannels[i].mKey)
                {
                    mPointChart.RemoveChannel(mChannels[i].mNTItem);
                    mChannels.RemoveAt(i);
                    break;
                }
            }

            lvChannels.Items.Clear();
            for (int i = 0; i < mChannels.Count; i++)
            {
                AddListViewRow(mChannels[i]);
            }

            SaveChannels();
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Display the chart
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        private void tDisplay_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < mChannels.Count;i++)
            {
                mChannels[i].mNTItem.AddPoint(mChannels[i].GetPoint());
            }

            this.Invalidate();
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Paint the screen
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        private void NetworkTablesGraph_Paint(object sender, PaintEventArgs e)
        {
            mPointChart.Draw(e.Graphics);
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Add button hit
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        private void bAdd_Click(object sender, EventArgs e)
        {
            if(tbKey.Text.Length>0)
            {
                if("" == tbMult.Text)
                {
                    tbMult.Text = "1.0";
                }

                double mult = 0.0;
                double.TryParse(tbMult.Text,out mult);
                double offset = 0.0;
                double.TryParse(tbOffset.Text, out offset);
                AddChannel(tbKey.Text, Color.FromName(cbColor.Text), mult,offset);
                tbKey.Text = "";
                cbColor.SelectedIndex = 0;
                tbMult.Text = "1.0";
                tbOffset.Text = "0.0";
            }
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Delete button hit
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        private void bDelete_Click(object sender, EventArgs e)
        {
            if (tbKey.Text.Length > 0)
            {
                DeleteChannel(tbKey.Text);
            }
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      The user selected a row
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        private void lvChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvChannels.SelectedIndices.Count > 0)
            {
                int index = lvChannels.SelectedIndices[0];
                tbKey.Text = mChannels[index].mKey;
                tbMult.Text = mChannels[index].mMult.ToString();
                tbOffset.Text = mChannels[index].mOffset.ToString();
                for (int i = 0; i < cbColor.Items.Count;i++ )
                {
                    if(mChannels[index].mNTItem.mColor.Name == cbColor.Items[i].ToString())
                    {
                        cbColor.SelectedIndex = i;
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Loads the XML file
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        private void LoadChannels()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CHANNEL_FILE);
            XmlNode node = doc.FirstChild;
            XmlNodeList nodeList = node.ChildNodes;
            foreach(XmlNode newNode in nodeList)
            {
                DataChannel newChannel = new DataChannel(newNode);
                mChannels.Add(newChannel);

                mPointChart.AddChannel(newChannel.mNTItem);
                AddListViewRow(newChannel);
            }
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Saves the channels to the XML file
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        private void SaveChannels()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateNode("element",CHANNELS_TAG,"");
            doc.AppendChild(node);

            for(int i=0;i<mChannels.Count;i++)
            {
                mChannels[i].Save(node, doc);
            }

            doc.Save(CHANNEL_FILE);
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Resize
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        private void NetworkTablesGraph_Resize(object sender, EventArgs e)
        {
            mPointChart.Resize(LEFT_OFFSET, TOP_OFFSET, GetPoints(), this.Size.Height - BOTTOM_OFFSET);
            for(int i=0;i<mChannels.Count;i++)
            {
                mChannels[i].SetNumberOfPoints(GetPoints());
            }
        }

        private void NetworkTablesGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetworkTable.StopClient();
        }
    }

    //----------------------------------------------------------------------------
    //  Purpose:
    //      Handles the channel
    //
    //  Notes:
    //      None
    //
    //----------------------------------------------------------------------------
    class DataChannel
    {
        //----------------------------------------------------------------------------
        //  Class constants
        //----------------------------------------------------------------------------
        public const string CHANNEL_TAG = "Channel";
        public const string COLOR_TAG = "Color";
        public const string KEY_TAG = "Key";
        public const string MULT_TAG = "Mult";
        public const string OFFSET_TAG = "Offset";

        //----------------------------------------------------------------------------
        //  Class Attributes
        //----------------------------------------------------------------------------
        public string mKey = "";
        public double mMult = 1.0;
        public double mOffset = 0.0;
        public double mCur = 0.0;
        public double mLast = 0.0;
        public double mMax = double.MinValue;
        public double mTotal = 0.0;
        public double mMin = double.MaxValue;
        public double mMean = 0.0;
        public int mCount = 0;
        public ListViewItem mLVItem;
        public DateTime mLastTime = DateTime.Now;
        public Channel mNTItem = new Channel(Color.Black, NetworkTablesGraph.MAX_DATA_POINTS);

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Constructor
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public DataChannel()
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
        public DataChannel(string key, double mult, double offset, Channel chan)
        {
            mKey = key;
            mMult = mult;
            mOffset = offset;
            mNTItem = chan;
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Constructor from XML file
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public DataChannel(XmlNode node)
        {
            XmlNodeList childNodes = node.ChildNodes;
            foreach(XmlNode childNode in childNodes)
            {
                if (COLOR_TAG == childNode.Name)
                {
                    mNTItem = new Channel(Color.FromName(childNode.InnerText), NetworkTablesGraph.MAX_DATA_POINTS);
                }
                if (KEY_TAG == childNode.Name)
                {
                    mKey = childNode.InnerText;
                }
                if (MULT_TAG == childNode.Name)
                {
                    double.TryParse(childNode.InnerText, out mMult);
                }
                if (OFFSET_TAG == childNode.Name)
                {
                    double.TryParse(childNode.InnerText, out mOffset);
                }
            }
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Change the number of points to record
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public void SetNumberOfPoints(int points)
        {
            mNTItem.SetPoints(points);
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Set the LV Item
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public void SetLVItem(ListViewItem item)
        {
            mLVItem = item;
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Builds the point, then finds the time since last updated
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public double GetPoint()
        {
            
            mCur = mOffset + (mMult * NetworkTable.GetEntryValueDouble(mKey));

            if (mMax < mCur)
            {
                mMax = mCur;
            }
            if (mMin > mCur)
            {
                mMin = mCur;
            }

            mTotal += mCur;
            mCount++;
            mMean = mTotal / (double)mCount;

            if (null != mLVItem)
            {
                mLVItem.SubItems[NetworkTablesGraph.LV_COL_CUR_VALUE].Text = mCur.ToString("F3");
                mLVItem.SubItems[NetworkTablesGraph.LV_COL_MIN].Text = mMin.ToString("F3");
                mLVItem.SubItems[NetworkTablesGraph.LV_COL_MEAN].Text = mMean.ToString("F3");
                mLVItem.SubItems[NetworkTablesGraph.LV_COL_MAX].Text = mMax.ToString("F3");
                mLVItem.SubItems[NetworkTablesGraph.LV_COL_LAST_TIME].Text = DateTime.Now.Subtract(mLastTime).TotalMilliseconds.ToString();
            }
            mLast = mCur;
            mLastTime = DateTime.Now;
            return mCur;
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      Save to XML File
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        public void Save(XmlNode node, XmlDocument doc)
        {
            XmlNode newNode = doc.CreateNode("element", CHANNEL_TAG, "");

            XmlNode keyNode = doc.CreateNode("element", KEY_TAG, "");
            keyNode.InnerText = mKey;
            newNode.AppendChild(keyNode);

            XmlNode colorNode = doc.CreateNode("element", COLOR_TAG, "");
            colorNode.InnerText = mNTItem.mColor.Name;
            newNode.AppendChild(colorNode);

            XmlNode multNode = doc.CreateNode("element", MULT_TAG, "");
            multNode.InnerText = mMult.ToString();
            newNode.AppendChild(multNode);

            XmlNode offsetNode = doc.CreateNode("element", OFFSET_TAG, "");
            offsetNode.InnerText = mOffset.ToString();
            newNode.AppendChild(offsetNode);

            node.AppendChild(newNode);
        }
    }
}
