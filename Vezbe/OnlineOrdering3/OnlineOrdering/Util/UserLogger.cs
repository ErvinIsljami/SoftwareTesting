using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Util
{
    public class UserLogger : IUserLogger
    {
        public int GetLoggedUserId()
        {
            //Dobavlja ID trenutno logovanog korisnika
            throw new NotImplementedException();
        }

        public string GetUserEmail(int userId)
        {
            //Vraca email korisnika na osnovu ID-ja
            throw new NotImplementedException();
        }
    }
}
