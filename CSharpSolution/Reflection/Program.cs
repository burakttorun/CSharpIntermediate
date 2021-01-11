using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var tip = typeof(DortIslem); //tip belirlemek için kullanılan bir yöntem.
            DortIslem dortIslem = (DortIslem)Activator.CreateInstance(tip,3,4);//Parametre olarak gönderilen tipte bir nesne oluşturuldu.
            Console.WriteLine(dortIslem.Topla(5, 7));//oluşturulan nesnenin bir metodu kullanıldı.
            dortIslem.Topla2();

            var instance = Activator.CreateInstance(tip, 7, 8);

            MethodInfo methodInfo = instance.GetType().GetMethod("Topla2"); // oluşturulan instance in çağırılan metodun bilgisi aktarıldı.
            Console.WriteLine(methodInfo.Invoke(instance,null));//aktarılan metot bilgisine göre o metot çalıştırıldı. ve parametleri gönderildi.

            Console.WriteLine("------------------------------------------------------------------");
            var methodlar = instance.GetType().GetMethods(); //belirtilen tipe ait bütün metotları listeler.
            foreach (var info in methodlar)
            {
                Console.WriteLine("Metotlar: "+ info.Name);

                foreach (var parametre in info.GetParameters())//belirtilen tipe ait metotların parametrelerini listeler.
                {
                    Console.WriteLine("Parametre: "+parametre.Name);
                }

                foreach (var attribute in info.GetCustomAttributes()) //belirtilen tipe ait bütün attributeleri listeler.
                {
                    Console.WriteLine("Attribute Name: "+attribute.GetType().Name);
                }
            }
            Console.WriteLine("------------------------------------------------------------------");

           
            Console.ReadLine();
        }
    }


    class DortIslem
    {
        private int _sayi1;
        private int _sayi2;

        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        public void Topla2()
        {
            Console.WriteLine("Sonuç: " + (_sayi1 + _sayi2));
        }
    }
}
