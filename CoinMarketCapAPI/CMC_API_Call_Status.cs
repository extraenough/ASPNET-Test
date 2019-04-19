using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_Test2.CMC
{
    public class CMC_API_Call_Status
    {
        public DateTime timestamp       { get; set; }
        public int      error_code      { get; set; }
        public string   error_message   { get; set; }
        public int      elapsed         { get; set; }
        public int      credit_count    { get; set; }

    }
}