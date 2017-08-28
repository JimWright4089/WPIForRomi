using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NetworkTablesInterface;

namespace ClientCSharpTest
{
    public partial class ClientCSharpTest : Form
    {
        double mOldData = 0;
        DateTime mOldTime = DateTime.Now;
        long mTotalTime = 0;
        long mCount = 0;

        public ClientCSharpTest()
        {
            InitializeComponent();

            NetworkTable.StartClient("192.168.143.124", 1735);

            tDisplay.Enabled = true;
        }

        private void tDisplay_Tick(object sender, EventArgs e)
        {
            double sin = NetworkTable.GetEntryValueDouble("/datatable/x");
            double sin2 = NetworkTable.GetEntryValueDouble("/string");

            string text = NetworkTable.GetEntryValueString("/string").ToString();

            bool theBool = NetworkTable.GetEntryValueBool("/bool");
            bool theBool2 = NetworkTable.GetEntryValueBool("/bool2");

            lDouble.Text = sin.ToString("F4");
            lString.Text = text;
            lBool.Text = theBool.ToString();
            lDouble2.Text = sin2.ToString("F3");

            if(mOldData != sin)
            {
                long lastTime = (long)DateTime.Now.Subtract(mOldTime).TotalMilliseconds;
                lLastTime.Text = lastTime.ToString();
                mTotalTime += lastTime;
                mCount++;
                lTime.Text = ((double)mTotalTime / (double)mCount).ToString("F4");
                mOldTime = DateTime.Now;
                mOldData = sin;
            }

        }
    }
}
