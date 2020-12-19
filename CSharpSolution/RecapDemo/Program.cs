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
            customManager.logger = new DatabaseLogger(); // Müşterinin ihtiyacına göre logger nesnesi oluşturuldu.
            customManager.Add();           
            Console.ReadLine();
        }
        
    }

    class CustomManager
    {
        public ILogger logger { get; set; } /*Her yeni eklenen log sistemi için kod değişikliği yapmamak için CustomManager e bir "ILogger
        tipinde prop eklendi.*/
        
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
