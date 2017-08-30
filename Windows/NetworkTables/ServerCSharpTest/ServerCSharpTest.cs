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

namespace ServerCSharpTest
{
    //----------------------------------------------------------------------------
    //  Class Declarations
    //----------------------------------------------------------------------------
    //
    // Class Name: ServerCSharpTest
    // 
    // Purpose:
    //      This class tests the Networktable Server
    //
    //----------------------------------------------------------------------------
    public partial class ServerCSharpTest : Form
    {
        //----------------------------------------------------------------------------
        //  Class Attributes 
        //----------------------------------------------------------------------------
        double mCount = 0.0;
        long mCountLong = 0;

        //--------------------------------------------------------------------
        // Purpose:
        //     Constructor.
        //
        // Notes:
        //     None.
        //--------------------------------------------------------------------
        public ServerCSharpTest()
        {
            InitializeComponent();
            NetworkTable.Flush();
            NetworkTable.StartServer("persistent.ini", "", 10000);
            NetworkTable.SetEntryValueDouble("/foo", 0.5);
            NetworkTable.SetEntryFlags("/foo", NetworkTable.NT_PERSISTENT);
            NetworkTable.SetEntryValueDouble("/foo2", 0.5);
            NetworkTable.SetEntryValueDouble("/foo2", 0.7);
            NetworkTable.SetEntryValueDouble("/foo2", 0.6);
            NetworkTable.SetEntryValueDouble("/foo2", 0.5);
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
            // Find the values to send
            double sin = Math.Sin(mCount) * 100.0;
            lSin.Text = sin.ToString("F4");
            string text = "Sin:" + sin.ToString("f2");
            bool theBool = (0 == (mCountLong % 2));
            mCountLong++;

            // Set the entries
            NetworkTable.SetEntryValueDouble("/double", sin);
            NetworkTable.SetEntryValueDouble("/sin", Math.Sin(mCount));
            NetworkTable.SetEntryValueDouble("/cos", Math.Cos(mCount));
            NetworkTable.SetEntryValueString("/string", text);
            NetworkTable.SetEntryValueBool("/bool", theBool);
            mCount += 0.01;
        }
    }
}
