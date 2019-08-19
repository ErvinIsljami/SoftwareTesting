using OTS2019_BankSimulation.Interface;
using OTS2019_BankSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_BankSimulation.Class
{
    public class CompanyBanking : IBanking
    {
        public bool Credit(UserType user, decimal amount, DateTime date)
        {
            try
            {
                if (Form1.isChecked_rbtnCash)
                {
                    if (!user.hasCredit && user.monthlyAmount > 2000 && amount < 20000)
                    {
                        user.hasCredit = true;
                        return true;
                    }
                    else if (!user.hasCredit && amount < 20000 && user.balance >= 10000)
                    {
                        user.hasCredit = true;
                        return true;
                    }
                    else if (!user.hasCredit && amount >= 20000 && amount < 40000 && user.monthlyAmount >= 4000)
                    {
                        user.hasCredit = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (Form1.isChecked_rbtnRevolving)
                {
                    if (!user.hasCredit && amount <= 150000 && user.monthlyAmount >= 3000 && user.balance >= 20000)
                    {
                        user.hasCredit = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (Form1.isChecked_rbtnOpen)
                {
                    if (!user.hasCredit && amount <= 50000 && user.monthlyAmount >= 4000)
                    {
                        user.hasCredit = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (DivideByZeroException)
            {

                throw;
            }
        }

        public void Payment(UserType user, decimal amount)
        {
            if (amount == 0)
            {
                throw new Exception("Amount can't be 0!");
            }
            user.balance = user.balance + amount;
        }

        public bool Transfer(UserType user, decimal amount)
        {
            if (user.balance < amount)
            {
                throw new Exception("Amount can't be greater then user's balance!");
            }

            user.balance = user.balance - amount;
            return true;
        }
    }
}
