using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Interfaces
{
    public interface IStockManager
    {
        void TakeOffStock(int orderId);

        void PutOnStock(int orderId);
    }
}
