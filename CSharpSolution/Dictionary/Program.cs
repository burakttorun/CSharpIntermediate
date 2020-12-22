using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(); //key,value prensibine göre çalışır.

            dictionary.Add("book", "kitap");
            dictionary.Add("table", "tablo");
            dictionary.Add("computer", "bilgisayar"); //dictionaty e ekleme yapmak için kullanılır.

            foreach (var item in dictionary)
            {
                Console.WriteLine(item);//tüm dictionary i yazar.
                Console.WriteLine(item.Key);// sadece anahtarları yazar.
                Console.WriteLine(item.Value);// sadece değerleri yazar.            
            }
            Console.WriteLine(dictionary.ContainsKey("book")); //verilen string için anahtar kelimelerde karşılaştırma yapar.
            Console.WriteLine(dictionary.ContainsValue("top")); //verilen string için value kelimelerde karşılaştırma yapar.

            Console.ReadLine();
        }
    }
}
