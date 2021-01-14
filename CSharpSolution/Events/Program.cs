using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Product hardDisk = new Product(50);
            hardDisk.ProductName = "Hard Disk";
            Product mobilePhone = new Product(50);
            mobilePhone.ProductName = "Mobile Phone";

            // istenilen productın evente abone olması.
            mobilePhone.StockControlEvent += MobilePhone_StockControlEvent;


            for (int i = 0; i < 5; i++)
            {
                hardDisk.SellProduct(10);
                mobilePhone.SellProduct(10);
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        //abone olan product için yapılacak olan eylem.
        private static void MobilePhone_StockControlEvent()
        {
            Console.WriteLine("Mobile Phone amount is almost over!");
        }
    }
}
