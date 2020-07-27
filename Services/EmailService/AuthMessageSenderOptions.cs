using System;
using System.Collections.Generic;
using System.Text;

namespace Services.EmailService
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
