using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiMessage
{
    public class Message
    {
        public enum MessageIDs
        {
            Reserved1 = 0,
            DS_STATUS = 1,
            RC_STATUS = 2,
            CONNTROLLER = 3,
        };

        private static UInt16 mNextSequence = 0;

        public const int START_BYTE_LOC = 0;
        public const int COMMAND_BYTE_LOC = 1;
        public const int SEQUENCE_BYTE_LOC = 2;
        public const int DATA_BYTE_LOC = 4;
        public const int END_BYTE_LOC = -2;
        public const int CRC_BYTE_LOC = -1;

        public const byte START_CHAR = 0xA0;
        public const byte END_CHAR = 0xA1;
        public const byte SPECIAL_CHAR = 0xA2;
        public const byte NEW_START_CHAR = 0xB0;
        public const byte NEW_END_CHAR = 0xB1;
        public const byte NEW_SPECIAL_CHAR = 0xB2;

        protected MessageIDs mID = MessageIDs.DS_STATUS;
        protected UInt32 mLength = 0;
        protected byte[] mData;
        protected byte[] mSendData;

        protected byte GetFirstByte()
        {
            byte id = (byte)mID;
            return (byte)(id * 16);
        }

        public UInt16 GetNextSequence()
        {
            return mNextSequence;
        }

        public MessageIDs GetMessageID()
        {
            return (MessageIDs) mData[COMMAND_BYTE_LOC];
        }

        public byte[] GetSendData()
        {
            return mSendData;
        }

        public void RollSequenceNumber()
        {
            mNextSequence++;
        }

        public UInt16 GetSequence()
        {
            return BitConverter.ToUInt16(mData, SEQUENCE_BYTE_LOC);
        }

        public void SetSequence(UInt16 sequence)
        {
            mNextSequence = sequence;
            byte[] sequnceBytes = BitConverter.GetBytes(sequence);

            mData[SEQUENCE_BYTE_LOC] = sequnceBytes[0];
            mData[SEQUENCE_BYTE_LOC + 1] = sequnceBytes[1];
        }

        public byte[] GetData()
        {
            byte[] sequnceBytes = BitConverter.GetBytes(mNextSequence);

            mData[SEQUENCE_BYTE_LOC] = sequnceBytes[0];
            mData[SEQUENCE_BYTE_LOC + 1] = sequnceBytes[1];

            buildCheckByte();
            UInt32 returnLength = mLength;

            for (int index = COMMAND_BYTE_LOC; index < mLength + END_BYTE_LOC; index++)
            {
                switch (mData[index])
                {
                    case (START_CHAR):
                    case (END_CHAR):
                    case (SPECIAL_CHAR):
                        returnLength++;
                        break;
                }
            }

            mSendData = new byte[returnLength];
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

            return mSendData;
        }

        public UInt32 GetLength()
        {
            return mLength;
        }

        public void buildCheckByte()
        {
            mData[mLength + CRC_BYTE_LOC] = calcCheckByte();
        }

        public byte calcCheckByte()
        {
            byte checkByte = 0xFF;

            for (int index = COMMAND_BYTE_LOC; index < mLength + CRC_BYTE_LOC; index++)
            {
                checkByte ^= mData[index];
            }
            return checkByte;
        }

        public byte getCheckByte()
        {
            return mData[mLength + CRC_BYTE_LOC];
        }
    }

    public class DS_Status_Message : Message
    {
        public const int STATUS_BYTE_LOC = 4;
        public const int TIME_BYTE_LOC = 10;
        protected UInt32 mTime = 0;

        public DS_Status_Message()
        {
            mLength = 16;
            mData = new byte[mLength];
            mID = MessageIDs.DS_STATUS;

            mData[START_BYTE_LOC] = START_CHAR;
            mData[COMMAND_BYTE_LOC] = (byte)mID;
            mData[mLength + END_BYTE_LOC] = END_CHAR;
        }

        public DS_Status_Message(byte[] data)
        {
            mLength = 16;
            mData = new byte[mLength];
            mID = MessageIDs.DS_STATUS;

            if(mLength == data.Length)
            {
                for (int i = 0; i < mLength; i++)
                {
                    mData[i] = data[i];
                }
            }

            mTime = BitConverter.ToUInt32(mData, TIME_BYTE_LOC);
        }

        public void SetStatus(byte status)
        {
            mData[DATA_BYTE_LOC] = status;
        }

        public void SetTime(UInt32 theTime)
        {
            mTime = theTime;
            byte[] timeData = BitConverter.GetBytes(theTime);

            mData[TIME_BYTE_LOC + 3] = timeData[0];
            mData[TIME_BYTE_LOC + 2] = timeData[1];
            mData[TIME_BYTE_LOC + 1] = timeData[2];
            mData[TIME_BYTE_LOC + 0] = timeData[3];
        }

        public UInt32 GetTime()
        {
            return mTime;
        }

        public byte GetStatus()
        {
            return mData[DATA_BYTE_LOC];
        }
    }

    public class RC_Status_Message : Message
    {
        public const int STATUS_BYTE_LOC = 4;
        public const int TIME_BYTE_LOC = 10;
        protected UInt32 mTime = 0;

        public RC_Status_Message()
        {
            mLength = 16;
            mData = new byte[mLength];
            mID = MessageIDs.RC_STATUS;

            mData[START_BYTE_LOC] = START_CHAR;
            mData[COMMAND_BYTE_LOC] = (byte)mID;
            mData[mLength + END_BYTE_LOC] = END_CHAR;
        }

        public RC_Status_Message(byte[] data)
        {
            mLength = 16;
            mData = new byte[mLength];
            mID = MessageIDs.RC_STATUS;

            if (mLength == data.Length)
            {
                for (int i = 0; i < mLength; i++)
                {
                    mData[i] = data[i];
                }
            }

            mTime = BitConverter.ToUInt32(mData, TIME_BYTE_LOC);
        }

        public void SetStatus(byte status)
        {
            mData[DATA_BYTE_LOC] = status;
        }

        public void SetTime(UInt32 theTime)
        {
            mTime = theTime;
            byte[] timeData = BitConverter.GetBytes(theTime);

            mData[TIME_BYTE_LOC] = timeData[0];
            mData[TIME_BYTE_LOC + 1] = timeData[1];
            mData[TIME_BYTE_LOC + 2] = timeData[2];
            mData[TIME_BYTE_LOC + 3] = timeData[3];
        }

        public UInt32 GetTime()
        {
            return mTime;
        }

        public byte GetStatus()
        {
            return mData[DATA_BYTE_LOC];
        }
    }


    public class Controller_Message : Message
    {
        public const int NUMBER_BYTE_LOC = 4;
        public const int NUMBER_LENGTH = 1;
        public const int BUTTONS_BYTE_LOC = 5;
        public const int BUTTONS_LENGTH = 4;
        public const int ANALOG_BYTE_LOC = BUTTONS_BYTE_LOC+BUTTONS_LENGTH;
        public const int ANALOG_LENGTH = 20;

        public Controller_Message()
        {
            mLength = 31;
            mData = new byte[mLength];
            mID = MessageIDs.CONNTROLLER;

            mData[START_BYTE_LOC] = START_CHAR;
            mData[COMMAND_BYTE_LOC] = (byte)mID;
            mData[mLength + END_BYTE_LOC] = END_CHAR;
        }

        public Controller_Message(byte[] data)
        {
            mLength = 31;
            mData = new byte[mLength];
            mID = MessageIDs.CONNTROLLER;

            if (mLength == data.Length)
            {
                for (int i = 0; i < mLength; i++)
                {
                    mData[i] = data[i];
                }
            }
        }

        public void SetNumber(byte number)
        {
            mData[NUMBER_BYTE_LOC] = number;
        }

        public byte GetNumber()
        {
            return mData[NUMBER_BYTE_LOC];
        }

        public void SetAnalog(int analogNum, short analogValue)
        {
            PutU16TobyteArray((UInt16)analogValue, mData, ANALOG_BYTE_LOC + (analogNum * 2));
        }

        public short GetAnalog(int analogNum)
        {
            return (short)GetU16FrombyteArray(mData, ANALOG_BYTE_LOC + (analogNum * 2));
        }

        public void SetButton(int buttonNum, bool value)
        {
            UInt32 data = GetU32FrombyteArray(mData, BUTTONS_BYTE_LOC);
            SetAChunkOfU32(ref data, (UInt32)(value ? 1 : 0), buttonNum, 1);
            PutU32TobyteArray(data, mData, BUTTONS_BYTE_LOC);
        }

        public bool GetButton(int buttonNum)
        {
            UInt32 data = GetU32FrombyteArray(mData, BUTTONS_BYTE_LOC);
            UInt32 value = GetAChunkOfU32(data, buttonNum, 1);
            return (1 == value) ? true : false;
        }

        ///--------------------------------------------------------------------
        /// Purpose:
        /// <summary>
        ///     Get a u32 from an array of bytes
        /// </summary>
        /// 
        /// Returns:
        /// <returns>
        /// UInt32 - The number
        /// </returns>
        /// 
        /// Notes:
        /// <remarks>
        ///     None.
        /// </remarks>
        ///--------------------------------------------------------------------
        public static UInt32 GetU32FrombyteArray(byte[] data, int location)
        {
            return (UInt32)((data[location] << 24) +
                (data[location + 1] << 16) +
                (data[location + 2] << 8) +
                data[location + 3]);
        }

        ///--------------------------------------------------------------------
        /// Purpose:
        /// <summary>
        ///     Put a long into a data buffer
        /// </summary>
        /// 
        /// Returns:
        /// <returns>
        /// </returns>
        /// 
        /// Notes:
        /// <remarks>
        ///     None.
        /// </remarks>
        ///--------------------------------------------------------------------
        public static void PutU32TobyteArray(UInt32 number, byte[] data, int location)
        {
            data[location] = (byte)((number >> 24) & 0xFF);
            data[location + 1] = (byte)((number >> 16) & 0xFF);
            data[location + 2] = (byte)((number >> 8) & 0xFF);
            data[location + 3] = (byte)(number & 0xFF);
        }

        ///--------------------------------------------------------------------
        /// Purpose:
        /// <summary>
        ///     Get a u32 from an array of bytes
        /// </summary>
        /// 
        /// Returns:
        /// <returns>
        /// UInt32 - The number
        /// </returns>
        /// 
        /// Notes:
        /// <remarks>
        ///     None.
        /// </remarks>
        ///--------------------------------------------------------------------
        public static UInt16 GetU16FrombyteArray(byte[] data, int location)
        {
            return (UInt16)((data[location] << 8) +
                data[location + 1]);
        }

        ///--------------------------------------------------------------------
        /// Purpose:
        /// <summary>
        ///     Put a long into a data buffer
        /// </summary>
        /// 
        /// Returns:
        /// <returns>
        /// </returns>
        /// 
        /// Notes:
        /// <remarks>
        ///     None.
        /// </remarks>
        ///--------------------------------------------------------------------
        public static void PutU16TobyteArray(UInt16 number, byte[] data, int location)
        {
            data[location] = (byte)((number >> 8) & 0xFF);
            data[location + 1] = (byte)((number) & 0xFF);
        }

        ///--------------------------------------------------------------------
        /// Purpose:
        /// <summary>
        ///     Sets the chunk of the data field of the data packet
        /// </summary>
        /// 
        /// Returns:
        /// <returns>
        ///     Return the int32
        /// </returns>
        /// 
        /// Notes:
        /// <remarks>
        ///     None.
        /// </remarks>
        ///--------------------------------------------------------------------
        public static void SetAChunkOfU32(ref UInt32 dataToSave, UInt32 dataToSet, int location, int size)
        {
            UInt32 newSetMask = (UInt32)((1 << size) - 1);
            newSetMask <<= location;

            UInt32 newClearMask = ~newSetMask;

            UInt32 newData = dataToSet << location;
            newData &= newSetMask;

            dataToSave &= newClearMask;
            dataToSave |= newData;
        }

        ///--------------------------------------------------------------------
        /// Purpose:
        /// <summary>
        ///     Gets the chunk of the data field of the data packet
        /// </summary>
        /// 
        /// Returns:
        /// <returns>
        ///     The block from the UInt32
        /// </returns>
        /// 
        /// Notes:
        /// <remarks>
        ///     None.
        /// </remarks>
        ///--------------------------------------------------------------------
        public static UInt32 GetAChunkOfU32(UInt32 data, int location, int size)
        {
            int newRollRightValue = (location);

            UInt32 newClearMask = (UInt32)((1 << size) - 1);

            return ((data >> newRollRightValue) & newClearMask);
        }
    }


    public static class MessageFactory
    {
        public static Message Build(byte[] data)
        {
            int realLength = data.Length;

            for (int index = Message.COMMAND_BYTE_LOC; index < data.Length + Message.END_BYTE_LOC; index++)
            {
                switch (data[index])
                {
                    case (Message.SPECIAL_CHAR):
                        realLength--;
                        break;
                }
            }

            byte[] realData = new byte[realLength];
            int location = 0;

            realData[location] = data[0];
            location++;

            for (int index = Message.COMMAND_BYTE_LOC; index < data.Length + Message.END_BYTE_LOC; index++)
            {
                switch (data[index])
                {
                    case (Message.SPECIAL_CHAR):
                        index++;
                        switch (data[index])
                        {
                            case (Message.NEW_START_CHAR):
                                realData[location] = Message.START_CHAR;
                                location++;
                                break;
                            case (Message.NEW_END_CHAR):
                                realData[location] = Message.END_CHAR;
                                location++;
                                break;
                            case (Message.NEW_SPECIAL_CHAR):
                                realData[location] = Message.SPECIAL_CHAR;
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
            realData[location] = data[data.Length + Message.END_BYTE_LOC];
            location++;
            realData[location] = data[data.Length + Message.CRC_BYTE_LOC];
            location++;

            byte checkByte = 0xFF;

            for (int index = Message.COMMAND_BYTE_LOC; index < realLength + Message.CRC_BYTE_LOC; index++)
            {
                checkByte ^= realData[index];
            }

            if(checkByte == realData[realLength+Message.CRC_BYTE_LOC])
            {
                switch (realData[Message.COMMAND_BYTE_LOC])
                {
                    case ((byte)Message.MessageIDs.DS_STATUS):
                        return new DS_Status_Message(realData);
                    case ((byte)Message.MessageIDs.RC_STATUS):
                        return new RC_Status_Message(realData);
                    case ((byte)Message.MessageIDs.CONNTROLLER):
                        break;
                }
            }

            return null;
        }
    }

}
