using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    //delegate ler metot tutan yapılardır. Eklenecek metodun geri dönüş tipine ve tutacağı parametreye göre tanımlanır.
    public delegate void DelegateMessenger();
    public delegate void DelegateMath(int s1, int s2);
    public delegate int DelegateCalculate(int s1, int s2);

    class Program
    {
        static int result;

        static void Main(string[] args)
        {
            //DelegateDemo();
            //ActionDemo();
            //FuncDemo();
            DelegateTest();
            Console.ReadLine();
        }

        private static void DelegateTest()
        {
            CustomerManager customerManager = new CustomerManager();
            Matematik matematik = new Matematik();
            DelegateMessenger delegateMessenger = customerManager.SendMessage;

            matematik.TestDelegate(delegateMessenger);
        }

        private static void FuncDemo()
        {
            Matematik matematik = new Matematik();
            Func<int, int, int> func = matematik.Carp;
            Console.WriteLine(func.Invoke(4, 5));

            Func<int> randomNumber = delegate ()
            {
                var random = new Random();
                int randomNum = random.Next(1, 20);
                return randomNum;
            };
            Console.WriteLine(randomNumber.Invoke());

            DelegateCalculate delegateCalculate = matematik.Bol;
        }

        private static void ActionDemo()
        {
            CustomerManager customerManager = new CustomerManager();
            Matematik matematik = new Matematik();

            //Oluşturulan metoda void geri dönüş tipinde herhangi bir parametre almayan bir metot gönderildi.
            matematik.Calculater(customerManager.SendMessage);

            //Oluşturulan actiona void geri dönüş tipinde herhangi bir parametre almayan bir metot atandı.
            Action action = customerManager.ShowAlert;
            matematik.Calculater(action);//Oluşturulan action Calculater a parametre olarak gönderildi.

        }

        private static void DelegateDemo()
        {
            CustomerManager customerManager = new CustomerManager();//CustomerManeger classından nesne oluşturuldu.
            DelegateMessenger delegateMessenger = customerManager.SendMessage;//Bu nesneye ait metotlar oluşturulan delegateye atandı.
            delegateMessenger += customerManager.ShowAlert;//delegate ye metot eklendi.
            delegateMessenger(); //delegate aktif hale getirildi.


            Matematik matematikIslem = new Matematik();
            DelegateMath delegateMath = matematikIslem.Topla;
            delegateMath += matematikIslem.Cikarma;
            delegateMath(4, 3);


            DelegateCalculate delegateCalculate = matematikIslem.Bol;
            result = delegateCalculate(5, 3);
            Console.WriteLine(result);
            delegateCalculate += matematikIslem.Carp;
            Console.WriteLine(delegateCalculate(result, 3));
        }
    }

    public class CustomerManager
    {

        public void SendMessage()
        {
            Console.WriteLine("Hello");
        }
        public void ShowAlert()
        {
            Console.WriteLine("Be Carefull!");
        }

    }

    public class Matematik
    {

        public void Topla(int sayi1, int sayi2)
        {
            Console.WriteLine("Sonuc: " + (sayi1 + sayi2));
        }
        public void Cikarma(int sayi1, int sayi2)
        {
            Console.WriteLine("Sonuc: " + (sayi1 - sayi2));
        }
        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
        public int Bol(int sayi1, int sayi2)
        {
            return sayi1 / sayi2;
        }

        public void Calculater(Action action) // Action void geri dönüş tipine sahip herhangi bir parametre almayan metotları tutar.
        {
            var random = new Random();
            int randomNumber = random.Next(1, 20);

            if (randomNumber < 10)
            {
                action.Invoke();
            }

            Thread.Sleep(1000);//Programı 1 sn geciktirir.
        }

        public void TestDelegate(DelegateMessenger action) // Action void geri dönüş tipine sahip herhangi bir parametre almayan metotları tutar.
        {    
                action.Invoke();
            
        }


    }
}
