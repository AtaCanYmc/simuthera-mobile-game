using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toplanabilir : MonoBehaviour
{
    public bool canMı;
    public GameManager gManager;
    public AudioSource sesKaynak;
    public AudioClip toplanmaSesi;

    // Start is called before the first frame update
    void Start()
    {
        gManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sesKaynak.PlayOneShot(toplanmaSesi); //ses oynatır

            if (canMı)
            {
                gManager.ekleCan(1);
            }
            else
            {
                gManager.ekleSkor(1);
            }
            Destroy(gameObject);
        }
    }
}
