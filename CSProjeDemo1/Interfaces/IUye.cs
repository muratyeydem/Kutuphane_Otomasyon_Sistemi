using CSProjeDemo1.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Interfaces
{
    public interface IUye
    {
        string Ad { get; set; }
        string Soyad { get; set; }
        int UyeNo { get; set; }
        List<Kitap> OduncKitaplarIdListesi { get; set; }

        void KitapOduncAl(Kitap kitap);
        void KitapIadeEt(Kitap kitap);
    }
}
