using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[3] {
               
                new Person
                {
                    firstName="Burak"
                },

                new Student
                {
                    firstName="Can"
                },
                new Customer
                {
                    firstName="Ömer"
                }
            };

            foreach (var person in people)
            {
                Console.WriteLine(person.firstName);
            }

            Console.ReadLine();
        }
        
    }
    //Ata class oluşturuldu ve bu class kendisinden nesne üretilebilecek bir yapıya sahip.
    class Person
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    /*Person classından miras alan bir class oluşturuldu. Bu class kendi parametreleri ve metotları hariç miras aldığı classta
    yer alan parametre ve metotları kendi bünyesinde gibi kullanabilir.*/
    class Customer : Person
    {
        public string city { get; set; }
    }

    // bir class sadece bir classtan miras alabilir!.
    class Student : Person
    {
        public string department { get; set; }
    }
}
