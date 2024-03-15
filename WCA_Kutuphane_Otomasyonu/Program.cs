using CSProjeDemo1.Entities.Abstract;
using CSProjeDemo1.Entities.Concrete;
using CSProjeDemo1.Enums;
using CSProjeDemo1.Interfaces;
using CSProjeDemo1.Services;
using System;

class Program
{
    static KutuphaneService kutuphane= new KutuphaneService(new Kutuphane());
    static void Main(string[] args)
    {
        KitapBilim kitap1 = new KitapBilim { ISBN = "123456789", Baslik = "Bilim Kitabı", Yazar = "Bilimci", YayinYili = 2020, Durum = Durum.OduncAlinabilir };
        KitapRoman kitap2 = new KitapRoman { ISBN = "987654321", Baslik = "Roman Kitabı", Yazar = "Romancı", YayinYili = 2019, Durum = Durum.OduncAlinabilir };
        KitapTarih kitap3 = new KitapTarih { ISBN = "565465656", Baslik = "Tarih Kitabı", Yazar = "Tarihci", YayinYili = 2018, Durum = Durum.OduncAlinabilir };

        Uye uye1 = new Uye { Ad = "Murat", Soyad = "Yeydem", UyeNo = 1 };
        Uye uye2 = new Uye { Ad = "Ayaz", Soyad = "Kaya", UyeNo = 2 };


        kutuphane.KitapEkle(kitap1);
        kutuphane.KitapEkle(kitap2);
        kutuphane.KitapEkle(kitap3);
        kutuphane.UyeEkle(uye1);
        kutuphane.UyeEkle(uye2);



        bool devam = true;
        while (devam)
        {
            Console.WriteLine("1. Kitap Ödünç Alma");
            Console.WriteLine("2. Kitap İade Etme");
            Console.WriteLine("3. Kütüphane Durumunu Görüntüle");
            Console.WriteLine("4. Çıkış");

            Console.Write("Seçiminizi yapınız: ");
            int secim = Convert.ToInt32(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    KitapOduncAl();
                    break;
                case 2:
                    KitapIadeEt();
                    break;
                case 3:
                    KutuphaneDurumuGoruntule();
                    break;
                case 4:
                    devam = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void KitapOduncAl()
    {
        Console.Write("Üye adı: ");
        string ad = Console.ReadLine();
        Console.Write("Üye soyadı: ");
        string soyad = Console.ReadLine();
        Console.Write("Kitap adı: ");
        string kitapAdi = Console.ReadLine();

        IUye uye = new Uye { Ad = ad, Soyad = soyad };
        Kitap kitap = kutuphane.TumKitaplariGetir().Find(k => k.Baslik == kitapAdi);

        if (kitap != null)
        {
            uye.KitapOduncAl(kitap);
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.");
        }
    }

    static void KitapIadeEt()
    {
        Console.Write("Üye adı: ");
        string ad = Console.ReadLine();
        Console.Write("Üye soyadı: ");
        string soyad = Console.ReadLine();
        Console.Write("Kitap adı: ");
        string kitapAdi = Console.ReadLine();

        IUye uye = new Uye { Ad = ad, Soyad = soyad };
        Kitap kitap = kutuphane.TumKitaplariGetir().Find(k => k.Baslik == kitapAdi);

        if (kitap != null)
        {
            uye.KitapIadeEt(kitap);
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.");
        }
    }

    static void KutuphaneDurumuGoruntule()
    {
        kutuphane.KütüphaneDurumunuGoruntule();
    }
}
