using System;

abstract class BaseMakine
{
    //ortak özellikler
    public DateTime UretimTarihi { get; set; }
    public string SeriNo { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public string IsletimSistemi { get; set; }

    //constructor
    public BaseMakine()
    {
        UretimTarihi = DateTime.Now; 
    }

    //ortak bilgileri yazdıran metot
    public virtual void BilgileriYazdir()
    {
        Console.WriteLine($"Üretim Tarihi: {UretimTarihi}");
        Console.WriteLine($"Seri Numarası: {SeriNo}");
        Console.WriteLine($"Ad: {Ad}");
        Console.WriteLine($"Açıklama: {Aciklama}");
        Console.WriteLine($"İşletim Sistemi: {IsletimSistemi}");
    }

    //abstract metot
    public abstract void UrunAdiGetir();
}

class Telefon : BaseMakine
{
    public bool TrLisansli { get; set; }

    //telefon'a ait BilgileriYazdir metodu
    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir(); //base sınıftan ortak bilgileri alma kısmı
        Console.WriteLine($"Türkçe Lisanslı: {(TrLisansli ? "Evet" : "Hayır")}");
    }

    //telefon'un adıyla ilgili metot
    public override void UrunAdiGetir()
    {
        Console.WriteLine($"Telefonunuzun adı ---> {Ad}");
    }
}

class Bilgisayar : BaseMakine
{
    public int UsbGirisSayisi { get; set; }
    public bool Bluetooth { get; set; }

    //bilgisayar'a ait BilgileriYazdir metodu
    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir(); //base sınıftan ortak bilgileri al
        Console.WriteLine($"USB Giriş Sayısı: {UsbGirisSayisi}");
        Console.WriteLine($"Bluetooth: {(Bluetooth ? "Evet" : "Hayır")}");
    }

    //bilgisayarın adıyla ilgili metot
    public override void UrunAdiGetir()
    {
        Console.WriteLine($"Bilgisayarınızın adı ---> {Ad}");
    }

    //encapsulation örneği: USB giriş sayısının geçerli olmasını sağlamak için olan 
    public void SetUsbGirisSayisi(int sayi)
    {
        if (sayi == 2 || sayi == 4)
        {
            UsbGirisSayisi = sayi;
        }
        else
        {
            Console.WriteLine("Geçersiz USB Giriş Sayısı! (-1 atanıyor)");
            UsbGirisSayisi = -1;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool devamEt = true;
        while (devamEt)
        {
            Console.WriteLine("Telefon üretmek için 1'e, Bilgisayar üretmek için 2'ye basınız.");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Telefon telefon = new Telefon();
                Console.Write("Telefonun Seri Numarasını girin: ");
                telefon.SeriNo = Console.ReadLine();
                Console.Write("Telefonun adını girin: ");
                telefon.Ad = Console.ReadLine();
                Console.Write("Telefonun açıklamasını girin: ");
                telefon.Aciklama = Console.ReadLine();
                Console.Write("Telefonun işletim sistemini girin: ");
                telefon.IsletimSistemi = Console.ReadLine();
                Console.Write("Türkçe lisanslı mı? (Evet/Hayır): ");
                telefon.TrLisansli = Console.ReadLine().ToLower() == "evet";

                telefon.BilgileriYazdir();
                telefon.UrunAdiGetir();
            }
            else if (secim == "2")
            {
                Bilgisayar bilgisayar = new Bilgisayar();
                Console.Write("Bilgisayarın Seri Numarasını girin: ");
                bilgisayar.SeriNo = Console.ReadLine();
                Console.Write("Bilgisayarın adını girin: ");
                bilgisayar.Ad = Console.ReadLine();
                Console.Write("Bilgisayarın açıklamasını girin: ");
                bilgisayar.Aciklama = Console.ReadLine();
                Console.Write("Bilgisayarın işletim sistemini girin: ");
                bilgisayar.IsletimSistemi = Console.ReadLine();

                //USB giriş sayısını kullanıcıdan al
                int usbSayisi;
                do
                {
                    Console.Write("USB Giriş Sayısını girin (2 ya da 4): ");
                } while (!int.TryParse(Console.ReadLine(), out usbSayisi) || (usbSayisi != 2 && usbSayisi != 4));

                bilgisayar.SetUsbGirisSayisi(usbSayisi);

                Console.Write("Bluetooth var mı? (Evet/Hayır): ");
                bilgisayar.Bluetooth = Console.ReadLine().ToLower() == "evet";

                bilgisayar.BilgileriYazdir();
                bilgisayar.UrunAdiGetir();
            }
            else
            {
                Console.WriteLine("Geçersiz seçenek!");
                continue;
            }

            Console.WriteLine("Başka bir ürün üretmek ister misiniz? (Evet/Hayır)");
            devamEt = Console.ReadLine().ToLower() == "evet";
        }

        Console.WriteLine("İyi günler!");
    }
}
