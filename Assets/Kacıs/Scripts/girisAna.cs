using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class girisAna : MonoBehaviour
{
    
    public void Oyna()
    { 
        SceneManager.LoadScene(8);
    }
   
    public void Cıkıs()
    {

        Debug.Log("CIKIS_YAPILDI");
        SceneManager.LoadScene(0);
    }

}
