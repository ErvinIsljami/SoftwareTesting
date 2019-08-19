using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Fakes
{
    public class FakeStockManager : IStockManager
    {
        public Exception exception = null;
        public void PutOnStock(int orderId)
        {
            Console.WriteLine("Vracanje na lager");
        }

        public void TakeOffStock(int orderId)
        {
            if(exception != null)
            {
                throw exception;
            }
            Console.WriteLine("Uzianje sa lagera");
        }
    }
}
