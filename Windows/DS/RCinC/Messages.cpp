#include <stdio.h>
#include <memory.h>
#include "Messages.hpp"
#include "Utils.h"

UInt16 Message::mNextSequence = 0;

Message::Message() :
mID(Message::MessageIDs::DS_STATUS),
mLength(0)
{

}

byte Message::GetFirstByte()
{
    byte id = (byte)mID;
    return (byte)(id * 16);
}

UInt16 Message::GetNextSequence()
{
    return mNextSequence;
}

Message::MessageIDs Message::GetMessageID()
{
    return (MessageIDs) mData[COMMAND_BYTE_LOC];
}

void Message::GetSendData(byte* returnBytes, int returnBytesLength)
{
    memcpy(returnBytes, mSendData, returnBytesLength);
}

void Message::RollSequenceNumber()
{
    mNextSequence++;
}

UInt16 Message::GetSequence()
{
    return GetIU16FrombyteArray(mData, SEQUENCE_BYTE_LOC);
}

void Message::SetSequence(UInt16 sequence)
{
    mNextSequence = sequence;
    PutIU16TobyteArray(sequence, mData, SEQUENCE_BYTE_LOC);
}

void Message::GetData(byte* returnBytes, int* returnBytesLength)
{
    PutIU16TobyteArray(mNextSequence, mData, SEQUENCE_BYTE_LOC);

    buildCheckByte();
    mSendDataLength = mLength;

    for (int index = COMMAND_BYTE_LOC; index < mLength + END_BYTE_LOC; index++)
    {
        switch (mData[index])
        {
            case (START_CHAR):
            case (END_CHAR):
            case (SPECIAL_CHAR):
                               mSendDataLength++;
                break;
        }
    }

    int location = 0;

    mSendData[location] = mData[START_BYTE_LOC];
    location++;

    for (int index = COMMAND_BYTE_LOC; index < mLength + END_BYTE_LOC; index++)
    {
        switch (mData[index])
        {
            case (START_CHAR):
                mSendData[location] = SPECIAL_CHAR;
                location++;
                mSendData[location] = NEW_START_CHAR;
                location++;
                break;
            case (END_CHAR):
                mSendData[location] = SPECIAL_CHAR;
                location++;
                mSendData[location] = NEW_END_CHAR;
                location++;
                break;
            case (SPECIAL_CHAR):
                mSendData[location] = SPECIAL_CHAR;
                location++;
                mSendData[location] = NEW_SPECIAL_CHAR;
                location++;
                break;
            default:
                mSendData[location] = mData[index];
                location++;
                break;
        }
    }

    mSendData[location] = mData[mLength + END_BYTE_LOC];
    location++;
    mSendData[location] = mData[mLength + CRC_BYTE_LOC];
    location++;

    memcpy(returnBytes, mSendData, mSendDataLength);
    *returnBytesLength = (int)mSendDataLength;
}

UInt32 Message::GetLength()
{
    return mLength;
}

void Message::buildCheckByte()
{
    mData[mLength + CRC_BYTE_LOC] = calcCheckByte();
}

byte Message::calcCheckByte()
{
    byte checkByte = 0xFF;

    for (int index = COMMAND_BYTE_LOC; index < mLength + CRC_BYTE_LOC; index++)
    {
        checkByte ^= mData[index];
    }
    return checkByte;
}

byte Message::getCheckByte()
{
    return mData[mLength + CRC_BYTE_LOC];
}


DS_Status_Message::DS_Status_Message():
mTime(0)
{
    mLength = 16;
    mID = MessageIDs::DS_STATUS;

    mData[START_BYTE_LOC] = START_CHAR;
    mData[COMMAND_BYTE_LOC] = (byte)mID;
    mData[mLength + END_BYTE_LOC] = END_CHAR;
}

DS_Status_Message::DS_Status_Message(byte* data, int dataLen):
mTime(0)
{
    mLength = 16;
    mID = Message::MessageIDs::DS_STATUS;

    if (mLength == dataLen)
    {
        for (int i = 0; i < mLength; i++)
        {
            mData[i] = data[i];
        }
    }

    mTime = GetU32FrombyteArray(mData, TIME_BYTE_LOC);
}

void DS_Status_Message::SetStatus(byte status)
{
    mData[DATA_BYTE_LOC] = status;
}

void DS_Status_Message::SetTime(UInt32 theTime)
{
    mTime = theTime;
    PutU32TobyteArray(mTime, mData, TIME_BYTE_LOC);
}

UInt32 DS_Status_Message::GetTime()
{
    return mTime;
}

byte DS_Status_Message::GetStatus()
{
    return mData[DATA_BYTE_LOC];
}

RC_Status_Message::RC_Status_Message():
mTime(0)
{
    mLength = 16;
    mID = MessageIDs::RC_STATUS;

    mData[START_BYTE_LOC] = START_CHAR;
    mData[COMMAND_BYTE_LOC] = (byte)mID;
    mData[mLength + END_BYTE_LOC] = END_CHAR;
}

RC_Status_Message::RC_Status_Message(byte* data, int dataLength):
mTime(0)
{
    mLength = 16;
    mID = MessageIDs::RC_STATUS;

    if (mLength == dataLength)
    {
        for (int i = 0; i < mLength; i++)
        {
            mData[i] = data[i];
        }
    }

    mTime = GetU32FrombyteArray(mData, TIME_BYTE_LOC);
}

void RC_Status_Message::SetStatus(byte status)
{
    mData[DATA_BYTE_LOC] = status;
}

void RC_Status_Message::SetTime(UInt32 theTime)
{
    mTime = theTime;
    PutU32TobyteArray(mTime, mData, TIME_BYTE_LOC);
}

UInt32 RC_Status_Message::GetTime()
{
    return mTime;
}

byte RC_Status_Message::GetStatus()
{
    return mData[DATA_BYTE_LOC];
}


Controller_Message::Controller_Message()
{
    mLength = 20;
    mID = MessageIDs::CONNTROLLER;

    mData[START_BYTE_LOC] = START_CHAR;
    mData[COMMAND_BYTE_LOC] = (byte)mID;
    mData[mLength + END_BYTE_LOC] = END_CHAR;
}

Controller_Message::Controller_Message(byte* data, int dataLength)
{
    mLength = 20;
    mID = MessageIDs::CONNTROLLER;

    if (mLength == dataLength)
    {
        for (int i = 0; i < mLength; i++)
        {
            mData[i] = data[i];
        }
    }
}

void Controller_Message::SetAnalog(int analogNum, byte analogValue)
{
    mData[ANALOG_BYTE_LOC + analogNum] = analogValue;
}

byte Controller_Message::GetAnalog(int analogNum)
{
    return mData[ANALOG_BYTE_LOC + analogNum];
}

void Controller_Message::SetButton(int buttonNum, bool value)
{
    UInt32 data = GetU32FrombyteArray(mData, BUTTONS_BYTE_LOC);
    SetAChunkOfU32(&data, (UInt32)(value ? 1 : 0), buttonNum, 1);
    PutU32TobyteArray(data, mData, BUTTONS_BYTE_LOC);
}

bool Controller_Message::GetButton(int buttonNum)
{
    UInt32 data = GetU32FrombyteArray(mData, BUTTONS_BYTE_LOC);
    UInt32 value = GetAChunkOfU32(data, buttonNum, 1);
    return (1 == value) ? true : false;
}

Message* MessageFactory::Build(byte* data, int dataLength)
{
    int realLength = dataLength;

    for (int index = Message::COMMAND_BYTE_LOC+1; index < dataLength + Message::END_BYTE_LOC; index++)
    {
        switch (data[index])
        {
        case (Message::SPECIAL_CHAR):
                realLength--;
                break;
        }
    }

    byte realData[Message::MAX_BUFFER];
    int location = 0;

    realData[location] = data[0];
    location++;

    for (int index = Message::COMMAND_BYTE_LOC; index < dataLength + Message::END_BYTE_LOC; index++)
    {
        switch (data[index])
        {
        case (Message::SPECIAL_CHAR):
                index++;
                switch (data[index])
                {
                    case (Message::NEW_START_CHAR):
                        realData[location] = Message::START_CHAR;
                        location++;
                        break;
                    case (Message::NEW_END_CHAR):
                        realData[location] = Message::END_CHAR;
                        location++;
                        break;
                    case (Message::NEW_SPECIAL_CHAR):
                        realData[location] = Message::SPECIAL_CHAR;
                        location++;
                        break;
                }
                break;
            default:
                realData[location] = data[index];
                location++;
                break;
        }
    }
    realData[location] = data[dataLength + Message::END_BYTE_LOC];
    location++;
    realData[location] = data[dataLength + Message::CRC_BYTE_LOC];
    location++;

    byte checkByte = 0xFF;

    for (int index = Message::COMMAND_BYTE_LOC; index < realLength + Message::CRC_BYTE_LOC; index++)
    {
        checkByte ^= realData[index];
    }

    if(checkByte == realData[realLength+Message::CRC_BYTE_LOC])
    {
        switch (realData[Message::COMMAND_BYTE_LOC])
        {
            case ((byte)Message::MessageIDs::DS_STATUS):
                return new DS_Status_Message(realData, realLength);
            case ((byte)Message::MessageIDs::RC_STATUS) :
                return new RC_Status_Message(realData, realLength);
            case ((byte)Message::MessageIDs::CONNTROLLER) :
                return new Controller_Message(realData, realLength);
        }
    }

    return NULL;
}


