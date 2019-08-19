using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Util
{
    public class ProductChecker : IProductChecker
    {
        public bool CheckProductAvailability(int orderId)
        {
            //Metoda prolazi kroz listu proizvoda u jednoj narudzbini (order-u) i ukoliko
            //su svi proizvodi dostupni vraca true, a ukoliko makar jedan nije dostupan vraca false
            throw new NotImplementedException();
        }
    }
}
