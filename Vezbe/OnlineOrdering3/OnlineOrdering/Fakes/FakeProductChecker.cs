using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Fakes
{
    public class FakeProductChecker : IProductChecker
    {
        public Exception exception = null;
        public bool available = true;
        public bool CheckProductAvailability(int orderId)
        {
            if(exception != null)
            {
                throw exception;
            }
            return available;
        }
    }
}
