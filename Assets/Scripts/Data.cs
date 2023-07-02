using System.Linq;
using System.Collections.Generic;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    
    public BigDouble[] sectionAmounts;          // 0-Food 1-Military 2-Land 3-Material
    public BigDouble humanAmount;               // İnsan sayısı
    public BigDouble humanPower;                // İnsan üretim gücü
    public List<BigDouble> humanUpgradeLevels;  // İnsan üretim geliştirme seviyesini tutar.
    public List<BigDouble> humanUpgradeRequires;// İnsan üretim geliştirmesi için gerekli miktar
    public BigDouble gold;                      // Prestij sonucu elde edilen kaynak
    public DateTime lastOnlineTime;             // Çevrimdışı kazanç için oyundan çıkılan tarihi tutar.
    public List<List<BigDouble>> Levels;        // Sektörlerdeki geliştirmelerin seviyeleri
    public List<List<bool>> isAchieve;          // Başarımın açılıp açılmadığını tutar.
    public int[] productionMultiplier;          // Açılan başarımlardan kazanılan üretim çarpanları
    public BigDouble[] clickPower;              // Sektörlerdeki tıklama butonu üretim gücü
    public BigDouble[] prestigeUpgradeLevels;   // Prestij sonrası sektör üretimini kalıcı olarak arttıran geliştirme seviyesini tutar.
    public int notation;                        // Sayısal gösterimin seçimi için değişken
    public int notationBuyMultiplier;           // Toplu satın alımının seçimi için değişken

    public Data()
    {
        sectionAmounts = new BigDouble[] { 0, 0, 0, 0 };
        humanUpgradeLevels = new List<BigDouble>() { 0, 0, 0, 0 };
        humanUpgradeRequires = new List<BigDouble>() { 1e3, 1e3, 1e3, 1e3 };
        productionMultiplier = new int[] { 1, 1, 1, 1 };
        clickPower = new BigDouble[] { 1, 1, 1, 1 };
        prestigeUpgradeLevels = new BigDouble[] { 0, 0, 0, 0 };
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

        humanAmount = 0;
        humanPower = 1;
        
        gold = 0;
        lastOnlineTime = DateTime.Now;
        
        notation = 0;
        notationBuyMultiplier = 0;
        
    }

}
