using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetworkTablesInterface
{
    public class ConfigureFile
    {
        const string SETTINGS_TAG = "Settings";
        const string IPADDRESS_TAG = "IPAddress";
        const string PORT_TAG = "Port";
        const string SETTING_FILE = "NetworkTablesSettings.xml";

        public string mIPAddress = "127.0.0.1";
        public int mPort = 1000;

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
