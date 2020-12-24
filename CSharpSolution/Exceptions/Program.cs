using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleExceptionHandling();
            //UseExceptionClass();
            // UseExceptionKind();
            //ThrowException();

            HandleException(() =>  //burada bir Delegasyon işlemi yapılır ve bir metoda parametre olarak başka bir metot gönderilir.
            {
                Find();
            });

            Console.ReadLine();
        }

        private static void HandleException(Action action) // Action Delegasyonu yapılır bu void bir yapıdır herhangi bir değer döndürmez.
        {
            try
            {
                action.Invoke();// parametre olarak gönderilen metodu çalıştırır.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void ThrowException()
        {
            try
            {
                Find();
            }
            catch (RecordNotFoundException exception) //bizim tarafımızdan gönderilen hata burada yakalandı.
            {

                Console.WriteLine(exception.Message);// burada ise ekrana basıldı.
            }
        }

        private static void Find()
        {
            List<string> firstNames = new List<string> { "Burak", "Muhammed", "Ali" };

            if (!firstNames.Contains("Ömer")) //oluşturulan metotda hata oluşturacak durum belirlendi.
            {
                throw new RecordNotFoundException("Record is not found"); //hata olması durumunda parametrede içerisinde verilen mesaj gönderildi.
            }
            else
                Console.WriteLine("Record found.");
        }

        private static void UseExceptionKind()
        {
            try
            {
                string[] firstNames = new string[3] { "Burak", "Muhammed", "Ali" };
                firstNames[3] = "Can";
            }
            catch (DivideByZeroException) //burada "catch" verilen parametrenin hatanın çeşitine karşılık geldiğinde bloktaki kodları çalıştırır.
            {

                Console.WriteLine("Sıfıra bölme hatası");
            }
            catch(Exception exception) // hatanın belirtilen çeşitleri karşılamadığı durumda bu blok çalışacaktır.
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void UseExceptionClass()
        {
            try
            {
                string[] firstNames = new string[3] { "Burak", "Muhammed", "Ali" };
                firstNames[3] = "Can";
            }
            catch (Exception exception) // bu kullanımda ise tanımlanmış hatalardan faydalanılır.
            {
                Console.WriteLine(exception.Message);//tanımlı olan hata çeşiti yazdırılır.

            }
        }

        private static void SimpleExceptionHandling()
        {
            try //hata oluşturabilecek bir kod bloğu olduğunda bu kod bloğunu "try" parantez blokları içerisine yazarız.
            {
                string[] firstNames = new string[3] { "Burak", "Muhammed", "Ali" };
                firstNames[3] = "Can";
            }
            catch//"catch" bloğunda ise hata alındığıda yapılacak işlemler yer alır. 
            {
                Console.WriteLine("Exception!");

            }
        }
    }
}
