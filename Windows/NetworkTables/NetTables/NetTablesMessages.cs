using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTables
{
    public class NetTablesMessages
    {
        public enum MessageTypes
        {
            KEEP_ALIVE = 0x00,
            CLIENT_HELLO = 0x01,
            PROTOCOL_VERSION_UNSUPPORTED = 0x02,
            SERVER_HELLO_COMPLETE = 0x03,
            SERVER_HELLO = 0x04,
            CLIENT_HELLO_COMPLETE = 0x05,
            ENTRY_ASSIGNMENT = 0x10,
            ENTRY_UPDATE = 0x11,
            ENTRY_FLAG_UPDATE = 0x12,
            ENTRY_DELETE = 0x13,
            CLEAR_ALL_ENTRIES = 0x14,
            RPC_EXECUTE = 0x20,
            RPC_RESPONSE = 0x21
        };

        protected MessageTypes mMessageType = MessageTypes.KEEP_ALIVE;
        protected int mLength = 0;
        protected byte[] mData = new byte[0];

        public NetTablesMessages()
        {

        }

        public virtual byte[] GetBytes()
        {
            return mData;
        }

        public virtual int GetLength()
        {
            return mLength;
        }
    }

    public class KeepAliveMessage : NetTablesMessages
    {
        public KeepAliveMessage()
        {
            mMessageType = NetTablesMessages.MessageTypes.KEEP_ALIVE;
            mLength = 1;
            mData = new byte[mLength];
            mData[0] = (byte)mMessageType;
        }
    }

    public class ClientHelloMessage : NetTablesMessages
    {
        StringEntry mClientName = new StringEntry();
        byte mVersionMajor = 0x03;
        byte mVersionMinor = 0x00;
        public ClientHelloMessage()
        {
            mMessageType = NetTablesMessages.MessageTypes.CLIENT_HELLO;

            byte[] serverName = mClientName.GetBytes();
            mLength = 3 + serverName.Length;
            mData = new byte[mLength];
            mData[0] = (byte)mMessageType;
            mData[1] = mVersionMajor;
            mData[2] = mVersionMinor;

            for(int i=0;i<serverName.Length;i++)
            {
                mData[3 + i] = serverName[i];
            }
        }
    }

    public class ProtocolVersionUnsupportedMessage : NetTablesMessages
    {
        byte mMajorVersion = 0x03;
        byte mMinorVersion = 0x00;

        public ProtocolVersionUnsupportedMessage()
        {
            mMessageType = NetTablesMessages.MessageTypes.PROTOCOL_VERSION_UNSUPPORTED;

            mLength = 3;
            mData = new byte[mLength];
            mData[0] = (byte)mMessageType;
            mData[1] = mMajorVersion;
            mData[2] = mMinorVersion;
        }
    }

    public class ServerHelloCompleteMessage : NetTablesMessages
    {
        public ServerHelloCompleteMessage()
        {
            mMessageType = NetTablesMessages.MessageTypes.SERVER_HELLO_COMPLETE;

            mLength = 1;
            mData = new byte[mLength];
            mData[0] = (byte)mMessageType;
        }
    }

    public class ServerHelloMessage : NetTablesMessages
    {
        StringEntry mServerName = new StringEntry();
        byte mFlag = 0x00;
        public ServerHelloMessage()
        {
            mMessageType = NetTablesMessages.MessageTypes.SERVER_HELLO;

            byte[] serverName = mServerName.GetBytes();
            mLength = 2 + serverName.Length;
            mData = new byte[mLength];
            mData[0] = (byte)mMessageType;
            mData[1] = mFlag;

            for(int i=0;i<serverName.Length;i++)
            {
                mData[2 + i] = serverName[i];
            }
        }
    }

    class ClientHelloCompleteMessage : NetTablesMessages
    {
        public ClientHelloCompleteMessage()
        {
            mMessageType = NetTablesMessages.MessageTypes.CLIENT_HELLO_COMPLETE;

            mLength = 1;
            mData = new byte[mLength];
            mData[0] = (byte)mMessageType;
        }
    }

    class EntryAssignmentMessage : NetTablesMessages
    {

    }

    class EntryUpdateMessage : NetTablesMessages
    {

    }

    class EntryFlagsUpdateMessage : NetTablesMessages
    {

    }

    class EntryDeleteMessage : NetTablesMessages
    {

    }

    class ClearAllEntriesMessage : NetTablesMessages
    {

    }

    class RPCExecuteMessage : NetTablesMessages
    {

    }

    class RPCResponseMessage : NetTablesMessages
    {

    }
}
