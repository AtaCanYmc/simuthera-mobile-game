using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaKarakter : MonoBehaviour
{
    //  Hareket değişkenleri
    private float xPosition;
    private float mesafe = 0f;
    private bool canMove;
    private float xPoint = 0f;
    public float zıplamaGücü;

    //Ses
    public AudioSource sesKaynak;
    public AudioClip zıplamaSesi;
    public AudioClip hasarSesi;

    //  Animasyon değişkenleri
    public Animator animasyonKontrol;

    //oop
    public GameManager gManager;

    // Start is called before the first frame update
    void Start()
    {
        xPoint = -7.50f;
        canMove = true;
        gManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        xPosition = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gManager.duraklat)
        {
            tuşBasma();
        }
    }

    void tuşBasma() // Pc kısmı
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow))
            && (xPosition < 7.50f) && canMove)
        {
            canMove = false;
            mesafe = 5f;
            animasyonKontrol.SetTrigger("isVanish");
            Invoke("hareket", 0.43f);
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow))
            && (xPosition > (-7.50f)) && canMove)
        {
            canMove = false;
            mesafe = -5f;
            animasyonKontrol.SetTrigger("isVanish");
            Invoke("hareket", 0.43f);
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            && canMove)
        {
            canMove = false;
            xPoint = -7.50f;
            animasyonKontrol.SetTrigger("isVanish");
            Invoke("ısınlanma", 0.43f);
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            && canMove)
        {
            canMove = false;
            xPoint = -2.50f;
            animasyonKontrol.SetTrigger("isVanish");
            Invoke("ısınlanma", 0.43f);
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
             && canMove)
        {
            canMove = false;
            xPoint = 2.50f;
            animasyonKontrol.SetTrigger("isVanish");
            Invoke("ısınlanma", 0.43f);
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            && canMove)
        {
            canMove = false;
            xPoint = 7.50f;
            animasyonKontrol.SetTrigger("isVanish");
            Invoke("ısınlanma", 0.43f);
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && canMove)
        {
            zıplama();
        }
    }

    //Mobil butonlar
    public void mezar1()
    {
        if (canMove)
        {
            if (xPoint != -7.50f)
            {
                canMove = false;
                xPoint = -7.50f;
                animasyonKontrol.SetTrigger("isVanish");
                Invoke("ısınlanma", 0.43f);
            }
            else
                zıplama();
        }
    }
    public void mezar2()
    {
        if (canMove)
        {
            if (xPoint != -2.50f)
            {
                canMove = false;
                xPoint = -2.50f;
                animasyonKontrol.SetTrigger("isVanish");
                Invoke("ısınlanma", 0.43f);
            }
            else
                zıplama();
        }
    }
    public void mezar3()
    {
        if (canMove)
        {
            if (xPoint != 2.50f)
            {
                canMove = false;
                xPoint = 2.50f;
                animasyonKontrol.SetTrigger("isVanish");
                Invoke("ısınlanma", 0.43f);
            }
            else
                zıplama();
        }
    }
    public void mezar4()
    {
        if (canMove)
        {
            if (xPoint != 7.50f)
            {
                canMove = false;
                xPoint = 7.50f;
                animasyonKontrol.SetTrigger("isVanish");
                Invoke("ısınlanma", 0.43f);
            }
            else
                zıplama();
        }
    }


    //Hareket fonksiyonları
    public void zıplama()
    {
        canMove = false;
        Invoke("hareketSerbest", 1.75f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, zıplamaGücü);
        sesKaynak.PlayOneShot(zıplamaSesi); //ses oynatır
    }
    void hareket()
    {
        transform.Translate(mesafe, 0, 0);
        Invoke("hareketSerbest", 0.45f);
    }

    void ısınlanma()
    {
        transform.SetPositionAndRotation(new Vector3(xPoint, -3, -1), new Quaternion(0, 0, 0, 0));
        Invoke("hareketSerbest", 0.45f);
    }

    void hareketSerbest()
    {
        canMove = true;
    }

    //Animasyon fonksiyonları
    public void hurt()
    {
        gManager.ekleCan(-1);
        animasyonKontrol.SetTrigger("isHurt");
        sesKaynak.PlayOneShot(hasarSesi); //ses oynatır
    }

    public void dead()
    {
        animasyonKontrol.SetBool("isDead",true);
    }
}
