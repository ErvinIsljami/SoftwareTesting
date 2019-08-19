using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetApp.Interfaces;

namespace TimesheetApp.Fakes
{
    public class FakeEmailSender : IEmailSender
    {
        public string To { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Exception ExceptionWillOccur = null;


        public void SendEmail(string to, string title, string body)
        {
            if (ExceptionWillOccur != null)
            {
                throw ExceptionWillOccur;
            }

            To = to;
            Title = title;
            Body = body;
        }
    }
}
