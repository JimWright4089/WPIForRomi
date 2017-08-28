using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

using NetTables;

namespace NetTablesTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void BooleanEntryTest()
        {
            BooleanEntry boolEntry = new BooleanEntry();
            byte[] data = boolEntry.GetBytes();

            Assert.AreEqual(data.Length, 1, "The bool Entry Length is wrong");
            Assert.AreEqual(data[0], 0x00, "The bool Entry is wrong");
            Assert.AreEqual(boolEntry.GetID(), 1, "The bool Entry is wrong");
            Assert.AreEqual(boolEntry.GetTheType(), NetTablesEntry.EntryType.BOOLEAN, "The bool Entry is wrong");

            boolEntry = new BooleanEntry(true);
            data = boolEntry.GetBytes();
            byte[] idData = new byte[2];
            boolEntry.SetIDIntoArray(idData, 0);

            Assert.AreEqual(data.Length, 1, "The bool Entry Length is wrong");
            Assert.AreEqual(data[0], 0x01, "The bool Entry is wrong");
            Assert.AreEqual(boolEntry.ReturnBool(), true, "The bool Entry is wrong");
            Assert.AreEqual(boolEntry.GetID(), 2, "The bool Entry is wrong");
            Assert.AreEqual(idData[0], 0, "The bool Entry is wrong");
            Assert.AreEqual(idData[1], 2, "The bool Entry is wrong");

            boolEntry = new BooleanEntry(false);
            data = boolEntry.GetBytes();

            Assert.AreEqual(data.Length, 1, "The bool Entry Length is wrong");
            Assert.AreEqual(data[0], 0x00, "The bool Entry is wrong");
            Assert.AreEqual(boolEntry.ReturnBool(), false, "The bool Entry is wrong");
            Assert.AreEqual(boolEntry.GetID(), 3, "The bool Entry is wrong");
        }

        [TestMethod]
        public void DoubleEntryTest()
        {
            DoubleEntry doubleEntry = new DoubleEntry();
            byte[] data = doubleEntry.GetBytes();
            doubleEntry.SetKey("/double");
            byte[] keyData = doubleEntry.GetKeyAsBytes();

            Assert.AreEqual(data.Length, 8, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 0x00, "The Entry is wrong");
            Assert.AreEqual(doubleEntry.GetTheType(), NetTablesEntry.EntryType.DOUBLE, "The bool Entry is wrong");
            Assert.AreEqual(doubleEntry.GetKey(), "/double", "The bool Entry is wrong");
            Assert.AreEqual(keyData[0], 7, "The bool Entry is wrong");
            Assert.AreEqual(keyData[1], 47, "The bool Entry is wrong");
            Assert.AreEqual(keyData[2], 100, "The bool Entry is wrong");
            Assert.AreEqual(keyData[3], 111, "The bool Entry is wrong");
            Assert.AreEqual(keyData[4], 117, "The bool Entry is wrong");
            Assert.AreEqual(keyData[5], 98, "The bool Entry is wrong");
            Assert.AreEqual(keyData[6], 108, "The bool Entry is wrong");
            Assert.AreEqual(keyData[7], 101, "The bool Entry is wrong");

            doubleEntry = new DoubleEntry(0.0);
            data = doubleEntry.GetBytes();

            Assert.AreEqual(data.Length, 8, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 0x00, "The Entry is wrong");
            Assert.AreEqual(doubleEntry.ReturnDouble(), 0.0, "The Entry is wrong");

            doubleEntry = new DoubleEntry(1.0);
            data = doubleEntry.GetBytes();

            Assert.AreEqual(data.Length, 8, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 0x00, "The Entry is wrong");
            Assert.AreEqual(data[6], 240, "The Entry is wrong");
            Assert.AreEqual(data[7], 63, "The Entry is wrong");
            Assert.AreEqual(doubleEntry.ReturnDouble(), 1.0, "The Entry is wrong");

            doubleEntry = new DoubleEntry(-1.0);
            data = doubleEntry.GetBytes();

            Assert.AreEqual(data.Length, 8, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 0x00, "The Entry is wrong");
            Assert.AreEqual(data[6], 240, "The Entry is wrong");
            Assert.AreEqual(data[7], 191, "The Entry is wrong");
            Assert.AreEqual(doubleEntry.ReturnDouble(), -1.0, "The Entry is wrong");

            doubleEntry = new DoubleEntry(1.1);
            data = doubleEntry.GetBytes();

            Assert.AreEqual(data.Length, 8, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 154, "The Entry is wrong");
            Assert.AreEqual(data[1], 153, "The Entry is wrong");
            Assert.AreEqual(data[2], 153, "The Entry is wrong");
            Assert.AreEqual(data[3], 153, "The Entry is wrong");
            Assert.AreEqual(data[4], 153, "The Entry is wrong");
            Assert.AreEqual(data[5], 153, "The Entry is wrong");
            Assert.AreEqual(data[6], 241, "The Entry is wrong");
            Assert.AreEqual(data[7], 63, "The Entry is wrong");
            Assert.AreEqual(doubleEntry.ReturnDouble(), 1.1, "The Entry is wrong");

            doubleEntry = new DoubleEntry(-1.1);
            data = doubleEntry.GetBytes();

            Assert.AreEqual(data.Length, 8, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 154, "The Entry is wrong");
            Assert.AreEqual(data[1], 153, "The Entry is wrong");
            Assert.AreEqual(data[2], 153, "The Entry is wrong");
            Assert.AreEqual(data[3], 153, "The Entry is wrong");
            Assert.AreEqual(data[4], 153, "The Entry is wrong");
            Assert.AreEqual(data[5], 153, "The Entry is wrong");
            Assert.AreEqual(data[6], 241, "The Entry is wrong");
            Assert.AreEqual(data[7], 191, "The Entry is wrong");
            Assert.AreEqual(doubleEntry.ReturnDouble(), -1.1, "The Entry is wrong");

            doubleEntry = new DoubleEntry(double.MaxValue);
            data = doubleEntry.GetBytes();

            Assert.AreEqual(data.Length, 8, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 255, "The Entry is wrong");
            Assert.AreEqual(data[1], 255, "The Entry is wrong");
            Assert.AreEqual(data[2], 255, "The Entry is wrong");
            Assert.AreEqual(data[3], 255, "The Entry is wrong");
            Assert.AreEqual(data[4], 255, "The Entry is wrong");
            Assert.AreEqual(data[5], 255, "The Entry is wrong");
            Assert.AreEqual(data[6], 239, "The Entry is wrong");
            Assert.AreEqual(data[7], 127, "The Entry is wrong");
            Assert.AreEqual(doubleEntry.ReturnDouble(), double.MaxValue, "The Entry is wrong");

            doubleEntry = new DoubleEntry(double.MinValue);
            data = doubleEntry.GetBytes();

            Assert.AreEqual(data.Length, 8, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 255, "The Entry is wrong");
            Assert.AreEqual(data[1], 255, "The Entry is wrong");
            Assert.AreEqual(data[2], 255, "The Entry is wrong");
            Assert.AreEqual(data[3], 255, "The Entry is wrong");
            Assert.AreEqual(data[4], 255, "The Entry is wrong");
            Assert.AreEqual(data[5], 255, "The Entry is wrong");
            Assert.AreEqual(data[6], 239, "The Entry is wrong");
            Assert.AreEqual(data[7], 255, "The Entry is wrong");
            Assert.AreEqual(doubleEntry.ReturnDouble(), double.MinValue, "The Entry is wrong");

            data[0] = 12;
            doubleEntry = new DoubleEntry(data);
            Assert.AreEqual(doubleEntry.ReturnDouble(), -1.7976931348622672E+308, "The Entry is wrong");

            data[0] = 0;
            data[1] = 0;
            data[2] = 0;
            data[3] = 0;
            data[4] = 0;
            data[5] = 0;
            data[6] = 230;
            data[7] = 63;
            doubleEntry = new DoubleEntry(data);
            Assert.AreEqual(doubleEntry.ReturnDouble(), 0.6875, "The Entry is wrong");
        }

        [TestMethod]
        public void StringEntryTest()
        {
            StringEntry stringEntry = new StringEntry();
            byte[] data = stringEntry.GetBytes();
            stringEntry.SetKey("/ФдЩЩ");
            byte[] keyData = stringEntry.GetKeyAsBytes();

            Assert.AreEqual(data.Length, 1, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 0, "The Entry Length is wrong");
            Assert.AreEqual(stringEntry.GetTheType(), NetTablesEntry.EntryType.STRING, "The bool Entry is wrong");
            Assert.AreEqual(stringEntry.GetKey(), "/ФдЩЩ", "The bool Entry is wrong");
            Assert.AreEqual(keyData[0], 9, "The bool Entry is wrong");
            Assert.AreEqual(keyData[1], 47, "The bool Entry is wrong");
            Assert.AreEqual(keyData[2], 208,  "The bool Entry is wrong");
            Assert.AreEqual(keyData[3], 164, "The bool Entry is wrong");
            Assert.AreEqual(keyData[4], 208, "The bool Entry is wrong");
            Assert.AreEqual(keyData[5], 180, "The bool Entry is wrong");
            Assert.AreEqual(keyData[6], 208, "The bool Entry is wrong");
            Assert.AreEqual(keyData[7], 169, "The bool Entry is wrong");
            Assert.AreEqual(keyData[8], 208, "The bool Entry is wrong");
            Assert.AreEqual(keyData[9], 169, "The bool Entry is wrong");

            stringEntry = new StringEntry("Hi There");
            data = stringEntry.GetBytes();

            Assert.AreEqual(data.Length, 9, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 8, "The Entry Length is wrong");
            Assert.AreEqual(data[1], 72, "The Entry Length is wrong");
            Assert.AreEqual(data[7], 114, "The Entry Length is wrong");
            Assert.AreEqual(data[8], 101, "The Entry Length is wrong");
            Assert.AreEqual(stringEntry.ReturnString(), "Hi There", "The Entry is wrong");

            stringEntry = new StringEntry("杆癎碣ФдЩЩ There");
            data = stringEntry.GetBytes();

            Assert.AreEqual(data.Length, 24, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 23, "The Entry Length is wrong");
            Assert.AreEqual(data[1], 230, "The Entry Length is wrong");
            Assert.AreEqual(data[10], 208, "The Entry Length is wrong");
            Assert.AreEqual(data[11], 164, "The Entry Length is wrong");
            Assert.AreEqual(data[22], 114, "The Entry Length is wrong");
            Assert.AreEqual(data[23], 101, "The Entry Length is wrong");
            Assert.AreEqual(stringEntry.ReturnString(), "杆癎碣ФдЩЩ There", "The Entry is wrong");

            stringEntry = new StringEntry("杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890");
            data = stringEntry.GetBytes();

            Assert.AreEqual(data.Length, 2688, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 254, "The Entry Length is wrong");
            Assert.AreEqual(data[1], 20, "The Entry Length is wrong");
            Assert.AreEqual(data[2], 230, "The Entry Length is wrong");
            Assert.AreEqual(data[3], 157, "The Entry Length is wrong");
            Assert.AreEqual(data[4], 134, "The Entry Length is wrong");
            Assert.AreEqual(data[9], 162, "The Entry Length is wrong");
            Assert.AreEqual(data[10], 163, "The Entry Length is wrong");
            Assert.AreEqual(stringEntry.ReturnString(), "杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890杆癎碣ФдЩЩ There 1234567890", "The Entry is wrong");
        }

        [TestMethod]
        public void ServerHelloMessageTest()
        {
            ServerHelloMessage serverHello = new ServerHelloMessage();
            byte[] data = serverHello.GetBytes();

            Assert.AreEqual(serverHello.GetLength(), 3, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 4, "The Entry Length is wrong");
            Assert.AreEqual(data[1], 0, "The Entry Length is wrong");
            Assert.AreEqual(data[2], 0, "The Entry Length is wrong");
        }

        [TestMethod]
        public void ServerHelloCompleteMessageTest()
        {
            ServerHelloCompleteMessage serverHello = new ServerHelloCompleteMessage();
            byte[] data = serverHello.GetBytes();

            Assert.AreEqual(serverHello.GetLength(), 1, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 3, "The Entry Length is wrong");
        }

        [TestMethod]
        public void KeepAliveMessageTest()
        {
            KeepAliveMessage keepAlive = new KeepAliveMessage();
            byte[] data = keepAlive.GetBytes();

            Assert.AreEqual(keepAlive.GetLength(), 1, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 0, "The Entry Length is wrong");
        }

        [TestMethod]
        public void ClientHelloMessageTest()
        {
            ClientHelloMessage clientHello = new ClientHelloMessage();
            byte[] data = clientHello.GetBytes();

            Assert.AreEqual(clientHello.GetLength(), 4, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 1, "The Entry Length is wrong");
            Assert.AreEqual(data[1], 3, "The Entry Length is wrong");
            Assert.AreEqual(data[2], 0, "The Entry Length is wrong");
            Assert.AreEqual(data[3], 0, "The Entry Length is wrong");
        }

        [TestMethod]
        public void ProtocolVersionUnsupportedMessageTest()
        {
            ProtocolVersionUnsupportedMessage clientHello = new ProtocolVersionUnsupportedMessage();
            byte[] data = clientHello.GetBytes();

            Assert.AreEqual(clientHello.GetLength(), 3, "The Entry Length is wrong");
            Assert.AreEqual(data[0], 2, "The Entry Length is wrong");
            Assert.AreEqual(data[1], 3, "The Entry Length is wrong");
            Assert.AreEqual(data[2], 0, "The Entry Length is wrong");
        }

        [TestMethod]
        public void ClientStartTest()
        {
            NetTables.NetTables newClient = new NetTables.NetTables();
            newClient.StartClient("127.0.0.1", 10000);
            Thread.Sleep(1000);
            //while (true) ;
            newClient.Stop();

            Assert.AreEqual(newClient.GetNumberOfEntries(), 12, "The Entry Length is wrong");

            NetTablesEntry entry = newClient.GetEntry("/bad");
            Assert.AreEqual(entry.GetTheType(), NetTablesEntry.EntryType.NONE, "The Entry Length is wrong");

            entry = newClient.GetEntry("/zero");
            Assert.AreEqual(entry.GetTheType(), NetTablesEntry.EntryType.DOUBLE, "The Entry Length is wrong");
            DoubleEntry doubleEntry = (DoubleEntry)entry;
            Assert.AreEqual(doubleEntry.ReturnDouble(), 0, "The Entry Length is wrong");

            entry = newClient.GetEntry("/one");
            Assert.AreEqual(entry.GetTheType(), NetTablesEntry.EntryType.DOUBLE, "The Entry Length is wrong");
            doubleEntry = (DoubleEntry)entry;
            Assert.AreEqual(doubleEntry.ReturnDouble(), 1.0, "The Entry Length is wrong");

            entry = newClient.GetEntry("/minusone");
            Assert.AreEqual(entry.GetTheType(), NetTablesEntry.EntryType.DOUBLE, "The Entry Length is wrong");
            doubleEntry = (DoubleEntry)entry;
            Assert.AreEqual(doubleEntry.ReturnDouble(), -1.0, "The Entry Length is wrong");

            entry = newClient.GetEntry("/fourtyThree");
            Assert.AreEqual(entry.GetTheType(), NetTablesEntry.EntryType.DOUBLE, "The Entry Length is wrong");
            doubleEntry = (DoubleEntry)entry;
            Assert.AreEqual(doubleEntry.ReturnDouble(), 43.43, "The Entry Length is wrong");

            entry = newClient.GetEntry("/string");
            Assert.AreEqual(entry.GetTheType(), NetTablesEntry.EntryType.STRING, "The Entry Length is wrong");
        }

        [TestMethod]
        public void GetEntryTest()
        {
            NetTables.NetTables newClient = new NetTables.NetTables();
            newClient.StartClient("127.0.0.1", 10000);

            NetTablesEntry entry = newClient.GetEntry("/double");
            Assert.AreEqual(entry.GetTheType(), NetTablesEntry.EntryType.DOUBLE, "The Entry Length is wrong");
            DoubleEntry doubleEntry = (DoubleEntry)entry;
            double theDouble = doubleEntry.ReturnDouble();
            Thread.Sleep(1000);
            Assert.AreNotEqual(theDouble, doubleEntry.ReturnDouble());
            //while (true) ;
            newClient.Stop();
        }
    
    }
}
