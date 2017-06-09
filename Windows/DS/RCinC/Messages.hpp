#ifndef MESSAGES_HPP
#define MESSAGES_HPP

#include "Status.hpp"
#include "Common.h"

class Message
{
    public:
        enum MessageIDs
        {
            Reserved1 = 0,
            DS_STATUS = 1,
            RC_STATUS = 2,
            CONNTROLLER = 3
        };

        static const int MAX_BUFFER = 1000;

        static const int START_BYTE_LOC = 0;
        static const int COMMAND_BYTE_LOC = 1;
        static const int SEQUENCE_BYTE_LOC = 2;
        static const int DATA_BYTE_LOC = 4;
        static const int END_BYTE_LOC = -2;
        static const int CRC_BYTE_LOC = -1;

        static const byte START_CHAR = 0xA0;
        static const byte END_CHAR = 0xA1;
        static const byte SPECIAL_CHAR = 0xA2;
        static const byte NEW_START_CHAR = 0xB0;
        static const byte NEW_END_CHAR = 0xB1;
        static const byte NEW_SPECIAL_CHAR = 0xB2;

        Message();
        UInt16 GetNextSequence();
        MessageIDs GetMessageID();
        void GetSendData(byte* returnBytes, int returnBytesLength);
        void RollSequenceNumber();
        UInt16 GetSequence();
        void SetSequence(UInt16 sequence);
        void GetData(byte* returnBytes, int* returnBytesLength);
        UInt32 GetLength();
        void buildCheckByte();
        byte calcCheckByte();
        byte getCheckByte();

    private:
        static UInt16 mNextSequence;

    protected:
        MessageIDs mID;
        UInt32 mLength;
        UInt32 mSendDataLength;
        byte mData[MAX_BUFFER];
        byte mSendData[MAX_BUFFER];
        byte GetFirstByte();
};

class DS_Status_Message : public Message
{
        public:
        static const int STATUS_BYTE_LOC = 4;
        static const int TIME_BYTE_LOC = 10;

        DS_Status_Message();
        DS_Status_Message(byte* data, int dataLen);
        void SetStatus(byte status);
        void SetTime(UInt32 theTime);
        UInt32 GetTime();
        byte GetStatus();

        protected:
    UInt32 mTime;
};

class RC_Status_Message : public Message
{
        public:
    static const  int STATUS_BYTE_LOC = 4;
        static const  int TIME_BYTE_LOC = 10;

        RC_Status_Message();
        RC_Status_Message(byte* data,int dataLen);
        void SetStatus(byte status);
        void SetTime(UInt32 theTime);
        UInt32 GetTime();
        byte GetStatus();

        protected:
    UInt32 mTime;
};

class Controller_Message : public Message
{
    static const int BUTTONS_BYTE_LOC = 4;
    static const int BUTTONS_LENGTH = 4;
    static const int ANALOG_BYTE_LOC = BUTTONS_BYTE_LOC + BUTTONS_LENGTH;
    static const int ANALOG_LENGTH = 10;

public:
    Controller_Message();
    Controller_Message(byte* data, int dataLen);
    void SetAnalog(int analogNum, byte analogValue);
    byte GetAnalog(int analogNum);
    void SetButton(int buttonNum, bool value);
    bool GetButton(int buttonNum);
};

static class MessageFactory
{
    public:
        static Message* Build(byte* data, int dataLen);
};

#endif
