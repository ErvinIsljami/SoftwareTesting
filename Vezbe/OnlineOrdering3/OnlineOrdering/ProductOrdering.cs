using OnlineOrdering.Interfaces;
using OnlineOrdering.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrdering
{
    public class ProductOrdering
    {
        IUserLogger userLogger;
        IProductChecker productChecker;
        IOrder order;
        IEmailSender emailSender;
        IErrorLogger errorLogger;
        IStockManager stockManager;

        public ProductOrdering()
        {
            userLogger = new UserLogger();
            productChecker = new ProductChecker();
            order = new Order();
            emailSender = new EmailSender();
            errorLogger = new ErrorLogger();
            stockManager = new StockManager();
        }

        public ProductOrdering(IUserLogger userLogger, IProductChecker productChecker, IOrder order, IEmailSender emailSender, IErrorLogger errorLogger, IStockManager stockManager)
        {
            this.userLogger = userLogger;
            this.productChecker = productChecker;
            this.order = order;
            this.emailSender = emailSender;
            this.errorLogger = errorLogger;
            this.stockManager = stockManager;
        }

        public IUserLogger UserLogger
        {
            get { return userLogger; }
            set { userLogger = value; }
        }
        public IProductChecker ProductChecker
        {
            get { return productChecker; }
            set { productChecker = value; }
        }
        public IOrder Order
        {
            get { return order; }
            set { order = value; }
        }
        public IEmailSender EmailSender
        {
            get { return emailSender; }
            set { emailSender = value; }
        }
        public IErrorLogger ErrorLogger
        {
            get { return errorLogger; }
            set { errorLogger = value; }
        }
        public IStockManager StockManager
        {
            get { return stockManager; }
            set { stockManager = value; }
        }

        public void PlaceOrder(int orderId)
        {
            try
            {
                //dobaviti neophodne korisnicke podatke
                int userId = userLogger.GetLoggedUserId();
                string userEmail = userLogger.GetUserEmail(userId);

                //proveriti dostupnost proizvoda
                bool productAvailable = productChecker.CheckProductAvailability(orderId);

                //ukoliko su svi proizvodi dostupni skinuti proizvode sa stanja, sacuvati porudzbinu u bazi i poslati mejl potvrde
                if (productAvailable)
                {
                    stockManager.TakeOffStock(orderId); //skidanje sa lagera
                    order.SaveOrderToDB(orderId, userId); //cuvanje porudzbine u bazi
                    emailSender.SendEmail(userEmail,
                                         "Order created successfully",
                                         "Your order was created successfully. You can use the orderId=" + orderId + " to track your order."); //slanje mejla potvrde
                    
                }
                else
                {                    
                    throw new Exception("Some products are not available"); //neki proizvod nije dostupan
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Some products are not available"))
                {
                    order.RemoveFromDB(orderId); //porudzbina sa svim proizvodima se uklanja iz baze
                    stockManager.PutOnStock(orderId); //vracanje starog stanja na lageru
                }
                errorLogger.LogError(ex.Message); //logovanje greske
                throw ex;
            }
        }
    }
}
