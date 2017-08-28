using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace NetTables
{
    public class NetTables
    {
        const int MAX_BUFFER_SIZE = 40000;
        const int MAX_SMALL_BUFFER_SIZE = 4000;
        bool mRunThread = true;
        Thread mCommThread;
        Socket mSocket = null;
        static Semaphore mSemephore = new Semaphore(1, 1);
        string mIPAddress = "";
        int mPort = 0;
        Queue<NetTablesMessages> mSendMessages = new Queue<NetTablesMessages>();
        byte[] mReadBytes = new byte[MAX_BUFFER_SIZE];
        int mReadBytesLength = 0;
        NTString mServer = new NTString();
        List<NetTablesEntry> mEntries = new List<NetTablesEntry>();

        public NetTables()
        {
            mRunThread = true;
            mCommThread = new Thread(new ThreadStart(RunCommThread));
            mCommThread.Name = string.Format("Handle AFDX ");
            mCommThread.IsBackground = true;
            mCommThread.Start();
        }

        public bool StartClient(string address, int port)
        {
            mIPAddress = address;
            mPort = port;

            IPAddress[] addresslist = Dns.GetHostAddresses(mIPAddress);

            if (addresslist.Length > 0)
            {
                mSemephore.WaitOne();
                mSocket = new Socket(AddressFamily.InterNetwork,
                                     SocketType.Stream,
                                     ProtocolType.Tcp);

                mSocket.Connect(addresslist, mPort);
                mSocket.ReceiveTimeout = 100;
                mSocket.DontFragment = true;

                mSendMessages.Enqueue(new ClientHelloMessage());
                mSemephore.Release();
                Thread.Sleep(10);
                mSendMessages.Enqueue(new ClientHelloCompleteMessage());
            }
            else
            {
                return false;
            }

            return true;
        }

        public int GetNumberOfEntries()
        {
            return mEntries.Count;
        }

        public NetTablesEntry GetEntry(string key)
        {
            for (int i = 0; i < mEntries.Count;i++)
            {
                if(mEntries[i].GetKey() == key)
                {
                    return mEntries[i];
                }
            }

            return new NetTablesEntry();
        }

        public NetTablesEntry GetEntry(int id)
        {
            for (int i = 0; i < mEntries.Count; i++)
            {
                if (mEntries[i].GetID() == id)
                {
                    return mEntries[i];
                }
            }

            return new NetTablesEntry();
        }

        public void Refresh()
        {
            
        }

        public void Stop()
        {
            mRunThread = false;

            while(mCommThread.IsAlive)
            {
                Thread.Sleep(10);
            }
        }

        //----------------------------------------------------------------------------
        //  Purpose:
        //      the thread that does the work
        //
        //  Notes:
        //      None
        //
        //----------------------------------------------------------------------------
        private void RunCommThread()
        {
            DateTime oldTime = DateTime.Now;
            int len = 0;
            KeepAliveMessage pingMessage = new KeepAliveMessage();
            byte[] data = new byte[MAX_SMALL_BUFFER_SIZE];
            int bytesToRemove = 0;
            int stringBytesLength;
            int size;
            int totalSize = 0;
            BooleanEntry boolEntry;
            StringEntry stringEntry;
            DoubleEntry doubleEntry;

            while (true == mRunThread)
            {
                if (null != mSocket)
                {
                    if (mSocket.Connected)
                    {
                        mSemephore.WaitOne();
                        try
                        {
                            if (DateTime.Now.Subtract(oldTime).TotalMilliseconds > 1000)
                            {
                                mSocket.Send(pingMessage.GetBytes());
                                oldTime = DateTime.Now;
                            }
                            else
                            {
                                if(mSendMessages.Count>0)
                                {
                                    NetTablesMessages curMessage = mSendMessages.Dequeue();
                                    mSocket.Send(curMessage.GetBytes());
                                }
                            }

                            len = mSocket.Receive(data);

                            if((mReadBytesLength+len)>MAX_BUFFER_SIZE)
                            {
                                // If the buffer is clogged clear it
                                mReadBytesLength = 0;
                            }
                            else
                            {
                                for(int i=0;i<len;i++)
                                {
                                    mReadBytes[mReadBytesLength + i] = data[i];
                                }
                                mReadBytesLength += len;
                            }
                        }
                        catch (SocketException e)
                        {
                            if (10060 != e.ErrorCode)
                            {
                                Console.WriteLine(e.ToString());
                                Console.WriteLine(">>" + e.ErrorCode.ToString());
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        mSemephore.Release();

                        if (mReadBytesLength > 0)
                        {
                            bytesToRemove=1;
                            while ((bytesToRemove > 0) && (mReadBytesLength > 0))
                            {
                                bytesToRemove = 0;

                                switch (mReadBytes[0])
                                {
                                    case ((byte)NetTablesMessages.MessageTypes.SERVER_HELLO):
                                        if (mReadBytesLength > 2)
                                        {
                                            stringBytesLength = 0;
                                            size = (int)NetTablesEntry.DecodeLEB128(mReadBytes, 2, out stringBytesLength);

                                            if ((stringBytesLength + size + 2) <= mReadBytesLength)
                                            {
                                                mServer = new NTString(mReadBytes, 2, out bytesToRemove);
                                                bytesToRemove += 2 + size;
                                            }
                                        }
                                        break;
                                    case ((byte)NetTablesMessages.MessageTypes.CLIENT_HELLO_COMPLETE):
                                        bytesToRemove = 1;
                                        break;
                                    case ((byte)NetTablesMessages.MessageTypes.SERVER_HELLO_COMPLETE):
                                        bytesToRemove = 1;
                                        break;
                                    case ((byte)NetTablesMessages.MessageTypes.ENTRY_ASSIGNMENT):
                                        stringBytesLength = 0;
                                        size = (int)NetTablesEntry.DecodeLEB128(mReadBytes, 1, out stringBytesLength);
                                        totalSize = stringBytesLength + size + 1;

                                        if ((totalSize + 7) <= mReadBytesLength)
                                        {
                                            NTString entryKey = new NTString(mReadBytes, 1, out stringBytesLength);
                                            int type = mReadBytes[totalSize];
                                            totalSize++;
                                            int entryNumber = (mReadBytes[totalSize] << 8) + mReadBytes[totalSize + 1];
                                            totalSize += 2;
                                            int sequenceNumber = (mReadBytes[totalSize] << 8) + mReadBytes[totalSize + 1];
                                            totalSize += 2;
                                            int entryFlag = mReadBytes[totalSize];
                                            totalSize++;

                                            switch (type)
                                            {
                                                case ((int)NetTablesEntry.EntryType.BOOLEAN):
                                                    boolEntry = new BooleanEntry(mReadBytes, totalSize);
                                                    boolEntry.SetID(entryNumber);
                                                    boolEntry.SetKey(entryKey);
                                                    mEntries.Add(boolEntry);
                                                    totalSize++;
                                                    bytesToRemove = totalSize;
                                                    break;
                                                case ((int)NetTablesEntry.EntryType.DOUBLE):
                                                    if ((totalSize + 8) <= mReadBytesLength)
                                                    {
                                                        doubleEntry = new DoubleEntry(mReadBytes, totalSize);
                                                        doubleEntry.SetID(entryNumber);
                                                        doubleEntry.SetKey(entryKey);
                                                        mEntries.Add(doubleEntry);
                                                        totalSize += 8;
                                                        bytesToRemove = totalSize;
                                                    }
                                                    break;
                                                case ((int)NetTablesEntry.EntryType.STRING):
                                                    stringBytesLength = 0;
                                                    size = (int)NetTablesEntry.DecodeLEB128(mReadBytes, totalSize, out stringBytesLength);

                                                    if ((totalSize + stringBytesLength + size) <= mReadBytesLength)
                                                    {
                                                        NTString stringEntryString = new NTString(mReadBytes, totalSize, out stringBytesLength);
                                                        stringEntry = new StringEntry(stringEntryString);
                                                        stringEntry.SetID(entryNumber);
                                                        stringEntry.SetKey(entryKey);
                                                        mEntries.Add(stringEntry);
                                                        totalSize += stringBytesLength;
                                                        bytesToRemove = totalSize;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case ((byte)NetTablesMessages.MessageTypes.ENTRY_UPDATE):
                                        totalSize = 0;
                                        if ((totalSize + 7) <= mReadBytesLength)
                                        {
                                            totalSize++;
                                            int entryNumber = (mReadBytes[totalSize] << 8) + mReadBytes[totalSize + 1];
                                            totalSize += 2;
                                            int sequenceNumber = (mReadBytes[totalSize] << 8) + mReadBytes[totalSize + 1];
                                            totalSize += 2;
                                            int type = mReadBytes[totalSize];
                                            totalSize++;

                                            switch (type)
                                            {
                                                case ((int)NetTablesEntry.EntryType.BOOLEAN):
                                                    boolEntry = (BooleanEntry)GetEntry(entryNumber);
                                                    boolEntry.Update(mReadBytes, totalSize);
                                                    totalSize++;
                                                    bytesToRemove = totalSize;
                                                    break;
                                                case ((int)NetTablesEntry.EntryType.DOUBLE):
                                                    if ((totalSize + 8) <= mReadBytesLength)
                                                    {
                                                        doubleEntry = (DoubleEntry)GetEntry(entryNumber);
                                                        doubleEntry.Update(mReadBytes, totalSize);
                                                        totalSize += 8;
                                                        bytesToRemove = totalSize;
                                                    }
                                                    break;
                                                case ((int)NetTablesEntry.EntryType.STRING):
                                                    stringBytesLength = 0;
                                                    size = (int)NetTablesEntry.DecodeLEB128(mReadBytes, totalSize, out stringBytesLength);

                                                    if ((totalSize + stringBytesLength + size) <= mReadBytesLength)
                                                    {
                                                        NTString stringEntryString = new NTString(mReadBytes, totalSize, out stringBytesLength);
                                                        stringEntry = (StringEntry)GetEntry(entryNumber);
                                                        stringEntry.Update(stringEntryString);
                                                        totalSize += stringBytesLength;
                                                        bytesToRemove = totalSize;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;

                                    default:
                                        bytesToRemove = 1;
                                        break;
                                }

                                removeDataForNextMessage(bytesToRemove, false);
                            }
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }

        private void removeDataForNextMessage(int offset, bool isBad)
        {
            int index;

            //Move the first 'offset' number of bytes forward.
            for (index = 0; index < mReadBytesLength - offset; index++)  // JSF162 JSF213 Exception
            {
                mReadBytes[index] = mReadBytes[offset + index];
            }

            //if we have been asked to remove more bytes than we have set the number
            //of bytes to 0.
            if (offset > mReadBytesLength)
            {
                mReadBytesLength = 0;
            }
            else
            {
                //If not then reduce the number of bytes we have by the offset.
                mReadBytesLength -= offset;
            }

            //Move the rest of the message down to right after the 'offset' bytes.
            // Process the rest of the buffer
            for (; index < MAX_BUFFER_SIZE; index++)   // JSF200 JSF162 Exception
            {
                //If we are under the MAX packet size then move the data.
                if ((offset + index) < (mReadBytesLength))
                {
                    mReadBytes[index] = mReadBytes[offset + index];
                }
                else
                {
                    //If we are over the MAX packet size then clear out the bytes.
                    mReadBytes[index] = 0;
                }
            }
        }
    }
}
