using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace NetworkTablesInterface
{
    public class NetworkTable
    {
        public const int NT_PERSISTENT = 0x01;
        public const string DLLLib = ".\\NetworkTables.dll";

        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "DeleteEntry")]
        public static extern void DeleteEntry(String name);

        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "DeleteAllEntries")]
        public static extern void DeleteAllEntries();

        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetNetworkIdentity")]
        public static extern void SetNetworkIdentity(String name);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StartServer")]
        public static extern void StartServer(String persist_filename, String listen_address, int port);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StopServer")]
        public static extern void StopServer();
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StartClient")]
        public static extern void StartClient();
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StartClient")]
        public static extern void StartClient(String server_name, int port);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StopClient")]
        public static extern void StopClient();
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetServer")]
        public static extern void SetServer(String server_name, int port);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StartDSClient")]
        public static extern void StartDSClient(int port);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StopDSClient")]
        public static extern void StopDSClient();
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StopRpcServer")]
        public static extern void StopRpcServer();
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "StopNotifier")]
        public static extern void StopNotifier();
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetUpdateRate")]
        public static extern void SetUpdateRate(double interval);

        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetEntryValueString")]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string GetEntryValueString(String name);

        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetEntryValueDouble")]
        public static extern double GetEntryValueDouble(String name);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetEntryValueBool")]
        public static extern bool GetEntryValueBool(String name);


        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetDefaultEntryValueString")]
        public static extern bool SetDefaultEntryValueString(String name, String value);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetDefaultEntryValueDouble")]
        public static extern bool SetDefaultEntryValueDouble(String name, double value);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetDefaultEntryValueBool")]
        public static extern bool SetDefaultEntryValueBool(String name, bool value);

        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryFlags")]
        public static extern void SetEntryFlags(String name, int flags);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetEntryFlags")]
        public static extern int GetEntryFlags(String name);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Flush")]
        public static extern void Flush();

        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryValueString")]
        public static extern bool SetEntryValueString(String name, String value);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryValueDouble")]
        public static extern bool SetEntryValueDouble(String name, double value);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryValueBool")]
        public static extern bool SetEntryValueBool(String name, bool value);

        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryTypeValueString")]
        public static extern void SetEntryTypeValueString(String name, String value);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryTypeValueDouble")]
        public static extern void SetEntryTypeValueDouble(String name, double value);
        [DllImport(DLLLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetEntryTypeValueBool")]
        public static extern void SetEntryTypeValueBool(String name, bool value);

    }
}
