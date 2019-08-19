using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Interfaces
{
    public interface IErrorLogger
    {
        void LogError(string message);
    }
}
