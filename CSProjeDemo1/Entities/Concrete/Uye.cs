using CSProjeDemo1.Entities.Abstract;
using CSProjeDemo1.Enums;
using CSProjeDemo1.Interfaces;
using System.Collections.Generic;

namespace CSProjeDemo1.Entities.Concrete
{
    public class Uye : IUye
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int UyeNo { get; set; }
        public List<Kitap>? OduncKitaplarIdListesi { get; set; }

        public Uye()
        {
            OduncKitaplarIdListesi = new List<Kitap>();
        }

        public void KitapOduncAl(Kitap kitap)
        {
            if (kitap.Durum == Durum.OduncAlinabilir)
            {
                kitap.Durum = Durum.OduncVerildi;
                OduncKitaplarIdListesi.Add(kitap); 
            }
          
        }

        public void KitapIadeEt(Kitap kitap)
        {
            if (OduncKitaplarIdListesi.Contains(kitap))
            {
                kitap.Durum = Durum.OduncAlinabilir;
                OduncKitaplarIdListesi.Remove(kitap); 
            }
        }
    }
}
