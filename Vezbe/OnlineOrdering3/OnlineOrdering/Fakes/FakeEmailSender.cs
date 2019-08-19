using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Fakes
{
    public class FakeEmailSender : IEmailSender
    {
        public string To { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Exception exception = null;

        public void SendEmail(string to, string title, string body)
        {
            if(exception != null)
            {
                throw exception;
            }
            To = to;
            Title = title;
            Body = body;
        }
    }
}
