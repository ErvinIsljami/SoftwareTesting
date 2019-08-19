using OTS2019_BankSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_BankSimulation.Interface
{
    interface IBanking
    {
        bool Credit(UserType user, decimal amount, DateTime date);
        void Payment(UserType user, decimal amount);
        bool Transfer(UserType user, decimal amount);
    }
}
