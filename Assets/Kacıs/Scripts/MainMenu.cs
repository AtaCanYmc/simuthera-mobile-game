using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayEasy ()
    {
        PlayerPrefs.SetInt("can", 10);
        PlayerPrefs.Save();
        SceneManager.LoadScene(9);
    }

    public void PlayMed ()
    {
        PlayerPrefs.SetInt("can", 5);
        PlayerPrefs.Save();
        SceneManager.LoadScene(9);
    }

    public void PlayHard ()
    {
        PlayerPrefs.SetInt("can", 3);
        PlayerPrefs.Save();
        SceneManager.LoadScene(9);
    }

    public void ExitGame()
    {
        Debug.Log("CIKIS_YAPILDI");
        SceneManager.LoadScene(0);
    }
}
