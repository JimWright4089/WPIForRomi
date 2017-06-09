using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PiMessage
{
    public class ConfigureFile
    {
        const string SETTINGS_TAG = "Settings";
        const string IPADDRESS_TAG = "IPAddress";
        const string RC_PORT_TAG = "RCPort";
        const string DS_PORT_TAG = "DSPort";
        const string SETTING_FILE = "IPSettings.xml";

        public string mIPAddress = "172.26.225.41";
        public int mDSPort = 1150;
        public int mRCPort = 1110;

        public ConfigureFile()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(SETTING_FILE);
                XmlNode firstNode = doc.FirstChild;
                XmlNodeList nodes = firstNode.ChildNodes;

                foreach (XmlNode node in nodes)
                {
                    if (IPADDRESS_TAG == node.Name)
                    {
                        mIPAddress = node.InnerText;
                    }
                    if (RC_PORT_TAG == node.Name)
                    {
                        int.TryParse(node.InnerText, out mRCPort);
                    }
                    if (DS_PORT_TAG == node.Name)
                    {
                        int.TryParse(node.InnerText, out mDSPort);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
