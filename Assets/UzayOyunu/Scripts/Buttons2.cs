using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Buttons2 : MonoBehaviour
{
    GameManagement2 management;
    GameObject pauseMenuCanvas;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void MainMenuExit()
    {
        pauseMenuCanvas = GameObject.Find("MainMenuCanvas").transform.Find("MainCanvas").gameObject;
        pauseMenuCanvas.SetActive(false);
        SceneManager.LoadScene(16, LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        //EditorApplication.isPlaying = false;
        SceneManager.LoadScene(0);
    }

    public void TryAgainYes()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void TryAgainNo()
    {
        SceneManager.LoadScene(12);
    }

    public void Pause()
    {
        management = GameObject.Find("GameManagement").GetComponent<GameManagement2>();
        management.HideElements();
        SceneManager.LoadScene(14, LoadSceneMode.Additive);
    }

    public void Resume()
    {
        management = GameObject.Find("GameManagement").GetComponent<GameManagement2>();
        management.ShowElements();
        SceneManager.UnloadSceneAsync(14);
    }

    public void Replay()
    {
        management = GameObject.Find("GameManagement").GetComponent<GameManagement2>();
        string lastDiff = management.GameDiff;
        PlayerPrefs.SetString("Difficulty", lastDiff);
        SceneManager.LoadScene(13);
    }

    public void PauseMenuQuit()
    {
        SceneManager.LoadScene(12);
    }

    public void GoBack()
    {
        if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            pauseMenuCanvas = GameObject.Find("PauseMenuCanvas").transform.Find("PauseCanvas").gameObject;
            pauseMenuCanvas.SetActive(true);
            SceneManager.UnloadSceneAsync(16);
        }

        else if (SceneManager.GetActiveScene().buildIndex == 12)
        {
            pauseMenuCanvas = GameObject.Find("MainMenuCanvas").transform.Find("MainCanvas").gameObject;
            pauseMenuCanvas.SetActive(true);
            SceneManager.UnloadSceneAsync(16);
        }
    }

    public void HowToPlayOpen()
    {
        SceneManager.LoadScene(15);
    }

    public void HowToPlayClose()
    {
        SceneManager.LoadScene(12);
    }

}
