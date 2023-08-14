using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dikenlereÇarpmak : MonoBehaviour
{
    // Start is called before the first frame update
    public int can;
    void Start()
    {
        can = PlayerPrefs.GetInt("can"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("diken"))
        {
            Debug.Log("öldün diken");

            can--;

            if (can==0)
            {
                SceneManager.LoadScene(11);

            }
            
        } 
    }
}
