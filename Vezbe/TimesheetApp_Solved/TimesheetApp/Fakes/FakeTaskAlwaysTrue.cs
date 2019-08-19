using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetApp.Interfaces;

namespace TimesheetApp.Fakes
{
    public class FakeTaskAlwaysTrue : ITask 
    {
        public int TaskId { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public string Description { get; set; }

        public bool SaveToDB()
        {
            return true;
        }
    }
}
