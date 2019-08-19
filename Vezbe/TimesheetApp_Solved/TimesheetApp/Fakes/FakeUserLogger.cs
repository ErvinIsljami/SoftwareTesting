using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetApp.Interfaces;

namespace TimesheetApp.Fakes
{
    public class FakeUserLogger : IUserLogger
    {
        public Exception ExceptionWillOccur = null;
        public string badEmail = string.Empty;

        public string GetLoggedUserEmail(string userName)
        {
            if (ExceptionWillOccur != null)
            {
                throw ExceptionWillOccur;
            }
            if (!string.IsNullOrEmpty(badEmail))
            {
                return badEmail;
            }
            return userName + "@gmail.com";
        }

        public string GetLoggedUserName()
        {
            return "test";
        }
    }
}
