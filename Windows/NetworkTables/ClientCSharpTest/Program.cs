//----------------------------------------------------------------------------
//
//  $Workfile: Program.cs$
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

namespace ClientCSharpTest
{
    //----------------------------------------------------------------------------
    //  Class Declarations
    //----------------------------------------------------------------------------
    //
    // Class Name: Program
    // 
    // Purpose:
    //      Main app runner
    //
    //----------------------------------------------------------------------------
    static class Program
    {
        //--------------------------------------------------------------------
        // Purpose:
        //     Main Idle Loop
        //
        // Notes:
        //     The main entry point for the application.
        //--------------------------------------------------------------------
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ClientCSharpTest());
        }
    }
}
