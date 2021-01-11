using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    class ProductDal
    {
        //Veri tabanıyla bağlantı sağlayacak olan nesne oluşturuldu.
        SqlConnection _connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=ETrade;integrated security=true");

        public List<Product> GetAll()
        {
            ConnectionControl();
            //serverla iletişim kurup veri işlemi yapabilmek için "Sql" dili kullanılır.Bu kodu çalıştırabilmek için kullanılan sınıf.
            SqlCommand command = new SqlCommand("Select * from Products", _connection);//-->string içinde yer alan kod ile bağlantı yap anlamına gelir.
            SqlDataReader reader = command.ExecuteReader();//"ExecuteReader" metodu commend i çalıştırır ve geriye SqlDataReader döndürür.

            List<Product> products = new List<Product>(); //Liste oluşturuldu.

            while (reader.Read())//reader in veri okuyabildiği süre boyunca çalıştırılması sağlandı.
            {
                Product product = new Product() //yeni bir nesne oluşturulup readerdan gelen bütün değerler nesneye aktarıldı.
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    StockAmount = Convert.ToInt32(reader["StockAmount"])
                };
                products.Add(product);//verilerin yazıldığı nesne listeye eklendi.
            }

            reader.Close(); //readerin kapanması
            _connection.Close();//bağlantının kapanması
            return products;

        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)//bağlantının durumu kontrol edildi.
            {
                _connection.Open();//bağlantı açıldı.
            }
        }

        public DataTable GetAll2()
        {
            ConnectionControl();
            //serverla iletişim kurup veri işlemi yapabilmek için "Sql" dili kullanılır.Bu kodu çalıştırabilmek için kullanılan sınıf.
            SqlCommand command = new SqlCommand("Select * from Products", _connection);//-->string içinde yer alan kod ile bağlantı yap anlamına gelir.
            SqlDataReader reader = command.ExecuteReader();//"ExecuteReader" metodu commend i çalıştırır ve geriye SqlDataReader döndürür.
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);//IDataReader tipinde bir parametre alır ve onu yükler.
            reader.Close(); //readerin kapanması
            _connection.Close();//bağlantının kapanması
            return dataTable;

        }
        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand();
            command.Connection = _connection; //sql in komutuyla server arasında bağlantı kuruldu.
            //sql komutunun texti oluşturuldu.
            command.CommandText = "Insert into Products(name,unitPrice,stockAmount) Values(@name,@unitPrice,@stockAmount)";
            //parametreler atandı.
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);

            command.ExecuteNonQuery();//Veri tabanına yükleme yapıldı.

            _connection.Close();
        }
        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand();
            command.Connection = _connection; //sql in komutuyla server arasında bağlantı kuruldu.
            //sql komutunun texti oluşturuldu.
            command.CommandText = "Update Products Set Name=@name, UnitPrice=@unitPrice, StockAmount= @stockAmount where Id=@Id";
            //parametreler atandı.
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);

            command.ExecuteNonQuery();//Veri tabanına yükleme yapıldı.

            _connection.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand();
            command.Connection = _connection; //sql in komutuyla server arasında bağlantı kuruldu.
            //sql komutunun texti oluşturuldu.
            command.CommandText = "Delete from Products where Id=@id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();//Veri tabanına yükleme yapıldı.

            _connection.Close();
        }
    }
}
