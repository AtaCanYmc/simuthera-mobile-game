using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverekran : MonoBehaviour
{
    //SceneManager.LoadScene(0);


    public void TekrarDene ()
    {
        SceneManager.LoadScene(9);
    }

    public void GoToMainMenu ()
    {
        SceneManager.LoadScene(8);
    }

    public void ExitGame()
    {
        Debug.Log("CIKIS_YAPILDI");
        SceneManager.LoadScene(0);
    }
}