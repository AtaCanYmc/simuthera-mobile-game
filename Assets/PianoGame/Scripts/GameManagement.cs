using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class GameManagement : MonoBehaviour
{
    private float TileSpeed = 5.00f, TileInterval = 1.00f;
    private bool CanCreate = true;
    public int Lives = 3, Score = 0;

    public TMP_Text LifeText, ScoreText;
    public AudioSource[] sources = new AudioSource[4];
    private AudioSource currentMusic;
    public bool isPaused = false, PauseMusic = true;
    public AudioMixer mixer;

    public GameObject canvas, bottomTiles, screenTiles, CountText;
    public static GameObject pauseCanvas;

    private bool Allowed = true, GameWasPaused = false;
    private float LastIncreaseTime = 0.0f, CreateTime = 0.0f;

    void Start()
    {
        CountText.SetActive(false);
        float lastVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        mixer.SetFloat("MusicVol", Mathf.Log10(lastVolume) * 30);
        AudioListener.volume = 1.0f;
        int num = Random.Range(1, 5);
        switch(num)
        {
            case 1:
                sources[0].Play();
                currentMusic = sources[0];
                break;
            case 2:
                sources[1].Play();
                currentMusic = sources[1];
                break;
            case 3:
                sources[2].Play();
                currentMusic = sources[2];
                break;
            default:
                sources[3].Play();
                currentMusic = sources[3];
                break;
        }

        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (Lives == 0)
        {
            Time.timeScale = 0;
            currentMusic.Stop();
            int lastHighScore = PlayerPrefs.GetInt("PiyanoHighScore");
            if (Score > lastHighScore)
            {
                PlayerPrefs.SetInt("PiyanoHighScore", Score);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene(5);
        }

        if (isPaused == true)
        {
            Hide();
        }

        if (isPaused == false)
        {
            Show();
        }

        if (Time.timeScale != 0) 
        {
            LastIncreaseTime += Time.deltaTime;
            if (LastIncreaseTime >= 10.0f)
            {
                IncreaseSpeed();
                LastIncreaseTime = 0.0f;
            }

            if (CanCreate)
            {
                CreateTime += Time.deltaTime;
                if (CreateTime >= TileInterval)
                {
                    CreateTiles();
                    CreateTime = 0.0f;
                }
            }
        }

    }

    public void CreateTiles()
    {  
        float spot;
        int randomlane = Random.Range(1, 5);
        int randomTile = Random.Range(1, 101);
        if (randomlane == 1) spot = -1.4787f;      //Tile1 x kordinat
        else if (randomlane == 2) spot = -0.5047f; //Tile2 x kordinat
        else if (randomlane == 3) spot = 0.4953f;  //Tile3 x kordinat
        else spot = 1.498f;                        //Tile4 x kordinat

        GameObject Tiles, Tiles1;
        if (randomTile < 10) // 10% şans
        {
            Tiles = (GameObject)Resources.Load("Tiles\\StarTile", typeof(GameObject));
        }
        else if (randomTile > 85) // 15% şans
        {
            Tiles = (GameObject)Resources.Load("Tiles\\BonusTile", typeof(GameObject));
        }
        else if (randomTile < 15) // 5% şans
        {
            Tiles = (GameObject)Resources.Load("Tiles\\LifeTile", typeof(GameObject));
        }
        else
        {
            Tiles = (GameObject)Resources.Load("Tiles\\Tile", typeof(GameObject));
        }

        Tiles1 = Instantiate(Tiles, new Vector3(spot, 3.2f, -1f), Quaternion.identity);
        Tiles1.transform.parent = screenTiles.transform;
        Tiles1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -TileSpeed);

    }

    public void Hide()
    {
        if (!Allowed)
        {
            GameWasPaused = true;
            CanCreate = false;
            pauseCanvas = GameObject.Find("PauseCanvas");
            canvas.SetActive(false);
            bottomTiles.SetActive(false);
            screenTiles.transform.localScale = new Vector3(0, 0, 0);

            if (PauseMusic)
            {
                currentMusic.Pause();
                PauseMusic = false;
            }

            Allowed = true;
        }
    }

    public void Show()
    {
        if (Allowed)
        {
            canvas.SetActive(true);
            bottomTiles.SetActive(true);
            screenTiles.transform.localScale = new Vector3(1.013592f, -3.855601f, -0.3281724f);
            int IndexCnt = screenTiles.transform.childCount;
            Transform[] GameTiles = new Transform[IndexCnt];
            if (IndexCnt != 0)
            {
                GameTiles = new Transform[IndexCnt];
                for (int i = 0; i < IndexCnt; i++)
                {
                    GameTiles[i] = screenTiles.transform.GetChild(i);
                    GameTiles[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
            
            if (GameWasPaused)
            {
                CountText.SetActive(true);
                if (IndexCnt != 0)
                    StartCoroutine(ReadySetGo(GameTiles));
                else
                    StartCoroutine(ReadySetGo());
                Time.timeScale = 1.0f;
                GameWasPaused = false;
            }

            Allowed = false;
        }
    }

    private IEnumerator ReadySetGo()
    {
        CountText.GetComponent<TMP_Text>().text = "3";
        yield return new WaitForSeconds(1);
        CountText.GetComponent<TMP_Text>().text = "2";
        yield return new WaitForSeconds(1);
        CountText.GetComponent<TMP_Text>().text = "1";
        yield return new WaitForSeconds(1);
        CountText.SetActive(false);
        CanCreate = true;
    }

    private IEnumerator ReadySetGo(Transform[] arr)
    {
        CountText.GetComponent<TMP_Text>().text = "3";
        yield return new WaitForSeconds(1);
        CountText.GetComponent<TMP_Text>().text = "2";
        yield return new WaitForSeconds(1);
        CountText.GetComponent<TMP_Text>().text = "1";
        yield return new WaitForSeconds(1);
        CountText.SetActive(false);
        if (!PauseMusic)
        {
            currentMusic.UnPause();
            PauseMusic = true;
        }
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, -TileSpeed);
        }
        CanCreate = true;
    }

    private void IncreaseSpeed()
    {
        TileSpeed += 0.2f;
        TileInterval -= 0.015f;
        LastIncreaseTime = 0.0f;
    }

}
