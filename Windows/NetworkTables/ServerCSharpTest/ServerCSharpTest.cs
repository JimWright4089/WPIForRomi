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

namespace ServerCSharpTest
{
    public partial class ServerCSharpTest : Form
    {
        double mCount = 0.0;
        long mCountLong = 0;

        public ServerCSharpTest()
        {
            InitializeComponent();
            NetworkTable.Flush();
            NetworkTable.StartServer("persistent.ini", "", 10000);
            NetworkTable.SetEntryValueDouble("/foo", 0.5);
            NetworkTable.SetEntryFlags("/foo", NetworkTable.NT_PERSISTENT);
            NetworkTable.SetEntryValueDouble("/foo2", 0.5);
            NetworkTable.SetEntryValueDouble("/foo2", 0.7);
            NetworkTable.SetEntryValueDouble("/foo2", 0.6);
            NetworkTable.SetEntryValueDouble("/foo2", 0.5);
            tDisplay.Enabled = true;
        }

        private void tDisplay_Tick(object sender, EventArgs e)
        {
            double sin = Math.Sin(mCount) * 100.0;
            lSin.Text = sin.ToString("F4");
            string text = "Sin:" + sin.ToString("f2");
            bool theBool = (0 == (mCountLong % 2));
            mCountLong++;
            NetworkTable.SetEntryValueDouble("/double", sin);
            NetworkTable.SetEntryValueDouble("/sin", Math.Sin(mCount));
            NetworkTable.SetEntryValueDouble("/cos", Math.Cos(mCount));
            NetworkTable.SetEntryValueString("/string", text);
            NetworkTable.SetEntryValueBool("/bool", theBool);
            mCount += 0.01;
        }
    }
}
