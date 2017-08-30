//----------------------------------------------------------------------------
//
//  $Workfile: ConfigureFile.cs$
//
//  $Revision: X$
//
//  Project:    Networktables C#
//
//                            Copyright (c) 2017
//                               James A Wright
//                            All Rights Reserved
//
//  Modification History:
//  $Log:
//  $
//
//----------------------------------------------------------------------------
using System.Xml;

namespace NetworkTablesInterface
{
    //----------------------------------------------------------------------------
    //  Class Declarations
    //----------------------------------------------------------------------------
    //
    // Class Name: ConfigureFile
    // 
    // Purpose:
    //      This class loads in the config XML File
    //
    //----------------------------------------------------------------------------
    public class ConfigureFile
    {
        //----------------------------------------------------------------------------
        //  Class Constants 
        //----------------------------------------------------------------------------
        const string SETTINGS_TAG = "Settings";
        const string IPADDRESS_TAG = "IPAddress";
        const string PORT_TAG = "Port";
        const string SETTING_FILE = "NetworkTablesSettings.xml";

        //----------------------------------------------------------------------------
        //  Class Attributes 
        //----------------------------------------------------------------------------
        public string mIPAddress = "127.0.0.1";
        public int mPort = 1000;

        //--------------------------------------------------------------------
        // Purpose:
        //     Constructor.
        //
        // Notes:
        //     None.
        //--------------------------------------------------------------------
        public ConfigureFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SETTING_FILE);
            XmlNode firstNode = doc.FirstChild;
            XmlNodeList nodes = firstNode.ChildNodes;

            foreach(XmlNode node in nodes)
            {
                if (IPADDRESS_TAG == node.Name)
                {
                    mIPAddress = node.InnerText;
                }
                if (PORT_TAG == node.Name)
                {
                    int.TryParse(node.InnerText, out mPort);
                }
            }
        }
    }
}
