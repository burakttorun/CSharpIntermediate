using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomManager customManager = new CustomManager();
            customManager.logger = new DatabaseLogger();
            customManager.Add();           
            Console.ReadLine();
        }
        
    }

    class CustomManager
    {
        public ILogger logger { get; set; } 
        
        public void Add()
        {
            Console.WriteLine("Customer added.");
            logger.Log();
        }

        
    }

    interface ILogger
    {
        void Log();
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database.");
        }
    }

    class SmsLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to sms.");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file.");
        }
    }
}
