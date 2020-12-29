using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList(); //veri tabanındaki tabloda yer alan veriler forma aktarılır.

            }
        }

        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product); //oluşturulan var entity contextle bağlantı kurup gönderilen parametreyi karşılaştırılır.
                entity.State = System.Data.Entity.EntityState.Added;//EntityState de yer alan ekleme fonksiyonu çalıştırılır.
                context.SaveChanges(); //değişiklikler kaydedilir.

            }
        }

        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Modified;//EntityState de yer alan güncelleme fonksiyonu çalıştırılır.
                context.SaveChanges();

            }
        }
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Deleted;//EntityState de yer alan silme fonksiyonu çalıştırılır.
                context.SaveChanges();

            }
        }
    }
}
