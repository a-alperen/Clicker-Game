using System.Linq;
using System.Collections.Generic;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    
    public BigDouble[] sectionAmounts;      // 0-Food 1-Military 2-Land 3-Material
    public BigDouble humanAmount;           // İnsan sayısı
    public BigDouble humanPower;            // İnsan üretim gücü
    public BigDouble gold;                  // Prestij sonucu elde edilen kaynak
    public DateTime lastOnlineTime;         // Çevrimdışı kazanç için oyundan çıkılan tarihi tutar.
    public List<List<BigDouble>> Levels;    // Sektörlerdeki geliştirmelerin seviyeleri
    public List<List<bool>> isAchieve;      // Başarımın açılıp açılmadığını tutar.
    public int[] productionMultiplier;      // Açılan başarımlardan kazanılan üretim çarpanları
    public BigDouble[] clickPower;          // Sektörlerdeki tıklama butonu üretim gücü
    public int notation;                    // Sayısal gösterimin seçimi için değişken
    public int notationBuyMultiplier;       // Toplu satın alımının seçimi için değişken
    public Data()
    {
        sectionAmounts = new BigDouble[] { 0, 0, 0, 0 }; 
        humanAmount = 0;
        gold = 0;
        lastOnlineTime = DateTime.Now;
        productionMultiplier = new int[] { 1, 1, 1, 1 };
        clickPower = new BigDouble[] { 1, 1, 1, 1 };
        humanPower = 1;
        Levels = new List<List<BigDouble>>()
        {
            new BigDouble[8].ToList(),
            new BigDouble[10].ToList(),
            new BigDouble[10].ToList(),
            new BigDouble[9].ToList()
        };
        isAchieve = new List<List<bool>>()
        {
            new bool[5].ToList(),
            new bool[5].ToList(),
            new bool[5].ToList(),
            new bool[5].ToList()
        };
        notation = 0;
        notationBuyMultiplier = 0;
    }

}
