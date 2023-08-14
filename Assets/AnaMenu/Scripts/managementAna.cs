using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;

public class managementAna : MonoBehaviour
{

    public GameObject kayıtEkranı;
    public GameObject AnaEkran;
    public GameObject skorEkranı;
    public GameObject OyunEkranı;

    public GameObject kayıtSilmeUyarısı;
    public GameObject kayıtAçEkranı;
    public GameObject çıkışButonuKayıt;
    public TextMeshProUGUI Ad;

    public TextMeshProUGUI skor1;
    public TextMeshProUGUI skor2;
    public TextMeshProUGUI skor3;
    public TextMeshProUGUI skor4;
    public TextMeshProUGUI skor5;

    private int GraveHighScore = 0;
    private int KaçışHighScore = 0;
    private int UzayHighScore = 0;
    private int PiyanoHighScore = 0;
    private int PGHighScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll(); //bitince sil
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        if (!PlayerPrefs.HasKey("OyuncuAdı"))
        {
            kayıtEkranıAç(true);
        }
        else
            anaEkran();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void anaEkran()
    {
        kayıtAçEkranı.SetActive(false);
        kayıtEkranı.SetActive(false);
        OyunEkranı.SetActive(false);
        skorEkranı.SetActive(false);
        AnaEkran.SetActive(true);
    }

    public void skorGüncelle()
    {
        GraveHighScore = PlayerPrefs.GetInt("GraveHighScore");
        UzayHighScore = PlayerPrefs.GetInt("UzayHighScore");
        PiyanoHighScore = PlayerPrefs.GetInt("PiyanoHighScore");
        PGHighScore = PlayerPrefs.GetInt("PGHighScore");
        KaçışHighScore = PlayerPrefs.GetInt("Kacısscore");

        skor1.text = "Catching Tiles: " + PiyanoHighScore;
        skor2.text = "Kaçış: " + KaçışHighScore;
        skor3.text = "Space Fighters: " + UzayHighScore;
        skor4.text = "Paper Girl: " + PGHighScore;
        skor5.text = "Graveyard Adventure: " + GraveHighScore;
    }

    public void kayıtEkranıAç(bool ilkKayıt)
    {
        kayıtEkranı.SetActive(true);
        OyunEkranı.SetActive(false);
        AnaEkran.SetActive(false);
        skorEkranı.SetActive(false);

        Ad.text = null;
        if (!ilkKayıt)
        {
            kayıtSilmeUyarısı.SetActive(true);
            çıkışButonuKayıt.SetActive(true);
        }
        else
            kayıtAçEkranı.SetActive(true);
    }

    public void oyunEkranıAç()
    {
        kayıtEkranı.SetActive(false);
        AnaEkran.SetActive(false);
        skorEkranı.SetActive(false);
        OyunEkranı.SetActive(true);
    }

    public void skorEkranıAç()
    {
        kayıtEkranı.SetActive(false);
        AnaEkran.SetActive(false);
        skorEkranı.SetActive(true);
        OyunEkranı.SetActive(false);
        skorGüncelle();
    }

    public void adıKaydet()
    {
        if (Ad.text != null || Ad.text.ToLower() != "cs")
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("OyuncuAdı", Ad.text);
            PlayerPrefs.Save();
            anaEkran();
        }
        else
            Ad.text = "CS Lover :)";

    }

}
