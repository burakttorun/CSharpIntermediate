using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            // Database database = new Database(); --> abstract bir classtan nesne oluşturulamaz!

            Database database = new SqlServer();
            database.Add();
            database.Delete();

            //interface lerde olduğu gibi bir kullanım yapılabilir.
            Database database2 = new MySql();
            database2.Add();
            database2.Delete();

            Console.ReadLine();
        }
    }

    /*abstact classlarda ortak kullanılacak metodların yazıldığı gibi her bir classta farklılık gösterecek metotlarda yazılır ve
    class içerisinde bir tane bile abstract metot varsa o class abstact olur.*/
    abstract class Database
    {
        public void Add()
        {
            Console.WriteLine("Added by default.");
        }

        public abstract void Delete();
        
    }

    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by SqlServer");
        }
    }

    class MySql : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by MySql");
        }
    }

}
