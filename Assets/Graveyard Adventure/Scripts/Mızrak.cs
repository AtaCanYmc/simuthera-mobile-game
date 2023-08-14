using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mızrak : MonoBehaviour
{
    public AnaKarakter player;
    public bool sagTarafa;
    public bool solTarafa;
    public float hız;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AnaKarakter>();
    }

    void Update()
    {
        if(sagTarafa)
        {
            transform.Translate(hız * Time.deltaTime , 0 , 0);
        }
        else if(solTarafa)
        {
            transform.Translate(-1 * hız * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.hurt();
        }
        if(collision.tag != "Toplanabilir")
            Destroy(gameObject);
    }

    public void setMızrakHızı(float hız)
    {
        this.hız = hız;
    }
}
