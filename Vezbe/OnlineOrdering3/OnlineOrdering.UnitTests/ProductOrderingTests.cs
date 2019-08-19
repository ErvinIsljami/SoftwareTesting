using NSubstitute;
using NUnit.Framework;
using OnlineOrdering.Fakes;
using OnlineOrdering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering.UnitTests
{
    [TestFixture]
    class ProductOrderingTests
    {
        [Test]
        public void uspesnaProveraICuvanjePorudzbine()
        {
            FakeProductChecker productChecker = new FakeProductChecker();
            FakeUserLogger userLogger = new FakeUserLogger();
            FakeStockManager stockManager = new FakeStockManager();
            FakeOrder order = new FakeOrder();
            FakeEmailSender emailSender = new FakeEmailSender();

            ProductOrdering productOrdering = new ProductOrdering(userLogger, productChecker, order, emailSender, null, stockManager);

            productOrdering.PlaceOrder(100);
            StringAssert.Contains("test@gmail.com", emailSender.To);
        }
        [Test]
        public void greskaPrilikomProvereDostupnostiProizvoda()
        {
            FakeProductChecker productChecker = new FakeProductChecker();
            FakeUserLogger userLogger = new FakeUserLogger();
            FakeStockManager stockManager = new FakeStockManager();
            FakeOrder order = new FakeOrder();
            productChecker.exception = new Exception();
            FakeErrorLogger errorLogger = new FakeErrorLogger();

            ProductOrdering productOrdering = new ProductOrdering(userLogger, productChecker, order, null, errorLogger, stockManager);

            Exception ex = Assert.Throws<Exception>(() => productOrdering.PlaceOrder(100));
            Assert.That(ex.Message, Is.EqualTo(errorLogger.exception.Message));
        }
        [Test]
        public void greskaPrilikomSlanjaMejla()
        {
            string errorMsg = "Failed to send email";
            FakeProductChecker productChecker = new FakeProductChecker();
            FakeUserLogger userLogger = new FakeUserLogger();
            FakeStockManager stockManager = new FakeStockManager();
            FakeOrder order = new FakeOrder();
            FakeEmailSender emailSender = new FakeEmailSender();
            emailSender.exception = new Exception(errorMsg);
            //FakeErrorLogger errorLogger = new FakeErrorLogger();
            IErrorLogger errorLogger = Substitute.For<IErrorLogger>();

            ProductOrdering productOrdering = new ProductOrdering(userLogger, productChecker, order, emailSender, errorLogger, stockManager);
            Exception ex = Assert.Throws<Exception>(() => productOrdering.PlaceOrder(100));
            errorLogger.Received().LogError(ex.Message);
            StringAssert.Contains("Failed to send email", ex.Message);
        }
        [Test]
        public void greskaNekiOdProizvodaNisuDostupni()
        {
            FakeProductChecker productChecker = new FakeProductChecker();
            FakeUserLogger userLogger = new FakeUserLogger();
            FakeStockManager stockManager = new FakeStockManager();
            FakeOrder order = new FakeOrder();
            FakeErrorLogger errorLogger = new FakeErrorLogger();
            productChecker.available = false;

            ProductOrdering productOrdering = new ProductOrdering(userLogger, productChecker, order, null, errorLogger, stockManager);
            Exception ex = Assert.Throws<Exception>(() => productOrdering.PlaceOrder(100));
            StringAssert.Contains("Some products are not available", ex.Message);
            Assert.AreEqual(ex.Message, errorLogger.exception.Message);
        }
        [Test]
        public void greskaPrilikomSkidanjaProizvodaSaLagera()
        {
            FakeProductChecker productChecker = new FakeProductChecker();
            FakeUserLogger userLogger = new FakeUserLogger();
            FakeStockManager stockManager = new FakeStockManager();
            stockManager.exception = new Exception();
            IErrorLogger errorLogger = Substitute.For<IErrorLogger>();

            ProductOrdering productOrdering = new ProductOrdering();
            productOrdering.ProductChecker = productChecker;
            productOrdering.UserLogger = userLogger;
            productOrdering.StockManager = stockManager;
            productOrdering.ErrorLogger = errorLogger;

            Exception ex = Assert.Throws<Exception>(() => productOrdering.PlaceOrder(100));
            errorLogger.Received().LogError(ex.Message);
        }
    }
}
