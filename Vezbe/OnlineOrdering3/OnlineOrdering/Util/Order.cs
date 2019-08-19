using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Util
{
    public class Order : IOrder
    {
        public void RemoveFromDB(int orderId)
        {
            //Metoda koja na osnovu ID-ja uklanja order sa svim proizvodima iz baze podataka
            throw new NotImplementedException();
        }

        public void SaveOrderToDB(int orderId, int userId)
        {
            //Metoda koja na osnovu ID-ja dobavlja order sa svim proizvodima i cuva odredjene podatke u bazi
            throw new NotImplementedException();
        }
    }
}
