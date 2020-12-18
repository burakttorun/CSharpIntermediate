using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();

            MySql mySql = new MySql();
            mySql.Add(); //görünürde class boş olsa bile miras aldığı atanın metotunu kullanabilir.

        }
    }

    class Database
    {
        /*Ata classta yer alan metotlar miras alan classlarda doğrudan kullanılabilirken, "virtual" anahtar kelimesi ile işaretlenmiş metotlar miras alan
         classlarda yeniden tanımlanabilir ve ihtiyaca göre dizayn edilebilir. Bunun için "override" anahtar kelimesi kullanılmalıdır.*/

        public virtual void Add()
        {
            Console.WriteLine("Added by default");
        }
        public void Delete()
        {
            Console.WriteLine("Deleted by default");
        }
    }

    class SqlServer : Database
    {
        public override void Add()
        {
            //base.Add(); --> Bu ifade de yer alan "base" bir üst classı işaret eder.
            Console.WriteLine("Added by Sql Code");
        }
    }

    class MySql : Database
    {

    }
}
