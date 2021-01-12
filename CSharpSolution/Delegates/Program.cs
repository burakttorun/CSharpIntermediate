using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            Console.ReadLine();
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




    }
}
