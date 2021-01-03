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
        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            { //parametre olarak gelen key veri tabanında sorgulanır ve eşleşen değerler geri döndürülür.
                var result = context.Products.Where(p => p.Name.Contains(key)).ToList();
                return result;

            }
        }

        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {   //parametre olarak gelen price ile veri tabanındaki UnitPrice karşılaştırılır. price a eşit veya daha yüksek veriler döndürülür. 
                var result = context.Products.Where(p => p.UnitPrice >= price).ToList();
                return result;

            }
        }
        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            using (ETradeContext context = new ETradeContext())
            {   //parametre olarak gelen key ile veri tabanındaki UnitPrice karşılaştırılır. min-max arasında yer alan veriler döndürülür. 
                var result = context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
                return result;

            }
        }

        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                // parametre olarak gelen id değerini veri tabanında arar eşleşen ilk veriyi geri döndürür.
                // var result = context.Products.FirstOrDefault(p=>p.Id ==id);
                /* parametre olarak gelen id değerini veri tabanında arar eşleşen veriyi geri döndürür.Birden fazla aynı değerle 
                uyuşan bir sonuç olduğunda hata fırlatır.*/
                var result = context.Products.SingleOrDefault(p => p.Id == id);

                return result;

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
