using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTables
{
    public class NetTablesEntry
    {
        public enum MessageFlags
        {
            NOT_PERSISTENT = 0x00,
            PERSISTENT = 0x01,
            RESERVED = 0xFE
        };

        public enum EntryType
        {
            NONE = 0XFF,
            BOOLEAN = 0x00,
            DOUBLE = 0x01,
            STRING = 0x02,
            RAW_DATA = 0x03,
            BOOLEAN_ARRAY = 0x10,
            DOUBLE_ARRAY = 0x11,
            STRING_ARRAY = 0x12,
            RPC_DEFINITION = 0x20
        };

        static int mCurEntryID = 1;

        protected int mEntryID = 0;
        protected MessageFlags mEntryFlags = MessageFlags.NOT_PERSISTENT;
        protected EntryType mType = EntryType.NONE;
        protected int mSize = 1;
        protected byte[] mData = new byte[1];
        protected string mKey = "";

        public virtual byte[] GetBytes()
        {
            return mData;
        }

        protected virtual void AssignID()
        {
            mEntryID = mCurEntryID;
            mCurEntryID++;
        }

        public virtual int GetID()
        {
            return mEntryID;
        }

        public virtual void SetID(int id)
        {
            mEntryID = id;
        }

        public virtual EntryType GetTheType()
        {
            return mType;
        }

        public virtual void SetIDIntoArray(byte[] data, int loc)
        {
            data[loc] = (byte)((mEntryID >> 8) & 0xFF);
            data[loc+1] = (byte)(mEntryID & 0xFF);
        }

        public virtual string GetKey()
        {
            return mKey;
        }

        public virtual void SetKey(string key)
        {
            mKey = key;
        }

        public virtual void SetKey(NTString key)
        {
            mKey = key.ReturnString();
        }

        public virtual byte[] GetKeyAsBytes()
        {
            byte[] keyData = Encoding.UTF8.GetBytes(mKey);
            byte[] lengthBytes = EncodeLEB128((UInt32)keyData.Length);
            byte[] returnValue = new byte[keyData.Length + lengthBytes.Length];

            for (int i = 0; i < lengthBytes.Length; i++)
            {
                returnValue[i] = lengthBytes[i];
            }

            for (int i = 0; i < keyData.Length; i++)
            {
                returnValue[i+lengthBytes.Length] = keyData[i];
            }

            return returnValue;
        }


        public static byte[] EncodeLEB128(UInt32 value)
        {
            byte[] data = new byte[20];
            int len = 0;

            do {
              data[len] = (byte)(value&0x7F);
              value >>= 7;
              if (value != 0)
              {
                data[len] |= 0x80;
              }
              len++;
            } while (value != 0);

            byte[] returnValue = new byte[len];
            for(int i=0;i<len;i++)
            {
                returnValue[i] = data[i];
            }
            return returnValue;
        }

        public static UInt32 DecodeLEB128(byte[] data, int location, out int lengthOfNumber)
        {
            lengthOfNumber = 0;
            UInt32 returnValue = 0;
            int shift = 0;

            while(true) 
            {
                byte curByte = data[lengthOfNumber+location];
                lengthOfNumber++;

                returnValue |= (UInt32)((curByte&0x7F) << shift);
                if ((curByte&0x80) == 0)
                {
                    break;
                }
                shift += 7;
            }

            return returnValue;
        }
    }

    public class BooleanEntry : NetTablesEntry
    {
        public BooleanEntry()
        {
            AssignID();
            mType = EntryType.BOOLEAN;

            mSize = 1;
            mData = new byte[1];

            mData[0] = 0;
        }

        public BooleanEntry(bool data)
        {
            AssignID();
            mType = EntryType.BOOLEAN;

            if (true == data)
            {
                mData[0] = 1;
            }
            else
            {
                mData[0] = 0;
            }
        }

        public BooleanEntry(byte[] data)
        {
            AssignID();
            mType = EntryType.BOOLEAN;

            mData = data;
        }

        public BooleanEntry(byte[] data, int location)
        {
            AssignID();
            mType = EntryType.BOOLEAN;

            mData[0] = data[location];
        }

        public bool ReturnBool()
        {
            if(0 == mData[0])
            {
                return false;
            }
            return true;
        }

        public void Update(byte[] data, int location)
        {
            mData[0] = data[location];
        }
    }

    public class DoubleEntry : NetTablesEntry
    {
        public DoubleEntry()
        {
            AssignID();

            mType = EntryType.DOUBLE;
            mSize = 8;
            mData = new byte[mSize];

            for (int i = 0; i < 8;i++)
            {
                mData[i] = 0;
            }
        }

        public DoubleEntry(double value)
        {
            AssignID();

            mType = EntryType.DOUBLE;
            mData = BitConverter.GetBytes(value);
            mSize = mData.Length;
        }

        public DoubleEntry(byte[] data)
        {
            AssignID();

            mSize = 8;
            mData = data;
        }

        public DoubleEntry(byte[] data, int location)
        {
            AssignID();
            mType = EntryType.DOUBLE;
            mSize = 8;
            mData = new byte[mSize];

            for (int i = 0; i < 8;i++)
            {
                mData[7-i] = data[i+location];
            }
        }

        public void Update(byte[] data, int location)
        {
            for (int i = 0; i < 8; i++)
            {
                mData[7 - i] = data[i + location];
            }
        }

        public double ReturnDouble()
        {
            return BitConverter.ToDouble(mData, 0);
        }
    }

    public class StringEntry : NetTablesEntry
    {
        NTString mString = new NTString();

        public StringEntry()
        {
            AssignID();
            mType = EntryType.STRING;
        }

        public StringEntry(string value)
        {
            AssignID();
            mType = EntryType.STRING;
            mString = new NTString(value);
        }

        public StringEntry(NTString aString)
        {
            AssignID();
            mType = EntryType.STRING;
            mString = aString;
        }

        public string ReturnString()
        {
            return mString.ReturnString();
        }

        public void Update(NTString aString)
        {
            mString = aString;
        }

        public override byte[] GetBytes()
        {
            return mString.GetBytes();
        }
    }

    public class RawDataEntry : NetTablesEntry
    {
        public RawDataEntry()
        {
            AssignID();

            mType = EntryType.RAW_DATA;
            mSize = 0;
            mData = new byte[mSize];
        }

        public RawDataEntry(byte[] value)
        {
            AssignID();

            mType = EntryType.RAW_DATA;
            mData = value;
            mSize = mData.Length;
        }

        byte[] ReturnString()
        {
            return mData;
        }

        public override byte[] GetBytes()
        {
            byte[] lengthBytes = EncodeLEB128((UInt32)mSize);
            
            byte[] returnValue = new byte[lengthBytes.Length+mSize];

            for(int i=0;i<lengthBytes.Length;i++)
            {
                returnValue[i] = lengthBytes[i];
            }

            for(int i=0;i<mSize;i++)
            {
                returnValue[lengthBytes.Length+i] = mData[i];
            }

            return returnValue;
        }
    }

    public class BooleanArrayEntry : NetTablesEntry
    {

    }

    public class DoubleArrayEntry : NetTablesEntry
    {

    }

    public class StringArrayEntry : NetTablesEntry
    {

    }

    public class RPCDefinitionEntry : NetTablesEntry
    {

    }

    public class NTString
    {
        int mSize=0;
        byte[] mData = new byte[0];

        public NTString()
        {
            mSize = 0;
            mData = new byte[mSize];
        }

        public NTString(string value)
        {
            mData = Encoding.UTF8.GetBytes(value);
            mSize = mData.Length;
        }

        public NTString(byte[] data, int location,out int bytesLength)
        {
            int stringBytesLength = 0;
            mSize = (int)NetTablesEntry.DecodeLEB128(data, location, out stringBytesLength);
            bytesLength = stringBytesLength+mSize;
            mData = new byte[mSize];

            for(int i=0;i<mSize;i++)
            {
                mData[i] = data[i + location + stringBytesLength];
            }

        }

        public string ReturnString()
        {
            return Encoding.UTF8.GetString(mData);
        }

        public byte[] GetBytes()
        {
            byte[] lengthBytes = NetTablesEntry.EncodeLEB128((UInt32)mSize);

            byte[] returnValue = new byte[lengthBytes.Length + mSize];

            for (int i = 0; i < lengthBytes.Length; i++)
            {
                returnValue[i] = lengthBytes[i];
            }

            for (int i = 0; i < mSize; i++)
            {
                returnValue[lengthBytes.Length + i] = mData[i];
            }

            return returnValue;
        }
    }
}
