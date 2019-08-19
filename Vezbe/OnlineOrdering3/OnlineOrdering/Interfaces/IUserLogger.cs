using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Interfaces
{
    public interface IUserLogger
    {
        int GetLoggedUserId();

        string GetUserEmail(int userId);
    }
}
