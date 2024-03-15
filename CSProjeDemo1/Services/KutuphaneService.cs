using CSProjeDemo1.Entities.Abstract;
using CSProjeDemo1.Entities.Concrete;
using CSProjeDemo1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services
{
    public class KutuphaneService
    {
        Kutuphane kutuphane;
        public KutuphaneService(Kutuphane kutuphane)
        {
            this.kutuphane = kutuphane;
        }
        public void KitapEkle(Kitap kitap)
        {
            kutuphane.Kitaplar.Add(kitap);
        }

        public void UyeEkle(Uye uye)
        {
            kutuphane.Uyeler.Add(uye);
        }

        public List<Kitap> TumKitaplariGetir()
        {
            return kutuphane.Kitaplar;
        }

        public List<Uye> TumUyeleriGetir()
        {
            return kutuphane.Uyeler;
        }

        public List<Kitap> OduncAlinabilirKitaplariGetir()
        {
            return kutuphane.Kitaplar.FindAll(k => k.Durum == Durum.OduncAlinabilir);
        }

        public void KitapDurumunuGuncelle(Kitap kitap, Durum durum)
        {
            kitap.Durum = durum;
        }

        public void UyeKitaplariniGoruntule(Uye uye)
        {
            foreach (var kitap in uye.OduncKitaplarIdListesi)
            {
                // Uye'nin ödünç aldığı kitapları görüntüle
            }
        }

        public int OduncAlinanKitapSayisi()
        {
            return kutuphane.Kitaplar.FindAll(k => k.Durum == Durum.OduncVerildi).Count;
        }

        public int UyeSayisi()
        {
            return kutuphane.Uyeler.Count;
        }
        public void KütüphaneDurumunuGoruntule()
        {
            Console.WriteLine("Kütüphane Durumu:");
            Console.WriteLine("Mevcut Kitaplar:");
            foreach (var kitap in kutuphane.Kitaplar)
            {
                Console.WriteLine(kitap.Baslik + " - " + kitap.Durum);
            }
            Console.WriteLine("\nÜyeler:");
            foreach (var uye in kutuphane.Uyeler)
            {
                Console.WriteLine(uye.Ad + " " + uye.Soyad);
                Console.WriteLine("Ödünç Aldığı Kitaplar:");
                foreach (var oduncAlinanKitap in uye.OduncKitaplarlistesi())
                {
                    Console.WriteLine("- " + oduncAlinanKitap.Baslik);
                }
                Console.WriteLine();
            }
        }
    }
}
