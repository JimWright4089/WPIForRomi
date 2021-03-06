﻿using System;
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
using SharpDX.XInput;

using PiMessage;

namespace DS
{
    public partial class DS : Form
    {
        bool mRunThread=true;
        Thread mThread;
        int mCount = 0;
        ConfigureFile mConfig = new ConfigureFile();
        DateTime mStartTime = DateTime.Now;
        byte mStatus = DSStatus.STATUS_DISA;
        Color mBackground = SystemColors.Control;
        DS_Status_Message mCurStatusMessage = new DS_Status_Message();
        DS_Status_Message mDSMessage = new DS_Status_Message();
        RC_Status_Message mRCMessage = new RC_Status_Message();
        Controller_Message mController = new Controller_Message();
        string mMessage = "";
        Controller mGamepad = new SharpDX.XInput.Controller(SharpDX.XInput.UserIndex.One);
        Int16 mLeftX = 0;
        Int16 mLeftY = 0;
        Int16 mRightX = 0;
        Int16 mRightY = 0;
        UInt16 mButtons = 0;
        const int MAX_BUTTONS = 10;
        Int16[] mOldButton = new Int16[MAX_BUTTONS] { 4096, 8192, 16384, -32768, 256, 512, 32, 16, 64, 128 };

        public DS()
        {
            InitializeComponent();

            mRunThread = true;
            mThread = new Thread(RunThread);
            mThread.Name = "GPIB Run Thread";
            mThread.Start();
            tDisplay.Enabled = true;
        }

        UInt16 TranslateButtons(Int16 button)
        {
            UInt16 returnValue = 0;
            for (int i = 0; i < MAX_BUTTONS; i++)
            {
                if (mOldButton[i] == (button & mOldButton[i]))
                {
                    returnValue |= (UInt16)(1 << i);
                }
            }
            return returnValue;
        }


        private void RunThread()
        {
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress send_to_address = IPAddress.Parse(mConfig.mIPAddress);
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, mConfig.mRCPort);

            UdpClient listener = new UdpClient(mConfig.mDSPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, mConfig.mDSPort);
            listener.Client.ReceiveTimeout = 30;
            byte theDouble = 0;

            while (true == mRunThread)
            {
                mCurStatusMessage.SetStatus(mStatus);
                mCurStatusMessage.SetTime((UInt32)DateTime.Now.Subtract(mStartTime).TotalMilliseconds);
                mCurStatusMessage.RollSequenceNumber();

                mController.SetNumber(1);
                for (int i = 0; i < MAX_BUTTONS; i++)
                {
                    mController.SetButton(i, ((1<<i)==(mButtons&(1<<i)))?true:false);
                }
                mController.SetAnalog(0, (short)(mLeftX / 256));
                mController.SetAnalog(1, (short)(mLeftY / 256));
                mController.SetAnalog(2, (short)(mRightX / 256));
                mController.SetAnalog(3, (short)(mRightY / 256));

                theDouble += 1;

                byte[] theData = mCurStatusMessage.GetData();

                sending_socket.SendTo(theData, sending_end_point); //  Repeat this as many times you want

                theData = mController.GetData();
                sending_socket.SendTo(theData, sending_end_point); //  Repeat this as many times you want

                Thread.Sleep(2);
                
                try
                {
                    theData = listener.Receive(ref groupEP); // You can repeat this as many times, but you can’t send stuff using this port.
                    PiMessage.Message theMessage = MessageFactory.Build(theData);
                    if (null != theMessage)
                    {
                        switch (theMessage.GetMessageID())
                        {
                            case (PiMessage.Message.MessageIDs.DS_STATUS):
                                mDSMessage = (DS_Status_Message)theMessage;
                                break;
                            case (PiMessage.Message.MessageIDs.RC_STATUS):
                                mRCMessage = (RC_Status_Message)theMessage;
                                break;
                        }
                    }

                    if (mCurStatusMessage.GetSequence() != mRCMessage.GetSequence())
                    {
                        mMessage = "Skipped";
                    }
                    else
                    {
                        mMessage = "OK";
                    }

                }
                catch(Exception e)
                {
                    mMessage = e.Message;
                }
                
                mCount++;
                Thread.Sleep(50);
            }
            sending_socket.Close();
        }

        private void bA_Click(object sender, EventArgs e)
        {
            if(mBackground == bA.BackColor)
            {
                bTel.BackColor = mBackground;
                bTest.BackColor = mBackground;
                bA.BackColor = Color.LightGreen;
                mStatus = DSStatus.STATUS_AUTO;
            }
            else
            {
                bA.BackColor = mBackground;
                mStatus = DSStatus.STATUS_DISA;
            }
            mStartTime = DateTime.Now;
        }

        private void bTel_Click(object sender, EventArgs e)
        {
            if (mBackground == bTel.BackColor)
            {
                bA.BackColor = mBackground;
                bTest.BackColor = mBackground;
                bTel.BackColor = Color.LightGreen;
                mStatus = DSStatus.STATUS_TELE;
            }
            else
            {
                bTel.BackColor = mBackground;
                mStatus = DSStatus.STATUS_DISA;
            }
            mStartTime = DateTime.Now;
        }

        private void bTest_Click(object sender, EventArgs e)
        {
            if (mBackground == bTest.BackColor)
            {
                bA.BackColor = mBackground;
                bTel.BackColor = mBackground;
                bTest.BackColor = Color.LightGreen;
                mStatus = DSStatus.STATUS_TEST;
            }
            else
            {
                bTest.BackColor = mBackground;
                mStatus = DSStatus.STATUS_DISA;
            }
            mStartTime = DateTime.Now;
        }

        private void DS_FormClosing(object sender, FormClosingEventArgs e)
        {
            mRunThread = false;
            Thread.Sleep(11);
        }

        private void tDisplay_Tick(object sender, EventArgs e)
        {
            lCount.Text = mCount.ToString();
            byte[] theData = mCurStatusMessage.GetSendData();

            switch(mStatus)
            {
                case (DSStatus.STATUS_AUTO):
                    lStatus.Text = "Auto";
                    break;
                case (DSStatus.STATUS_TELE):
                    lStatus.Text = "Tele";
                    break;
                case (DSStatus.STATUS_TEST):
                    lStatus.Text = "Test";
                    break;
                default:
                    lStatus.Text = "Dis";
                    break;
            }

            lTime.Text = mCurStatusMessage.GetTime().ToString();
            lSequence.Text = mCurStatusMessage.GetSequence().ToString();
            lLength.Text = theData.Length.ToString();

            switch(mRCMessage.GetStatus())
            {
                case (RCStatus.STATUS_GOOD):
                    lRCStatus.Text = "Good";
                    break;
                case (RCStatus.STATUS_FAIL):
                    lRCStatus.Text = "Fail";
                    break;
            }

            lRCTime.Text = mRCMessage.GetTime().ToString();
            lRCSequence.Text = mRCMessage.GetSequence().ToString();

            if (mCurStatusMessage.GetSequence() != mRCMessage.GetSequence())
            {
                lRCSequence.BackColor = Color.LightCoral;
            }
            else
            {
                lRCSequence.BackColor = Color.LightGreen;
            }

            theData = mController.GetData();
            UInt32 buttondata = Controller_Message.GetU32FrombyteArray(theData, Controller_Message.BUTTONS_BYTE_LOC);
            lControl.Text = buttondata.ToString();

            lMessage.Text = mMessage;

            State theState = mGamepad.GetState();
            mLeftX = (Int16)(theState.Gamepad.LeftThumbX);
            mLeftY = (Int16)(theState.Gamepad.LeftThumbY);
            mRightX = (Int16)(theState.Gamepad.RightThumbX);
            mRightY = (Int16)(theState.Gamepad.RightThumbY);
            mButtons = TranslateButtons((Int16)theState.Gamepad.Buttons);

            lControl.Text = mButtons.ToString() + " " + mLeftX.ToString() + " " + mLeftY.ToString(); ;
        }

        private void bTestStuff_Click(object sender, EventArgs e)
        {
            DS_Status_Message theMessage = new DS_Status_Message();

            theMessage.SetStatus(mStatus);
            theMessage.SetTime((UInt32)DateTime.Now.Subtract(mStartTime).TotalMilliseconds);

            byte[] theData = theMessage.GetData();
        }
    }
}
