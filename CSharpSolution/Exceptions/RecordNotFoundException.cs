using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class RecordNotFoundException : Exception //kendi özel hata durumlarımızı oluşturduğumuz class.
    {
        public RecordNotFoundException(string message) :base(message) //bu sınıfın yapıcısına gelen parametre miras alınan sınıfın yapıcısına gönderildi.
        {

        }
    }
}
