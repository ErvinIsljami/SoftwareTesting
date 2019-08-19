using OTS2019_BankSimulation.Interface;
using OTS2019_BankSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_BankSimulation.Class
{
    public class UserBanking : IBanking
    {
        public bool Credit(UserType user, decimal amount, DateTime date)
        {
            try
            {
                DateTime today = DateTime.Today;
                int year = date.Year - today.Year;
                decimal monthlyPayment = amount / year / 12;
                if (Form1.isChecked_rbtnCash && year <= 5)
                {
                    if (!user.hasCredit && user.monthlyAmount > 600 && amount < 2000 && monthlyPayment >= 50)
                    {
                        user.hasCredit = true;
                        return true;
                    }
                    else if (!user.hasCredit && amount < 2000 && user.balance >= 1000 && monthlyPayment >= 50)
                    {
                        user.hasCredit = true;
                        return true;
                    }
                    else if (!user.hasCredit && amount >= 2000 && amount < 5000 && user.monthlyAmount >= 800 && monthlyPayment >= 50)
                    {
                        user.hasCredit = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (Form1.isChecked_rbtnRevolving && year <= 10 && year > 5)
                {
                    if (!user.hasCredit && amount <= 20000 && user.monthlyAmount >= 800 && user.balance >= 1000 && monthlyPayment >= 80)
                    {
                        user.hasCredit = true;

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (Form1.isChecked_rbtnOpen && year <= 5)
                {
                    if (!user.hasCredit && amount <= 5000 && user.monthlyAmount >= 400 && monthlyPayment >= 50)
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
            catch (Exception)
            {
                throw new Exception("User has already have a credit!");
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
