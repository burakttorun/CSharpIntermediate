using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void StockControl();
    class Product
    {
        //belirlenen delegate tipinde bir even tanımlandı.
        public event StockControl StockControlEvent;
        private int _stock;
        public Product(int stock)
        {
            _stock = stock;
        }

       
        public string ProductName { get; set; }
       
        public int Stock
        {
            get
            {
                return _stock;
            }


            set
            {
                _stock = value;
                //productın evente abone olup olmadığı kontrol edildi.
                if (value <= 15 && StockControlEvent != null)
                {
                    StockControlEvent();//event çalıştırıldı.

                }
            }
        }

        public void SellProduct(int amount)
        {
            Stock -= amount;
            Console.WriteLine("{0} amount: {1}",ProductName,Stock);
        }


    }
}
