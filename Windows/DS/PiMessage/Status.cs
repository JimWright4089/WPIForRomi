using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiMessage
{
    public class DSStatus
    {
        public const byte STATUS_DISA = 0x00;
        public const byte STATUS_AUTO = 0x01;
        public const byte STATUS_TELE = 0x02;
        public const byte STATUS_TEST = 0x03;
    }

    public class RCStatus
    {
        public const byte STATUS_GOOD = 0x04;
        public const byte STATUS_FAIL = 0x05;
    }
}
