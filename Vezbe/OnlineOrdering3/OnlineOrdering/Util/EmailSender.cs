using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Util
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string to, string title, string body)
        {
            //Salje mejl obavestenja kupcu o izvrsenoj kupovini
            throw new NotImplementedException();
        }
    }
}
