using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetApp.DBAccess;
using TimesheetApp.Interfaces;
using TimesheetApp.Util;

namespace TimesheetApp
{
    public class TimeLogger
    {
        private ITask task;
        private IEmailSender emailSender;
        private IErrorLogger errorLogger;
        private IUserLogger userLogger;
        private ITaskManager taskManager;

        public TimeLogger()
        {
            task = new TaskLogger();
            emailSender = new EmailSender();
            errorLogger = new ErrorLogger();
            userLogger = new UserLogger();
            taskManager = new TaskManager();
        }

        public TimeLogger(IUserLogger userLogger, ITaskManager taskManager, ITask task, IEmailSender emailSender, IErrorLogger errorLogger)
        {
            this.userLogger = userLogger;
            this.taskManager = taskManager;
            this.task = task;
            this.emailSender = emailSender;
            this.errorLogger = errorLogger;
        }

        public IUserLogger UserLogger
        {
            get { return userLogger; }
            set { userLogger = value; }
        }

        public ITaskManager TaskManager
        {
            get { return taskManager; }
            set { taskManager = value; }
        }

        public ITask Task
        {
            get { return task; }
            set { task = value; }
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

        public void LogTime(int hours, int minutes, string description)
        {
            try
            {
                //dobaviti podatke o trenutno logovanom korisniku (username, email)
                string userName = userLogger.GetLoggedUserName();
                string userEmail = userLogger.GetLoggedUserEmail(userName);

                //dobaviti podatke o projektu i aktivnosti (task) na projektu za koju se loguje vreme
                int taskId = taskManager.GetTaskId(userName, userEmail);

                //logovati vreme - sacuvati podatke u bazi
                task.TaskId = taskId;
                task.Hours = hours;
                task.Minutes = minutes;
                task.Description = description;
                bool saved = task.SaveToDB();
                if (saved)
                {
                    //poslati mejl obavestenja o logovanom vremenu
                    emailSender.SendEmail(userEmail, 
                                         "Time logged successfully",
                                         hours + " hours and " + minutes + " minutes successfully logged to task with ID=" + taskId);
                }
                else
                {
                    throw new Exception("Failed to save data to database");
                }                                               
            }
            catch (Exception ex) //obrada gresaka
            {
                errorLogger.LogError(ex);
                throw ex;
            }
        }
    }
}
