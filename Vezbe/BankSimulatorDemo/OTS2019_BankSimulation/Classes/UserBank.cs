using OTS2019_BankSimulation.Interfaces;
using OTS2019_BankSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_BankSimulation.Classes
{
    public class UserBank : IBanking
    {
        private User user { get; set; }

        public UserBank(User user)
        {
            this.user = user;
        }

        public void Credit(User user, decimal amount)
        {
            if (Form1.isChecked_rbtnCash)
            {

            }
            else if (Form1.isChecked_rbtnRevolving)
            {

            }
            else if (Form1.isChecked_rbtnOpen)
            {

            }
        }

        public void Payment(User user, decimal amount)
        {
            user.balance = user.balance + amount;
        }

        public void TransferOut(User user, decimal amount)
        {
            if (user.balance > amount)
            {
                user.balance = user.balance - amount;
            }
        }
    }
}
