using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Fakes
{
    public class FakeErrorLogger : IErrorLogger
    {
        public Exception exception { get; set; }
        public void LogError(string message)
        {
            exception = new Exception(message);
        }
    }
}
