using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetApp.Interfaces;

namespace TimesheetApp.Fakes
{
    public class FakeErrorLogger : IErrorLogger
    {
        public Exception Error { get; set; }

        public void LogError(Exception error)
        {
            Error = error;
        }
    }
}
