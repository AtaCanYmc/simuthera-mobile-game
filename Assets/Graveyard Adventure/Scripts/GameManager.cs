using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AnaKarakter karakter;
    public GameObject Mızrak1;
    public GameObject yatayMızrak;
    public GameObject yatayMızrak2;
    public GameObject para;
    public GameObject can;
    GameObject toplanabilirItem = null;
    GameObject yeniMızrak = null;

    [Tooltip("Saldırı yaşama sıklığı (x saniyede bir)")]
    [Range(0.1f, 15)]
    public float mızrakSıklığı;

    [Tooltip("Can düşme sıklığı (%x)")]
    [Range(1, 10)]
    public int canSıklığı;

    private float boşMezar = -1f;
    private float[] mezarYerleri;

    public bool duraklat;
    public menumanager mManager;

    //skor ve can
    private int skor;
    private int kalanCan;
    private bool öldü;

    //Ses ayarları
    public AudioSource sesKaynak;
    public AudioClip MızrakSesi;
    public AudioClip uyarıSesi;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("GraveHighScore", 0);
        öldü = false;
        mezarYerleri = new float[] {-7.50f,-2.50f,2.50f,7.50f};
        karakter = FindObjectOfType<AnaKarakter>();
        duraklat = true;
        skor = 0;
        kalanCan = 3;

        if (!PlayerPrefs.HasKey("GraveHighScore"))
        {
            PlayerPrefs.SetInt("GraveHighScore", 0);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            mManager.ayarlar();
        }
        if (kalanCan <= 0 && !öldü)
        {
            karakter.dead();
            mManager.ölüm(skor);
            öldü = true;
        }
    }

    public void oyunuBaslat()
    {
        Invoke("saldırıYap", 2.2f);
        duraklat = false;
    }

    public void oyunuDurdur()
    {
        CancelInvoke();
        duraklat = true;

        if (toplanabilirItem != null)
            Destroy(toplanabilirItem);

        GameObject.Find("miniMızrakSol").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("miniMızrakSag").GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 1; i < mezarYerleri.Length + 1; i++) //parlayan mızrakları kapatır
        {
            GameObject.Find("miniMızrak" + i).GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    void saldırıYap()
    {
        if (Random.Range(1, 101) <= 30)
            Invoke("yatayMızrakHazırla", 1f);
        else
            Invoke("dikeyMızrakHazırla", 1f);
    }

    public void dikeyMızrakHazırla()
    {
        boşMezar = randomMezar(boşMezar);

        if(Random.Range(0,101) <= canSıklığı)
            toplanabilirItem = Instantiate(can, new Vector3(boşMezar, -3.7f, -1), new Quaternion(0, 0, -90, 90));
        else
            toplanabilirItem = Instantiate(para, new Vector3(boşMezar, -3.7f, -1), new Quaternion(0, 0, -90, 90));

        toplanabilirItem.SetActive(true);

        for (int i = 0; i < mezarYerleri.Length; i++)
        {
            if (mezarYerleri[i] != boşMezar)
            {
                GameObject.Find("miniMızrak" + (i + 1)).GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        if(!duraklat)
            sesKaynak.PlayOneShot(uyarıSesi); //ses oynatır
            Invoke("dikeyMızrakAt", mızrakSıklığı - 0.5f);
    }

    public void yatayMızrakHazırla()
    {
        boşMezar = randomMezar(boşMezar);

        if (Random.Range(0, 101) <= canSıklığı)
            toplanabilirItem = Instantiate(can, new Vector3(boşMezar, -3.7f, -1), new Quaternion(0, 0, -90, 90));
        else
            toplanabilirItem = Instantiate(para, new Vector3(boşMezar, -3.7f, -1), new Quaternion(0, 0, -90, 90));

        toplanabilirItem.SetActive(true);

        if (!duraklat)
            sesKaynak.PlayOneShot(uyarıSesi); //ses oynatır
            if (Random.Range(0, 101) <= 50)
            {
                Invoke("soldanMızrakAt", mızrakSıklığı - 0.5f);
                GameObject.Find("miniMızrakSol").GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                Invoke("sagdanMızrakAt", mızrakSıklığı - 0.5f);
                GameObject.Find("miniMızrakSag").GetComponent<SpriteRenderer>().enabled = true;
            }
    }

    private float randomMezar(float eskiMezar) // random boş mezar seçer (bir önceki mezarı seçemez)
    {
        float koordinat = 0f;

        do{
            koordinat = mezarYerleri[Random.Range(0, 4)];
        }while(koordinat == eskiMezar);

        return koordinat;
    }

    void dikeyMızrakAt()
    {
        sesKaynak.PlayOneShot(MızrakSesi); //ses oynatır

        foreach (var koordinat in mezarYerleri)
        {
            if (koordinat != boşMezar && !duraklat)
            {
                yeniMızrak = Instantiate(Mızrak1, new Vector3(koordinat, 6, -1), new Quaternion(0, 0, -90, 90));
                yeniMızrak.SetActive(true);
            }
        }

        for (int i = 1; i < mezarYerleri.Length+1; i++)
        {
            GameObject.Find("miniMızrak" + i).GetComponent<SpriteRenderer>().enabled = false;
        }

        Destroy(toplanabilirItem);

        if(!duraklat)
            Invoke("saldırıYap", 1f);
    }

    void soldanMızrakAt()
    {
        sesKaynak.PlayOneShot(MızrakSesi); //ses oynatır
        GameObject.Find("miniMızrakSol").GetComponent<SpriteRenderer>().enabled = false;

        if (!duraklat)
        {
            yeniMızrak = Instantiate(yatayMızrak, new Vector3(-13f, -3.715751f, -1f), new Quaternion(0, 0, 0, 0));
            yeniMızrak.SetActive(true);
        }

        Destroy(toplanabilirItem);

        if (!duraklat)
            Invoke("saldırıYap", 1f);
    }

    void sagdanMızrakAt()
    {
        sesKaynak.PlayOneShot(MızrakSesi); //ses oynatır
        GameObject.Find("miniMızrakSag").GetComponent<SpriteRenderer>().enabled = false;

        if (!duraklat)
        {
            yeniMızrak = Instantiate(yatayMızrak2, new Vector3(12f, -3.715751f, -1f), new Quaternion(0, 0, -90, 0));
            yeniMızrak.SetActive(true);
        }

        Destroy(toplanabilirItem);

        if (!duraklat)
            Invoke("saldırıYap", 1f);
    }

    public void ekleSkor(int ekleme)
    {
        skor += ekleme;
        mManager.skorGuncelle(skor);
    }

    public void ekleCan(int ekleme)
    {
        kalanCan += ekleme;
        mManager.canGuncelle(kalanCan);
    }
}
