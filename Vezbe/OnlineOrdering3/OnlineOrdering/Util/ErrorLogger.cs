using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Util
{
    public class ErrorLogger : IErrorLogger
    {
        public void LogError(string message)
        {
            //Vrsi logovanjegreske u bazu
            throw new NotImplementedException();
        }
    }
}
