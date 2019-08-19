using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Fakes
{
    public class FakeUserLogger : IUserLogger
    {
        public int GetLoggedUserId()
        {
            return 100;
        }

        public string GetUserEmail(int userId)
        {
            return "test@gmail.com";
        }
    }
}
