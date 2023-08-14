using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    GameManagement pauseManagement;
    public GameObject canvas;
    public GameObject parentCanvas;

    public void StartButton()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenuExit()
    {
        parentCanvas = GameObject.Find("ParentCanvas").transform.Find("Canvas").gameObject;
        parentCanvas.SetActive(false);
        SceneManager.LoadScene(6, LoadSceneMode.Additive);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(4);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
        pauseManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        pauseManagement.isPaused = true;
    }

    public void Replay()
    {
        SceneManager.LoadScene(2);
    }

    public void goBack()
    {
        if (SceneManager.GetActiveScene().name.Equals("MainScene"))
        {
            canvas = GameObject.Find("ParentPause").transform.Find("PauseCanvas").gameObject;
            canvas.SetActive(true);
            SceneManager.UnloadSceneAsync(6);
        }

        else if (SceneManager.GetActiveScene().name.Equals("HowToPlay") || SceneManager.GetActiveScene().name.Equals("EndScene"))
        {
            SceneManager.LoadScene(1);
        }

        else if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            parentCanvas = GameObject.Find("ParentCanvas").transform.Find("Canvas").gameObject;
            parentCanvas.SetActive(true);
            SceneManager.UnloadSceneAsync(6);
        }

    }

    public void ExitGame()
    {
        //EditorApplication.isPlaying = false;
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        //Time.timeScale = 1.0f;
        SceneManager.UnloadSceneAsync(3);
        pauseManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        pauseManagement.isPaused = false;
    }

    public void PauseMenuExit()
    {
        SceneManager.LoadScene(1);
    }

}
