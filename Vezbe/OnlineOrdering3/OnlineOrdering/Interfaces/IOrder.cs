using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Interfaces
{
    public interface IOrder
    {
        void SaveOrderToDB(int orderId, int userId);

        void RemoveFromDB(int orderId);
    }
}
