using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            // CustomManager customManager = new CustomManager(10); 
            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());
            employeeManager.Add();

            PersonManager personManager = new PersonManager("Product");
            personManager.Add();
            Console.ReadLine();
        }
    }

    class CustomManager
    {
        private int _count;

        public CustomManager() // Constructorlar classla aynı ada sahip olur.Constructorlar override edilecekse mutlaka boş bir tane oluşturulmalıdır.
        {

        }

        public CustomManager(int count)// bu classtan nesne oluştururken tek int parametresi gönderilirse bu constructor çalışır.
        {
            _count = count;//paramere olarak gelen count classta tanımlanmış private _count değerine atanır.
        }
        public void List()
        {
            Console.WriteLine("Listed {0} items", _count);
        }

        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }

    interface ILogger
    {
        void Log();
    } // interface oluşturuldu.

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database.");
        }
    } //interface implementasyonu yapıldı.

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file.");
        }
    }

    class EmployeeManager
    {
        private ILogger _logger;

        public EmployeeManager(ILogger logger) // Constructor kullanılarak injeksiyon yapıldı.
        {
            _logger = logger;
        }

        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added.");
        }

    }


    class BaseClass
    {
        private string _entity;

        public BaseClass(string entity)
        {
            _entity = entity;
        }

        public void Message()
        {
            Console.WriteLine("{0} message", _entity);
        }
    }
    class PersonManager : BaseClass
    {
        //ata classta yer alan constructor parametreli olduğu için bu kullanım yapılarak bir üst classın constructoruna parametre gönderilir.
        public PersonManager(string entity) : base(entity){ }

        public void Add()
        {
            Console.WriteLine("Added!");
            Message(); //ata classta yer alan metot kullanıldı.
        }
    }
}
