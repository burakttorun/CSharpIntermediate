using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleArrayList();
            // SimpleTypeSafe();
            // TypeClassSafeList();

            CollectionMethods();

            Console.ReadLine();
        }

        private static void CollectionMethods()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer{id = 1 , firstName = "Burak"},
                new Customer{id = 2 , firstName = "Can"},
                new Customer{id = 3 , firstName = "Ömer"}
            };
            var count = customers.Count(); //koleksiyonda yer alan parametrelerin sayısını geri döndürür.
            Console.WriteLine(count); // --> burada sonuç 3.

            customers.Clear(); //keloksiyonu tamamen temizler.
            count = customers.Count();
            Console.WriteLine(count); // burada sonuç 0.


            customers.AddRange(new Customer[2] //koleksiyona birden fazla parametre eklerken kullanılır.
            {
              new Customer{id = 4 , firstName = "Ali"},
              new Customer{id = 5 , firstName = "Börü"}
            });
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.firstName);
            }
            Customer customer2 = new Customer { id = 6, firstName = "Gök" };
            customers.Add(customer2); //koleksiyona ekleme yapar.

            bool compare = customers.Contains(customer2); //verilen parametrenin koleksiyonda yer alıp almadığını kontrol eder.
            Console.WriteLine(compare);

            Console.WriteLine(customers.IndexOf(customer2));//verilen parametrenin koleksiyonda kaçıncı indexte olduğunu kontrol eder.

            Console.WriteLine(customers.LastIndexOf(customer2)); //verilen parametrenin koleksiyonda yer alıp almadığını tersten kontrol eder.

            customers.Insert(0, customer2);//koleksiyonda istenilenindexe parametre ekler.
            foreach (var customer in customers)
                Console.WriteLine(customer.firstName);

            customers.Remove(customer2); //verilen parametreyi koleksiyonda arar ilk bulduğu indexte yer alanı siler.
            foreach (var customer in customers)
                Console.WriteLine(customer.firstName);

            customers.RemoveAll(c => c.firstName == "Börü"); //verilen parametreye göre koleksiyonda yer alan bütün "firstName = "Börü"" olan verileri siler.
            foreach (var customer in customers)
                Console.WriteLine(customer.firstName);
        }

        private static void TypeClassSafeList()
        {
            List<Customer> customers = new List<Customer>() // farklı tarz atamalara örnek.
            {
                new Customer(){id=3,firstName="Ali"},
                new Customer(){id=4,firstName="Osman"}
            };

            customers.Add(new Customer() { id = 1, firstName = "Burak" });
            customers.Add(new Customer() { firstName = "Can", id = 2 });

            foreach (var customer in customers)
            {
                Console.WriteLine("{0} : {1}", customer.id, customer.firstName);
            }
        }

        private static void SimpleTypeSafe()
        {
            List<string> cities = new List<string>();// Bu tip koleksiyon ise tip güvenli koleksiyona örnektir.

            cities.Add("Bartın");
            //cities.Add(1);->> Bu tarz bir kullanımda hata verecektir.
            cities.Add("Karabük");

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

        }

        private static void SimpleArrayList()
        {
            ArrayList cities = new ArrayList(); // Koleksiyonlar herhangi bir sınırlamadan bizi kurtaran kullanışlı bir formattır. 
            cities.Add("Ankara");
            cities.Add("İstanbul");
            cities.Add(1);//ayrıca bu tip kullanışlarda tip sınırlaması yoktur.

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

        }
    }

    class Customer
    {
        public int id { get; set; }
        public string firstName { get; set; }
    }
}
