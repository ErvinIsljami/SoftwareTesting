using NUnit.Framework;
using OTS2019_BankSimulation.Class;
using OTS2019_BankSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_BankSimulation.Test
{
    [TestFixture]
    class UserBankingTest
    {
        //Unit test koji testira metodu Payment
        //Pocetno stanje na racunu user-a je 0. Uplatom se stanje na racunu povecava na 500
        [Test]
        public void Payment_Success()
        {
            User user = new User("Pera", "Peric", 500, 0, false);
            UserBanking bank = new UserBanking();
            bank.Payment(user, 500);
            Assert.AreEqual(500, user.balance);
        }

        //Unit test koji testira metodu Transfer
        //Pocetno stanje na racunu je 1000 i pozivanjem funkcije Transfer ce sredstva sa racuna biti skinuta
        //Koristi se asertacija IsTrue - koja proverava da li je povratna vrednost funkcije true
        [Test]
        public void transfer_suc()
        {
            User user = new User("mare", "mare", 500, 1000, false);
            UserBanking bank = new UserBanking();
            Assert.IsTrue( bank.Transfer(user, 500));
        }
        //Unit test koji testira metodu Payment i ocekivano je izazivanje exception-a
        //Default tip Exception-a ce biti rezultat prosledjivanja funkciji Payment vrednosti 0.
        [Test]
        public void PaymentExeptciotn()
        {
            User user = new User("MAre", "Care", 0, 40, false);
            UserBanking bank = new UserBanking();
            Assert.Throws<Exception>(() => bank.Payment(user, 0));
        }

        //Unit test koji testira metodu Transfer i ocekivano je izazivanje exception-a
        //Default tip Exception-a ce biti rezultat prosledjivanja funkciji Transfer vrednosti koja je veca od trenutnog stanja na racunu user-a
        [Test]
        public void Transfer_ExceptionExpected()
        {
            User user = new User("Pera", "Peric", 500, 0, false);
            UserBanking bank = new UserBanking();
            Assert.Throws<Exception>(() => bank.Transfer(user, 300));
        }

        //Parametrizovani test koji testira metodu Credit i uslov vezan za CashCredit u okviru nje
        //Kao parametri testu putem dekoratora TestCase redom se prosledjuju amount(iznos kredita), monthlyAmount(mesecna plata), balance(stanje na racunu)
        //Ocekivan rezultat ovog testa je da ce zadovoljiti uslove i da ce kredit biti odobren, zbog toga se koristi asertacija IsTrue.
        [TestCase(1200, 700, 1000)]
        public void CashCredit_Success(decimal amount, decimal monthlyAmount, decimal balance)
        {
            DateTime date = new DateTime(2021, 3, 23);
            User user = new User("Pera", "Peric", monthlyAmount, balance, false);
            Form1.isChecked_rbtnCash = true;
            UserBanking bank = new UserBanking();
            Assert.IsTrue(bank.Credit(user, amount, date));
        }

        //Parametrizovani test koji testira metodu Credit i uslov vezan za CashCredit u okviru nje
        //Kao parametri testu putem dekoratora TestCase redom se prosledjuju amount(iznos kredita), monthlyAmount(mesecna plata), balance(stanje na racunu)
        //Ocekivan rezultat ovog testa je da nece zadovoljiti uslove definisane u metodi Credit i samim tim kredit nece biti odobren. Zbog toga se koristi asertacija IsFalse.
        [TestCase(12000, 700, 1000)]
        public void CashCredit_Failed(decimal amount, decimal monthlyAmount, decimal balance)
        {
            DateTime date = new DateTime(2021, 3, 23);
            User user = new User("Pera", "Peric", monthlyAmount, balance, false);
            Form1.isChecked_rbtnCash = true;
            UserBanking bank = new UserBanking();
            Assert.IsFalse(bank.Credit(user, amount, date));
        }

        //Parametrizovani test sa povratnom vrednoscu koji testira metodu Credit i uslov vezan za RevolvingCredit u okviru nje.
        //Kao parametri testu putem dekoratora TestCase redom se prosledjuju amount(iznos kredita), monthlyAmount(mesecna plata), balance(stanje na racunu) i ExpectedResult(sto ce predstavljati ocekivanu povratnu vrednost metode)
        //Zbog navedena dva dekoratora TestCase, ova metoda bice iskoriscena za 2 razlicita testa. Od toga, prvi ce rezultovati uspesnim odobravanjem kredita, a drugi neodobravanjem.
        //S obzirom na to da je rec o parametrizovanim testovima sa povratnom vrednoscu, testna metoda ima povratni tip podatka bool.
        [TestCase(15000, 1000, 1000, ExpectedResult = true)]
        [TestCase(25000, 1000, 1000, ExpectedResult = false)]
        public bool RevolvingCredit_FirstTestSuccess_SecondTestFailed(decimal amount, decimal monthlyAmount, decimal balance)
        {
            DateTime date = new DateTime(2025, 3, 23);
            User user = new User("Pera", "Peric", monthlyAmount, balance, false);
            Form1.isChecked_rbtnRevolving = true;
            UserBanking bank = new UserBanking();
            return bank.Credit(user, amount, date);
        }

        //Unit test koji testira pojavu DivideByZeroException-a u okviru Credit metode
        //Ovaj tip exception-a ce se pojaviti u slucaju da se kao datum Credit metodi prosledi neki datum iz 2019. godine - sto ce usloviti da varijabla 'year' u okviru Credit metode bude 0.
        [Test]
        public void CashCredit_DivideByZeroExceptionExpected()
        {
            DateTime date = new DateTime(2019, 3, 23);
            User user = new User("Pera", "Peric", 5000, 5000, false);
            Form1.isChecked_rbtnCash = true;
            UserBanking bank = new UserBanking();
            Assert.Throws<DivideByZeroException>(() => bank.Credit(user, 7, date));
        }

        //Parametrizovani test koji ocekuje da kredit ne bude odobren na osnovu postavljanja parametra 'hasCredit' na true.
        //Zahtev u okviru zadatka je da jedan user moze imati samo jedan kredit na svoje ime, sto se parametrom 'hasCredit' regulise.
        [TestCase(12000, 700, 1000)]
        public void RevolvingCredit_Failed_UserAlreadyHasCredit(decimal amount, decimal monthlyAmount, decimal balance)
        {
            DateTime date = new DateTime(2025, 3, 23);
            User user = new User("Pera", "Peric", monthlyAmount, balance, true);
            Form1.isChecked_rbtnRevolving = true;
            UserBanking bank = new UserBanking();
            Assert.IsFalse(bank.Credit(user, amount, date));
        }
    }
}
