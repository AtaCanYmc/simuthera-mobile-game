using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menumanager : MonoBehaviour
{
    public AudioClip butonBasmaSesi;
    public GameManager gManager;

    //açılış menüsü
    public GameObject acılısMenu;

    //genel menü
    public GameObject genelMenu;
    public TextMeshProUGUI skorumuz;
    public TextMeshProUGUI canımız;
    public TextMeshProUGUI finalSkor;
    public TextMeshProUGUI enYuksekSkor;

    //ayarlar menüsü
    public GameObject ayarlarMenu;
    public Slider sesBarı;

    //nasıl oynanır ekranı
    public GameObject nasılOynanırMenu;
    public GameObject ekran1;
    public GameObject ekran2;
    public GameObject ekran3;
    private int aktifEkran;

    //ölüm menüsü
    public GameObject ölumMenu;

    //mızraklar
    public Mızrak dikeyMızrak;
    public Mızrak yatayMızrak;
    public Mızrak yatayMızrak2;

    //ses ayarları
    public AudioSource sesKaynak;
    public AudioClip tusBasmaSesi;
    public GameObject mKutusu;
    public AudioClip ölmeSesi;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        //Screen.SetResolution(640, 480, true);
        gManager = FindObjectOfType<GameManager>();
        aktifEkran = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //açılış menüsü
    public void kolayOyun()
    {
        oyunZorlukAyarı(1f);
    }

    public void normalOyun()
    {
        oyunZorlukAyarı(1.5f);
    }

    public void zorOyun()
    {
        oyunZorlukAyarı(2f);
    }

    public void oyunZorlukAyarı(float zorluk)
    {
        sesKaynak.PlayOneShot(tusBasmaSesi); //ses oynatır
        dikeyMızrak.setMızrakHızı(13f * zorluk);
        yatayMızrak.setMızrakHızı(13f * zorluk);
        yatayMızrak2.setMızrakHızı(13f * zorluk);
        acılısMenu.SetActive(false);
        genelMenu.SetActive(true);
        gManager.mızrakSıklığı = Mathf.Ceil(5f / zorluk);
        gManager.canSıklığı = (int)Mathf.Ceil(14f / zorluk);
        gManager.oyunuBaslat();
        mKutusu.SetActive(true);
    }

    public void anaMenu()
    {
        SceneManager.LoadScene(0);
    }

    // genel menü
    public void skorGuncelle(int yeniSkor)
    {
        skorumuz.text = ": " + yeniSkor;
    }

    public void canGuncelle(int yeniCan)
    {
        canımız.text = ": " + yeniCan;
    }

    public void ayarlar()
    {
        if (!gManager.duraklat)
        {
            sesKaynak.PlayOneShot(tusBasmaSesi); //ses oynatır
            gManager.oyunuDurdur();
            genelMenu.SetActive(false);
            ayarlarMenu.SetActive(true);
        }
    }

    //ayarlar menüsü
    public void devam()
    {
        sesKaynak.PlayOneShot(tusBasmaSesi); //ses oynatır
        ayarlarMenu.SetActive(false);
        genelMenu.SetActive(true);
        gManager.oyunuBaslat();
    }

    public void yeniden()
    {
        SceneManager.LoadScene(20);
    }

    public void setSound()
    {
        mKutusu.GetComponent<AudioSource>().volume = sesBarı.value * 0.1f;
    }

    public void nasılOynanır()
    {
        sesKaynak.PlayOneShot(tusBasmaSesi); //ses oynatır
        ayarlarMenu.SetActive(false);
        nasılOynanırMenu.SetActive(true);
        ekran1.SetActive(true);
    }

    public void sonraki()
    {
        sesKaynak.PlayOneShot(tusBasmaSesi); //ses oynatır

        if(aktifEkran == 0)
        {
            ekran1.SetActive(false);
            ekran2.SetActive(true);
            aktifEkran = 1;
        }
        else if (aktifEkran == 1)
        {
            ekran2.SetActive(false);
            ekran3.SetActive(true);
            aktifEkran = 2;
        }
        else
        {
            ekran3.SetActive(false);
            nasılOynanırMenu.SetActive(false);
            ayarlarMenu.SetActive(true);
            aktifEkran = 0;
        }

    }

    //ölüm menüsü

    public void ölüm(int sonSkor)
    {
        sesKaynak.volume = 0.035f;
        sesKaynak.PlayOneShot(ölmeSesi); //ses oynatır
        int HighScore = PlayerPrefs.GetInt("GraveHighScore");
        string enYuksek = "En Yüksek Skor: ";
        if (sonSkor > HighScore || HighScore == 0)
        {
            enYuksek = "(Yeni) " + enYuksek; 
            HighScore = sonSkor;
            PlayerPrefs.SetInt("GraveHighScore", sonSkor);
            PlayerPrefs.Save();
        }
        mKutusu.SetActive(false);
        gManager.oyunuDurdur();
        genelMenu.SetActive(false);
        ölumMenu.SetActive(true);
        finalSkor.text = "Skor: " + sonSkor;
        enYuksekSkor.text = enYuksek + HighScore;

    }

}
