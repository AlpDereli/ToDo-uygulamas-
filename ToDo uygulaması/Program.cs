// See https://aka.ms/new-console-template for more information
List<kart> ToDOLine = new List<kart>();
List<kart> InProgressLine = new List<kart>();
List<kart> DoneLine = new List<kart>();
List<kisi> calisanlar = new List<kisi>();
kisi kisi1 = new kisi();
kisi1.ad = "Alp";
kisi1.ID = 1;
calisanlar.Add(kisi1);
kisi kisi2 = new kisi();
kisi2.ad = "Yusuf";
kisi2.ID = 2;
calisanlar.Add(kisi2);
bool b = true;
islemler islem = new islemler();
while (b)
{
    Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
    Console.WriteLine("*******************************************");
    Console.WriteLine("(1) Board Listelemek");
    Console.WriteLine("(2) Board'a Kart Eklemek");
    Console.WriteLine("(3) Board'dan Kart Silmek");
    Console.WriteLine("(4) Kart Taşımak");
    Console.WriteLine("(0) Çıkış Yapmak");
    int secim = int.Parse(Console.ReadLine());
    if (secim ==1)
    {
        islem.listele(ToDOLine, InProgressLine, DoneLine);
    }
    if (secim ==2) 
    {
        islem.kartekleme(calisanlar, ToDOLine);
    }
    if (secim ==3) 
    
    {
        islem.kartsil(ToDOLine, InProgressLine, DoneLine);
    }
    if (secim ==4) 
    {
        islem.kartasi(ToDOLine, InProgressLine, DoneLine);
    }
    if (secim == 0)
    {
        b = false;
    }
}





enum büyüklük
{
    XS = 1,
    S,
    M,
    L,
    XL
}
class kart
{
    public string baslik;
    public string icerk;
    public string atanankisi;
    public büyüklük b;
}

class kisi
{
    public string ad;
    public int ID;
}


class islemler
{
    public void listele(List<kart> ToDoLine, List<kart> InProgressLine,List<kart> DoneLine)
    {
        Console.WriteLine("TODO Line");
        Console.WriteLine("************************");
        if (ToDoLine.Count == 0)
        {
            Console.WriteLine("~ BOŞ ~");
        }
        foreach (kart kart in ToDoLine)
        {
                Console.WriteLine("Başlık      :" + kart.baslik);
                Console.WriteLine("İçerik      :" + kart.icerk);
                Console.WriteLine("Atanan Kişi :" + kart.atanankisi);
                Console.WriteLine("Büyüklük    :" + kart.b);
                Console.WriteLine("-");
        }
        Console.WriteLine("IN PROGRESS Line");
        Console.WriteLine("************************");
        if (InProgressLine.Count == 0)
        {
            Console.WriteLine("~ BOŞ ~");
        }
        foreach (kart kart in InProgressLine)
        {
                Console.WriteLine("Başlık      :" + kart.baslik);
                Console.WriteLine("İçerik      :" + kart.icerk);
                Console.WriteLine("Atanan Kişi :" + kart.atanankisi);
                Console.WriteLine("Büyüklük    :" + kart.b);
                Console.WriteLine("-");
        }
        Console.WriteLine("DONE Line");
        Console.WriteLine("************************");
        if (DoneLine.Count == 0)
        {
            Console.WriteLine("~ BOŞ ~");
        }
        foreach (kart kart in DoneLine)
        {
                Console.WriteLine("Başlık      :" + kart.baslik);
                Console.WriteLine("İçerik      :" + kart.icerk);
                Console.WriteLine("Atanan Kişi :" + kart.atanankisi);
                Console.WriteLine("Büyüklük    :" + kart.b);
                Console.WriteLine("-");
        }
    }
    public void kartekleme(List<kisi> calisanlar,List<kart> todoline)
    {
        kart kart = new kart();
        Console.WriteLine("Başlık Giriniz                                  :");
        string kadı = Console.ReadLine();
        kart.baslik = kadı;
        Console.WriteLine("İçerik Giriniz                                  :");
        string içerik = Console.ReadLine();
        kart.icerk = içerik;
        Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
        int boy = int.Parse(Console.ReadLine());
        if (boy == (int)büyüklük.XS)
        {
            kart.b = büyüklük.XS;
        }
        if (boy == (int)büyüklük.S)
        {
            kart.b = büyüklük.S;
        }
        if (boy == (int)büyüklük.M)
        {
            kart.b = büyüklük.M;
        }
        if (boy == (int)büyüklük.L)
        {
            kart.b = büyüklük.L;
        }
        if (boy == (int)büyüklük.XL)
        {
            kart.b = büyüklük.XL;
        }
        Console.WriteLine("Kişi Seçiniz                                    :");
        int id = int.Parse(Console.ReadLine());
        foreach (kisi insan in calisanlar)
        {
            if (insan.ID == id)
            {
                kart.atanankisi = insan.ad;
            }
        }
        todoline.Add(kart);
    }
    public void kartsil(List<kart> ToDOLine, List<kart> InProgressLine, List<kart> DoneLine)
    {
        Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
        Console.WriteLine("Lütfen kart başlığını yazınız:  ");
        string bas = Console.ReadLine();
        int kontrol = 0;
        for (int i = 0; i < ToDOLine.Count; i++)
        {
            if (ToDOLine[i].baslik==bas)
            {
                kontrol++;
                ToDOLine.Remove(ToDOLine[i]);
            }
        }
        for (int i = 0; i < InProgressLine.Count; i++)
        {
            if (InProgressLine[i].baslik == bas)
            {
                kontrol++;
                InProgressLine.Remove(InProgressLine[i]);
            }
        }
        for (int i = 0; i < DoneLine.Count; i++)
        {
            if (DoneLine[i].baslik == bas)
            {
                kontrol++;
                DoneLine.Remove(DoneLine[i]);
            }
        }



        if (kontrol == 0)
        {
            Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
            int sec = int.Parse(Console.ReadLine());
            if (sec == 2)
            {
                kartsil(ToDOLine,InProgressLine, DoneLine);
            }
        }
    }
    public void kartasi(List<kart> ToDoLine, List<kart> InProgressLine, List<kart> DoneLine) 
    {
        List<kart> bulunankart = new List<kart>();
        Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
        Console.WriteLine("Lütfen kart başlığını yazınız:");
        string bas = Console.ReadLine();
        int kontrol = 0;
        string line = "";
        foreach (kart kart in ToDoLine)
        {
            if ((bas == kart.baslik))
            {
                kontrol ++;
                bulunankart.Add(kart);
                line = "ToDo"; 
            }
        }
        foreach (kart kart in InProgressLine)
        {
            if (bas == kart.baslik)
            {
                kontrol ++;
                bulunankart.Add(kart);
                line = "In Progress";
            }
        }
        foreach (kart kart in DoneLine)
        {
            if (bas == kart.baslik)
            {
                kontrol ++;
                bulunankart.Add(kart);
                line = "Done";
            }
        }
        if (kontrol == 0)
        {
            Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Taşımayı sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
            int sec = int.Parse(Console.ReadLine());
            if (sec == 2)
            {
                kartasi(ToDoLine, InProgressLine, DoneLine);
            }
        }
        else
        {
            Console.WriteLine("Bulunan Kart Bilgileri:");
            Console.WriteLine("**************************************");
            Console.WriteLine("Başlık: " + bulunankart[0].baslik+ " İçerik: " + bulunankart[0].icerk + " Atanan Kişi: " + bulunankart[0].atanankisi +" Büyüklük: " + bulunankart[0].b + " Line: " + line );
            Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: (1) TODO (2) IN PROGRESS (3) DONE");
            int linesec = int.Parse(Console.ReadLine());
            if (linesec <1 || linesec > 3)
            {
                Console.WriteLine("Hatalı bir seçim yaptınız!");
            }
            else
            {
                kart tkart = new kart();
                tkart = bulunankart[0];
                if (linesec == 1)
                {
                    if (line == "In Progress")
                    {
                        InProgressLine.Remove(bulunankart[0]);
                        ToDoLine.Add(tkart);
                    }
                    if (line == "Done")
                    {
                        DoneLine.Remove(bulunankart[0]);
                        ToDoLine.Add(tkart);
                    }
                }
                if (linesec == 2)
                {
                    if (line == "ToDo")
                    {
                        ToDoLine.Remove(bulunankart[0]);
                        InProgressLine.Add(tkart);
                    }
                    if (line == "Done")
                    {
                        DoneLine.Remove(bulunankart[0]);
                        InProgressLine.Add(tkart) ;
                    }
                }
                if (linesec == 3)
                {
                    if (line == "ToDo")
                    {
                        ToDoLine.Remove(bulunankart[0]);
                        DoneLine.Add(tkart);
                    }
                    if (line == "In Progress")
                    {
                        InProgressLine.Remove(bulunankart[0]);
                        DoneLine.Add(tkart);
                    }
                }
            }
        }
        listele(ToDoLine, InProgressLine, DoneLine);
    }
}