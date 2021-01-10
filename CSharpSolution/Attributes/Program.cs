using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerDal _customerDal = new CustomerDal();
            _customerDal.Add(new Customer { id = 1, firstName = "Burak", lastName = "Torun", age = 25 });

            Console.ReadLine();
        }
    }
    //Burada yer alan attributeler bizim tarafımızdan belirlenip içeriklerinin doldurulması reflection ile işlenecektir.
    [ToTable("Customers")]//Hangi tabloyla bağlantılı olduğunu gösteren bir attribute.
    [ToTable("TblCustomers")]
    class Customer
    {
        [RequiredProperty]    // bu parametrenin doldurulmasının zorunlu olduğunun belirtilmesi için oluşturulan bir attribute.
        public int id { get; set; }
        [RequiredProperty]
        public string firstName { get; set; }
        [RequiredProperty]
        public string lastName { get; set; }
        [RequiredProperty]
        public int age { get; set; }
    }

    class CustomerDal
    {
        //Hazır bir attribute olup kullanıcıya bu methodun eski olduğu bilgisini verir.
        [Obsolete("Dont use Add, instead use AddNew Method!")]
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3}",customer.id,customer.firstName,customer.lastName,customer.age);

        } public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2}",customer.id,customer.firstName,customer.lastName);
        }


    }
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]//Burada iste birden fazla kullanıma örnek verilmiştir.
    class RequiredPropertyAttribute : Attribute // Attributeler bu şekilde tanımlanmalıdır ve "Attribute" clasından miras almalıdır.
    {

    }
    /*Burada ise oluşturulan attribute lere de attribute eklenebilir."AttributeTargets" hangi tiplere uygulanabileceğini gösterirken
   "AllowMultiple" ise çoklu kullanıma izin olup olmadığını kontrol eder.  */
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =true)]
    class ToTableAttribute : Attribute
    {
        string _toTable;

        public ToTableAttribute(string ToTable)
        {
            _toTable = ToTable;
        }
    }
}
