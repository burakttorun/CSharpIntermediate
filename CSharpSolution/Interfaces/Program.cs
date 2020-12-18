using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo();
            //InterfacesIntro();

            ICustomerDal[] customerDals = new ICustomerDal[3] //interface parametreli bir dizi oluşturuldu.
            {
                //bu interface i implementasyon yapmış diğer classlardan nesne üretilip diziye yerleştirildi.
                new SqlServerCustomerDal(),
                new OracleServerCustomerDal(),
                new MysqlServerCustomerDal()
            };

            foreach (var item in customerDals)//döngü yardımıyla interfacede yazılmış olan "Add()" metotu her bir nesnede çalıştırıldı.
            {
                item.Add();
            }

            Console.ReadLine();
        }

        private static void Demo()
        {
            CustomerManeger customerManeger = new CustomerManeger();
            customerManeger.Add(new OracleServerCustomerDal());
        }

        private static void InterfacesIntro()
        {
            IPerson customer = new Customer { id = 1, firstName = "Beyza", lastName = "Zambak", address = "İstanbul" };
            IPerson student = new Student { id = 2, firstName = "Ali", lastName = "Toprak", department = "Computer" };
            ProductManager productManager = new ProductManager();
            productManager.Add(student);
        }
    }

    interface IPerson
    {
        int id { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
    }


    class Customer : IPerson
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
    }

    class Student : IPerson
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string department { get; set; }

    }
    class Worker : IPerson
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string department { get; set; }
    }

    class ProductManager
    {
        /*parametre Interface tipinte atandığı için
          bu interfacei implementasyon yapan bütün classlar bu metota parametre gönderebilir hale getirildi.*/
        public void Add(IPerson person)
        {
            Console.WriteLine(person.firstName);
        }
    }
}

