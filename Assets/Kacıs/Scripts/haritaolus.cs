using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haritaolus : MonoBehaviour
{
   


    public Transform kameraObjesi;
    public Transform alttetik;
    public Vector3 v2 = new Vector3(0, -350, 0);
    public int sıralama;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ışınlama();
    }//xd
    void ışınlama()
    {
        if (kameraObjesi.position.y + 30 <= alttetik.position.y - 40-sıralama-25)
        {
            Debug.Log("yeni harita oluştur");
            alttetik.position += v2;
        }
    }



}
