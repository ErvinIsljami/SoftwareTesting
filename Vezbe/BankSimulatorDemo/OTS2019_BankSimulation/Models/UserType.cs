using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_BankSimulation.Models
{
    public abstract class UserType
    {
        public decimal balance { get; set; }
        public bool hasCredit { get; set; }
        public decimal monthlyAmount { get; set; }
    }
}
