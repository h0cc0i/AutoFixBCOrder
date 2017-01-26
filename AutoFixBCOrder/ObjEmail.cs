using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFixBCOrder
{
    public class ObjEmail
    {
        public string email { get; set; }
        public string password { get; set; }
        public string  Subject { get; set; }
        public string  Body { get; set; }
        public List<string>  desEmail { get; set; }
        public string SmtpServer { get; set; }
        public string attachmentPath { get; set; }

        public int Port { get; set; }
        public bool IsGmail { get; set; }
    }
}
