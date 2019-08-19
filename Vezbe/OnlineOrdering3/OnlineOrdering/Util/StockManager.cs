using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.Util
{
    public class StockManager : IStockManager
    {
        public void PutOnStock(int orderId)
        {
            //Pronalazi porudzbinu na osnovu orderId-ja, uzima ID-jeve svih proizvoda iz porudzbine i stavlja ih na lagera
            throw new NotImplementedException();
        }

        public void TakeOffStock(int orderId)
        {
            //Pronalazi porudzbinu na osnovu orderId-ja, uzima ID-jeve svih proizvoda iz porudzbine i skida ih sa lagera
            throw new NotImplementedException();
        }
    }
}
