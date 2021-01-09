using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("Ankara", "Istanbul", "Izmir");//string paremetreler gönderildi.

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Customer customers = new Customer();
            List<Customer> result2 = utilities.BuildList<Customer>(new Customer { firstName = "Burak" },
                new Customer { firstName = "Ömer" });//Customer tipli parametre gönderildi.
            foreach (var item in result2)
            {
                Console.WriteLine(item.firstName);
            }
            Console.ReadLine();
        }

    }

    class Utilities
    {
        //farklı türlerde parametre gönderip aynı tip metotlar kullanılacağı zaman bu yöntem kullanılır.
        public List<T> BuildList<T>(params T[] items)//hangi tip gönderilirse o tiple işlem yapılır.
        {
            return new List<T>(items);
        }


    }
    interface IEntity { }
    class Student : IEntity { }
    class Product : IEntity { }


    class Customer : IEntity
    {
        public string firstName { get; set; }
    }

    /* Burada ortak olarak kullanılan kod blokları belirtilir ve sadece tip farklılıkları söz konusu olduğu için Parametre olarak
       ortak bir harflendirme ve parametre adı belirlenir.*/
    interface IRepository<T> where T : class, IEntity, new()/*burada generic class lara kısıtlama getirebiliriz.
         "where T:" T parametresinin ne olabileceğini gösterir. "class" referans tip olması gerektiğini gösterir. 
        "IEntity" olarak belirtilmesi bu interface i implement eden bir class olması gerektiğini gösterir.
        "new()" is new anahtar kelimesi ile kullanılabilecek bir yapıya sahip olması gerektiğini gösterir.*/
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    //Hangi tip parametre kullanılacaksa implementasyon işlemi yapılırken belirtilir.
    interface IProductDal : IRepository<Product> { } //Product, implementasyon yapılan IRepository e gönderildi.
    interface ICustomerDal : IRepository<Customer>   //Customer, implementasyon yapılan IRepository e gönderildi.
    {
        void Custom();
    }

    interface IStudentrDal : IRepository<Student>   //Customer, implementasyon yapılan IRepository e gönderildi.
    {

    }
    class ProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    class CustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Custom()
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
