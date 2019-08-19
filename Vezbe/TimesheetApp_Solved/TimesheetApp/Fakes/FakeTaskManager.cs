using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetApp.Interfaces;

namespace TimesheetApp.Fakes
{
    public class FakeTaskManager : ITaskManager
    {
        public Exception ExceptionWillOccur = null;

        public int GetTaskId(string loggedUserName, string loggedUserEmail)
        {
            if (ExceptionWillOccur != null)
            {
                throw ExceptionWillOccur;
            }
            return 100;
        }
    }
}
