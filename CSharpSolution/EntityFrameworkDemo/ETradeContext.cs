using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ETradeContext: DbContext //Veri tabanına erişmek için kullanılan bir class oluşturulur.
    {
        
        public DbSet<Product> Products { get; set; } //veri tabanında hangi tabloyla bağlantı kurulacaksa o tablo "DbSet<>" içerisinde çağrılır.
    }
}
