//----------------------------------------------------------------------------
//
//  $Workfile: NetworkTable.cs$
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
using System.Runtime.InteropServices;

namespace NetworkTablesInterface
{
    //----------------------------------------------------------------------------
    //  Class Declarations
    //----------------------------------------------------------------------------
    //
    // Class Name: NetworkTable
    // 
    // Purpose:
    //      Interface between C# and C++
    //
    //----------------------------------------------------------------------------
    public class NetworkTable
    {
        //----------------------------------------------------------------------------
        //  Class Constants 
        //----------------------------------------------------------------------------
        public const int NT_PERSISTENT = 0x01;

        //----------------------------------------------------------------------------
        //  Class Attributes 
        //----------------------------------------------------------------------------
        public const string mDLLLib = ".\\NetworkTables.dll";

        //----------------------------------------------------------------------------
        //  DLL Imports 
        //----------------------------------------------------------------------------
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "DeleteEntry")]
        public static extern void DeleteEntry(String name);

        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "DeleteAllEntries")]
        public static extern void DeleteAllEntries();

        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetNetworkIdentity")]
        public static extern void SetNetworkIdentity(String name);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StartServer")]
        public static extern void StartServer(String persist_filename, String listen_address, int port);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StopServer")]
        public static extern void StopServer();
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StartClient")]
        public static extern void StartClient();
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StartClient")]
        public static extern void StartClient(String server_name, int port);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StopClient")]
        public static extern void StopClient();
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetServer")]
        public static extern void SetServer(String server_name, int port);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StartDSClient")]
        public static extern void StartDSClient(int port);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StopDSClient")]
        public static extern void StopDSClient();
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StopRpcServer")]
        public static extern void StopRpcServer();
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StopNotifier")]
        public static extern void StopNotifier();
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetUpdateRate")]
        public static extern void SetUpdateRate(double interval);

        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetEntryValueString")]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string GetEntryValueString(String name);

        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetEntryValueDouble")]
        public static extern double GetEntryValueDouble(String name);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetEntryValueBool")]
        public static extern bool GetEntryValueBool(String name);


        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetDefaultEntryValueString")]
        public static extern bool SetDefaultEntryValueString(String name, String value);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetDefaultEntryValueDouble")]
        public static extern bool SetDefaultEntryValueDouble(String name, double value);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetDefaultEntryValueBool")]
        public static extern bool SetDefaultEntryValueBool(String name, bool value);

        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryFlags")]
        public static extern void SetEntryFlags(String name, int flags);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetEntryFlags")]
        public static extern int GetEntryFlags(String name);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Flush")]
        public static extern void Flush();

        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryValueString")]
        public static extern bool SetEntryValueString(String name, String value);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryValueDouble")]
        public static extern bool SetEntryValueDouble(String name, double value);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryValueBool")]
        public static extern bool SetEntryValueBool(String name, bool value);

        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryTypeValueString")]
        public static extern void SetEntryTypeValueString(String name, String value);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryTypeValueDouble")]
        public static extern void SetEntryTypeValueDouble(String name, double value);
        [DllImport(mDLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryTypeValueBool")]
        public static extern void SetEntryTypeValueBool(String name, bool value);
    }
}
