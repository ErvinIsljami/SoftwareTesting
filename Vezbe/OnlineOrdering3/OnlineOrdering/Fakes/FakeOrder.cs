using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Fakes
{
    public class FakeOrder : IOrder
    {
        public void RemoveFromDB(int orderId)
        {
            Console.WriteLine("Brisanje iz baze");
        }

        public void SaveOrderToDB(int orderId, int userId)
        {
            Console.WriteLine("Cuvanje u bazi");
        }
    }
}
