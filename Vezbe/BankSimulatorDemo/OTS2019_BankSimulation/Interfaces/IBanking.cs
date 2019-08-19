using OTS2019_BankSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_BankSimulation.Interfaces
{
    interface IBanking
    {
        void Credit(User user, decimal amount);
        void Payment(User user, decimal amount);
        void TransferOut(User user, decimal amount);
    }
}
