using CSProjeDemo1.Entities.Abstract;
using CSProjeDemo1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Entities.Concrete
{
    public class Kutuphane
    {
        private List<Kitap> Kitaplar { get; set; }
        private List<Uye> Uyeler { get; set; }

        public Kutuphane()
        {
            Kitaplar = new List<Kitap>();
            Uyeler = new List<Uye>();
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }

        public void UyeEkle(Uye uye)
        {
            Uyeler.Add(uye);
        }

        public List<Kitap> TumKitaplariGetir()
        {
            return Kitaplar;
        }

        public List<Uye> TumUyeleriGetir()
        {
            return Uyeler;
        }

        public List<Kitap> OduncAlinabilirKitaplariGetir()
        {
            return Kitaplar.FindAll(k => k.Durum == Durum.OduncAlinabilir);
        }

        public void KitapDurumunuGuncelle(Kitap kitap, Durum durum)
        {
            kitap.Durum = durum;
        }

        public void UyeKitaplariniGoruntule(Uye uye)
        {
            foreach (var kitap in uye.OduncKitaplar)
            {
                // Uye'nin ödünç aldığı kitapları görüntüle
            }
        }

        public int OduncAlinanKitapSayisi()
        {
            return Kitaplar.FindAll(k => k.Durum == Durum.OduncVerildi).Count;
        }

        public int UyeSayisi()
        {
            return Uyeler.Count;
        }

    }
}
