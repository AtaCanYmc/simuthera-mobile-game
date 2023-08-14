using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class GameManagement2 : MonoBehaviour
{
    public string GameDiff;
    public float EnemySpeed = 2.5f;
    public int Lives = 3, Score = 0, EnemyCount = 0, LaserID = 0;

    GameObject EnemyGroup1, EnemyGroup2;
    private float FireDelay = 0.75f, FireInterval = 1.00f;
    private bool StartedFiring = false, GameIsStarted = false;
    public int frontEnemy_count;

    public GameObject gameOver, tryAgain, yesButton, noButton;
    public TMP_Text ReadyText;
    public Text ScoreText, LifeText;
    public bool isPaused = false;
    public GameObject canvas, player;

    public AudioMixer mixer;

    GameObject Star1, Star2, Heart1, Heart2;
    int bonusID = 0;
    GameObject currentBonus;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        gameOver.SetActive(false);
        tryAgain.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        mixer.SetFloat("MusicVol", Mathf.Log10(savedVolume) * 30);
        
        GameDiff = Difficulty.UsrDifficulty;
        if (!GameDiff.Equals("Easy") && !GameDiff.Equals("Medium") && !GameDiff.Equals("Hard"))
        {
            GameDiff = PlayerPrefs.GetString("Difficulty");
        }

        Time.timeScale = 1.0f;
        StartCoroutine(ReadySetGo());
    }
    
    void Update()
    {
        if (EnemyCount == 0 && GameIsStarted)
        {
            if (EnemyGroup1 != null && EnemyGroup1.transform.childCount != 0)
            {
                Destroy(EnemyGroup1, 0.417f);
                Destroy(EnemyGroup2);
            }
                
            else if (EnemyGroup2 != null && EnemyGroup2.transform.childCount != 0)
            {
                Destroy(EnemyGroup1);
                Destroy(EnemyGroup2, 0.417f);
            }

            if (currentBonus != null)
            {
                Destroy(currentBonus);
            }

            Invoke("CreateEnemies", 2.0f);
        }

        if (!StartedFiring && GameIsStarted)
        {
            InvokeRepeating("randomFire", FireDelay, FireInterval);
            StartedFiring = true;
        }
        
    }

    public void CreateEnemies()
    {   
        if (GameDiff.Equals("Easy"))
        {
            CreateGroups("Group1", "Group1", 6.0f, 4.0f, 7);
            frontEnemy_count = 7;
        }
        else if (GameDiff.Equals("Medium"))
        {
            CreateGroups("Group2", "Group2", 6.0f, 4.0f, 7);
            frontEnemy_count = 7;
        }
        else
        {
            CreateGroups("Group2", "Group3", 6.0f, 3.7f, 5);
            frontEnemy_count = 5;
        }
        CancelInvoke();
        StartedFiring = false;
        InvokeRepeating("createBonus", 0f, 10.0f);
        InvokeRepeating("destroyBonus", 10.0f, 10.0f);
    }

    public void randomFire()
    {

        int num1=0;
        int num2=0;
        int num3=0;

       
        while (true)
        {
            num1 = Random.Range(7, 14);
            num2 = Random.Range(7, 14);
            num3 = Random.Range(7, 14);
            if(num1 != num2 && num2 != num3)
            {
                break;
            }
        
        }

        if (frontEnemy_count <= 3)
        {
            while (true)
            {
                num1 = Random.Range(0, 14);
                num2 = Random.Range(0, 14);
                num3 = Random.Range(0, 14);
                if (num1 != num2 && num2 != num3)
                {
                    break;
                }
            }
        }

        GameObject ship1 = GameObject.Find("Enemy" + num1.ToString());
        GameObject ship2 = GameObject.Find("Enemy" + num2.ToString());
        GameObject ship3 = GameObject.Find("Enemy" + num3.ToString());

        if (ship1 != null)
        {
            ship1.GetComponent<EnemySpaceship>().EnemyFire(LaserID);
            LaserID++;
        }

        if (ship2 != null)
        {
            ship2.GetComponent<EnemySpaceship>().EnemyFire(LaserID);
            LaserID++;
        }

        if (ship3 != null)
        {
            ship3.GetComponent<EnemySpaceship>().EnemyFire(LaserID);
            LaserID++;
        }

    }

    void CreateGroups(string grup_adi1, string grup_adi2, float y1, float y2, int count)
    {
        GameObject Group1Prefab = (GameObject)Resources.Load("Prefabs\\"+ grup_adi1, typeof(GameObject));
        EnemyGroup1 = Instantiate(Group1Prefab, new Vector3(0f, y1, -1.89f), Quaternion.identity);
        for (int i = 0; i < 7; i++)
        {
            GameObject.Find(grup_adi1 + "-" + i.ToString()).name = "Enemy" + EnemyCount.ToString();
            EnemyCount++;
        }
        EnemyGroup1.name = "Group1";
  
        GameObject Group2Prefab = (GameObject)Resources.Load("Prefabs\\" + grup_adi2, typeof(GameObject));
        EnemyGroup2 = Instantiate(Group2Prefab, new Vector3(0f, y2, -1.89f), Quaternion.identity);
        for (int i = 0; i < count; i++)
        {
            GameObject tempShip = GameObject.Find(grup_adi2 + "-" + i.ToString());
            tempShip.name = "Enemy" + EnemyCount.ToString();
            tempShip.GetComponent<EnemySpaceship>().isFront = true;
            EnemyCount++;
        }
        EnemyGroup2.name = "Group2";
    }

    public void EndGame()
    {
        PlayerPrefs.SetString("Difficulty", GameDiff);
        PlayerPrefs.Save();
        Destroy(EnemyGroup1); Destroy(EnemyGroup2);
        if (currentBonus != null)
        {
            Destroy(currentBonus);
        }
        GameObject[] LeftoverLasers = GameObject.FindGameObjectsWithTag("Laser");
        for (int i = 0; i < LeftoverLasers.Length; i++) Destroy(LeftoverLasers[i]);

        Time.timeScale = 0f;
        int LastHighScore = PlayerPrefs.GetInt("UzayHighScore");
        if (Score > LastHighScore)
        {
            PlayerPrefs.SetInt("UzayHighScore", Score);
            PlayerPrefs.Save();
        }

        player.SetActive(false);
        gameOver.SetActive(true);
        tryAgain.SetActive(true);
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }

    public void HideElements()
    {    
        canvas.SetActive(false);
        player.SetActive(false);
        if (EnemyGroup1 != null) EnemyGroup1.SetActive(false);
        if (EnemyGroup2 != null) EnemyGroup2.SetActive(false);
        if (currentBonus != null)
        {
            currentBonus.transform.localScale = new Vector2(0, 0);
        }
        GameObject[] laserArr = GameObject.FindGameObjectsWithTag("Laser");
        for(int i = 0; i < laserArr.Length; i++)
        {
            laserArr[i].transform.localScale = new Vector2(0,0);
        }                                               
        Time.timeScale = 0.0f;
    }

    public void ShowElements()
    {
        canvas.SetActive(true);
        player.SetActive(true);
        if (EnemyGroup1 != null) EnemyGroup1.SetActive(true);
        if (EnemyGroup2 != null) EnemyGroup2.SetActive(true);
        if (currentBonus != null)
        {
            if (currentBonus.name.Contains("Star"))
            {
                currentBonus.transform.localScale = new Vector2(0.4f, 0.5f);
            }
            else
            {
                currentBonus.transform.localScale = new Vector2(0.4f, 0.4f);
            }
        }
        GameObject[] laserArr = GameObject.FindGameObjectsWithTag("Laser");
        for (int i = 0; i < laserArr.Length; i++)
        {
            if (laserArr[i].name.Contains("Enemy"))
            {
                laserArr[i].transform.localScale = new Vector3(0.8f, 1.9f, 1.0f);
            }
            else
            {
                laserArr[i].transform.localScale = new Vector3(0.13f, 0.23f, 1.0f);
            }
        }
        Time.timeScale = 1.0f;
    }

    public void createBonus()
    {
        int choice = Random.Range(1, 3);
        int horizontal = Random.Range(-12, 13);
        int vertical = Random.Range(0, 7);
        if (choice == 1)
        {
            Heart1 = (GameObject)Resources.Load("Prefabs\\Heart", typeof(GameObject));
            Heart2 = Instantiate(Heart1, new Vector3(horizontal, vertical, 0), Quaternion.identity);
            Heart2.name = "Heart" + bonusID.ToString();
            currentBonus = Heart2;
            bonusID++;
        }
        else
        {
            Star1 = (GameObject)Resources.Load("Prefabs\\Star", typeof(GameObject));
            Star2 = Instantiate(Star1, new Vector3(horizontal, vertical, 0), Quaternion.identity);
            Star2.name = "Star" + bonusID.ToString();
            currentBonus = Star2;
            bonusID++;
        }
    }

    public void destroyBonus()
    {
        Destroy(currentBonus);
    }

    private IEnumerator ReadySetGo()
    {
        yield return new WaitForSeconds(1.0f);
        ReadyText.GetComponent<TMP_Text>().text = "2";
        yield return new WaitForSeconds(1.0f);
        ReadyText.GetComponent<TMP_Text>().text = "1";
        yield return new WaitForSeconds(1.0f);
        ReadyText.GetComponent<TMP_Text>().text = "BASLA!";
        yield return new WaitForSeconds(1.0f);
        ReadyText.transform.localScale = new Vector3(0, 0, 0);
        CreateEnemies();
        GameIsStarted = true;
    }
}
