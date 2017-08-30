//----------------------------------------------------------------------------
//
//  $Workfile: ServerCSharpTest.cs$
//
//  $Revision: X$
//
//  Project:    Networktables C#
//
//                            Copyright (c) 2017
//                               James A Wright
//                            All Rights Reserved
//
//  Modification History:
//  $Log:
//  $
//
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using NetworkTablesInterface;

namespace ClientCSharpTest
{
    //----------------------------------------------------------------------------
    //  Class Declarations
    //----------------------------------------------------------------------------
    //
    // Class Name: ClientCSharpTest
    // 
    // Purpose:
    //      This class tests the Networktable Client
    //
    //----------------------------------------------------------------------------
    public partial class ClientCSharpTest : Form
    {
        //----------------------------------------------------------------------------
        //  Class Attributes 
        //----------------------------------------------------------------------------
        double mOldData = 0;
        DateTime mOldTime = DateTime.Now;
        long mTotalTime = 0;
        long mCount = 0;

        //--------------------------------------------------------------------
        // Purpose:
        //     Constructor.
        //
        // Notes:
        //     None.
        //--------------------------------------------------------------------
        public ClientCSharpTest()
        {
            InitializeComponent();

            NetworkTable.StartClient("127.0.0.1", 1735);

            tDisplay.Enabled = true;
        }

        //--------------------------------------------------------------------
        // Purpose:
        //     Display Timer Tick
        //
        // Notes:
        //     None.
        //--------------------------------------------------------------------
        private void tDisplay_Tick(object sender, EventArgs e)
        {
            double sin = NetworkTable.GetEntryValueDouble("/datatable/x");
            double sin2 = NetworkTable.GetEntryValueDouble("/string");

            string text = NetworkTable.GetEntryValueString("/string").ToString();

            bool theBool = NetworkTable.GetEntryValueBool("/bool");
            bool theBool2 = NetworkTable.GetEntryValueBool("/bool2");

            lDouble.Text = sin.ToString("F4");
            lString.Text = text;
            lBool.Text = theBool.ToString();
            lDouble2.Text = sin2.ToString("F3");

            if(mOldData != sin)
            {
                long lastTime = (long)DateTime.Now.Subtract(mOldTime).TotalMilliseconds;
                lLastTime.Text = lastTime.ToString();
                mTotalTime += lastTime;
                mCount++;
                lTime.Text = ((double)mTotalTime / (double)mCount).ToString("F4");
                mOldTime = DateTime.Now;
                mOldData = sin;
            }
        }
    }
}
