using NSubstitute;
using NUnit.Framework;
using System;
using TimesheetApp;
using TimesheetApp.Fakes;
using TimesheetApp.Interfaces;


namespace TimeSheetAppTest
{
    /// <summary>
    /// Testna klasa za TimeLogger
    /// </summary>
    /// <remarks>
    /// NAPOMENA: Ukoliko neki test ne zahteva upotrebu nekih laznih implementacija nije ih potrebno
    /// instancirati i dodavati u okviru tog testa
    /// </remarks>
    [TestFixture]
    class TimeLoggerTest
    {
        /// <summary>
        /// Testni zahtev 1
        /// </summary>
        /// <remarks>
        /// Uspesno logovanje vremena podrazumeva da su dobijeni korektni podaci od svih potrebnih zavisnosti 
        ///i da je email uspesno poslat, odnosno da je uspesno pozvana metoda SendEmail
        /// </remarks>
        [Test]
        public void LogTime_ValidInput_Success()
        {
            FakeUserLogger userLogger = new FakeUserLogger();
            FakeTaskManager taskManager = new FakeTaskManager();
            FakeTaskAlwaysTrue task = new FakeTaskAlwaysTrue();
            FakeEmailSender emailSender = new FakeEmailSender();

            TimeLogger time = new TimeLogger(userLogger, taskManager, task, emailSender, null);

            time.LogTime(2, 30, "Working on TimesheetApp");

            StringAssert.Contains("Time logged successfully", emailSender.Title);
        }

        /// <summary>
        /// Testni zahtev 2
        /// </summary>
        /// <remarks>
        /// Scenario nastanka greske u koraku 3 podrazumeva nastanak greske prilikom poziva metode SaveToDB(),
        /// sto moze da se testira jednostavnim vracanjem vrednosti false od strane date metode posto nam je cilj
        /// da dodjemo do dela koda koji loguje gresku
        /// </remarks>
        [Test]
        public void LogTime_FailedOnDBSave_LogException_Success()
        {
            FakeUserLogger userLogger = new FakeUserLogger();
            FakeTaskManager taskManager = new FakeTaskManager();
            FakeTaskAlwaysFalse task = new FakeTaskAlwaysFalse();
            FakeErrorLogger errorLogger = new FakeErrorLogger();

            TimeLogger time = new TimeLogger(userLogger, taskManager, task, null, errorLogger);

            var ex = Assert.Throws<Exception>(() => time.LogTime(2, 30, "Working on TimesheetApp"));
            Assert.That(ex.Message, Is.EqualTo(errorLogger.Error.Message));
        }

        /// <summary>
        /// Testni zahtev 3
        /// </summary>
        /// <remarks>
        /// Scenario nastanka Exception-a prilikom dobavljanja email-a mozemo da testiramo tako sto vrsimo
        /// prosirenje stub-a FakeUserLogger i dodajemo polje ExceptionWillOccur koje inicijalizujemo iz testa
        /// </remarks>
        [Test]
        public void LogTime_GetUserEmailFail_LogError_Fail()
        {
            string errorMsg = "Failed to get user email";
            FakeUserLogger userLogger = new FakeUserLogger();
            userLogger.ExceptionWillOccur = new Exception(errorMsg);
            IErrorLogger errorLogger = Substitute.For<IErrorLogger>();
                       
            TimeLogger time = new TimeLogger();
            time.UserLogger = userLogger;
            time.ErrorLogger = errorLogger;

            Exception ex = Assert.Throws<Exception>(() => time.LogTime(2, 30, "Working on TimesheetApp"));
            StringAssert.Contains(errorMsg, ex.Message);
            errorLogger.Received().LogError(ex);
        }

        /// <summary>
        /// Testni zahtev 4
        /// </summary>
        /// <remarks>
        /// Scenario nastanka greske prilikom dobavljanja podataka o task-u testiramo slicno kao i testni zahtev 3
        /// </remarks>
        [Test]
        public void LogTime_GetTaskDataError_LogError_Fail()
        {
            string errorMsg = "Failed to get the task info";
            FakeUserLogger userLogger = new FakeUserLogger();
            FakeTaskManager taskManager = new FakeTaskManager();
            FakeErrorLogger errorLogger = new FakeErrorLogger();
            
            taskManager.ExceptionWillOccur = new Exception(errorMsg);

            TimeLogger time = new TimeLogger(userLogger, taskManager, null, null, errorLogger);

            var ex = Assert.Throws<Exception>(() => time.LogTime(2, 30, "Working on TimesheetApp"));
            Assert.That(ex.Message, Is.EqualTo(errorMsg));
            Assert.AreEqual(ex, errorLogger.Error);
        }

        /// <summary>
        /// Testni zahtev 5
        /// </summary>
        /// <remarks>
        /// Slucaj nastanka greske u ovom scenariju je moguce tretirati kao slucaj da nije poslata odgovarajuca poruka,
        /// odnosno da poziv nije dobro upucen. Ovo je moguce realizovati simulacijom da neki stub nije vratio dobar podatak
        /// i da samim time mock nece dobiti ono sto bi ocekivali da dobije.
        /// </remarks>
        [Test]
        public void LogTime_SendEmailError_BadData_Fail()
        {
            FakeUserLogger userLogger = new FakeUserLogger();
            userLogger.badEmail = "somebademail@mail.com";
            FakeTaskManager taskManager = new FakeTaskManager();
            FakeTaskAlwaysTrue task = new FakeTaskAlwaysTrue();
            IEmailSender emailSender = Substitute.For<IEmailSender>();                                    

            TimeLogger time = new TimeLogger(userLogger, taskManager, task, emailSender, null);

            time.LogTime(2, 30, "Working on TimesheetApp");

            emailSender.DidNotReceive().SendEmail("test@gmail.com", "Time logged successfully", "2 hours and 30 minutes successfully logged to task with ID=100");
        }
    }
}
