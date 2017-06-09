using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

using PiMessage;

namespace RC
{
    public partial class RC : Form
    {
        bool mRunThread = true;
        Thread mThread;
        int mCount = 0;
        byte[] mData = new byte[0];
        ConfigureFile mConfigFile = new ConfigureFile();
        string mMessage = "";
        DS_Status_Message mDSMessage = new DS_Status_Message();
        RC_Status_Message mRCMessage = new RC_Status_Message();
        DateTime mStartTime = DateTime.Now;
        UInt16 mLastSequence = 0;

        public RC()
        {
            InitializeComponent();

            mRunThread = true;
            mThread = new Thread(RunThread);
            mThread.Name = "GPIB Run Thread";
            mThread.Start();
            tDisplay.Enabled = true;
        }

        private void RunThread()
        {
            UdpClient listener = new UdpClient(mConfigFile.mRCPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, mConfigFile.mRCPort);
            listener.Client.ReceiveTimeout = 60;
/*
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress send_to_address = IPAddress.Parse(mConfig.mIPAddress);
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, mConfig.mRCPort);
*/
            bool SenderOpen = false;
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress send_to_address = IPAddress.Parse("127.0.0.1");
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, mConfigFile.mDSPort);
            PiMessage.RC_Status_Message RCMessage = new RC_Status_Message();

            while (true == mRunThread)
            {
                mCount++;

                try
                {
                    mData = listener.Receive(ref groupEP); // You can repeat this as many times, but you can’t send stuff using this port.

                    PiMessage.Message theMessage = MessageFactory.Build(mData);
                    if(null != theMessage)
                    {
                        switch(theMessage.GetMessageID())
                        {
                            case(PiMessage.Message.MessageIDs.DS_STATUS):
                                mDSMessage = (DS_Status_Message)theMessage;
                                break;
                        }
                    }

                    if(mLastSequence+1 != mDSMessage.GetSequence())
                    {
                        mMessage = "Skipped";
                    }
                    else
                    {
                        mMessage = "OK";
                    }
                    mLastSequence = mDSMessage.GetSequence();

                    
                    if(false == SenderOpen)
                    {
                        send_to_address = groupEP.Address;
                        sending_end_point = new IPEndPoint(send_to_address, mConfigFile.mDSPort);
                        SenderOpen = true;
                    }

                    mRCMessage.SetStatus(PiMessage.RCStatus.STATUS_GOOD);
                    mRCMessage.SetSequence(mDSMessage.GetSequence());
                    mRCMessage.SetTime((UInt32)DateTime.Now.Subtract(mStartTime).TotalMilliseconds);

                    mData = mRCMessage.GetData();

                    sending_socket.SendTo(mData, sending_end_point); //  Repeat this as many times you want
                    
                }
                catch(SocketException e)
                {
                    //if(0x0000274c != e.ErrorCode)
                    {
                        mMessage = e.Message.ToString();
                    }
                }
                catch(Exception e)
                {
                    mMessage = e.Message.ToString();
                }

                Thread.Sleep(5);
            }
            listener.Close();
        }

        private void tDisplay_Tick(object sender, EventArgs e)
        {
            lCount.Text = mCount.ToString();
            lDataLength.Text = mData.Length.ToString();
            lMesssage.Text = mMessage;

            switch(mDSMessage.GetStatus())
            {
                case (DSStatus.STATUS_AUTO):
                    lStatus.Text = "Auto";
                    break;
                case (DSStatus.STATUS_DISA):
                    lStatus.Text = "Disa";
                    break;
                case (DSStatus.STATUS_TELE):
                    lStatus.Text = "Tele";
                    break;
                case (DSStatus.STATUS_TEST):
                    lStatus.Text = "Test";
                    break;
            }

            lTime.Text = mDSMessage.GetTime().ToString();
            lSequence.Text = mDSMessage.GetSequence().ToString();
        }

        private void RC_FormClosed(object sender, FormClosedEventArgs e)
        {
            mRunThread = false;
            Thread.Sleep(30);
        }
    }
}
