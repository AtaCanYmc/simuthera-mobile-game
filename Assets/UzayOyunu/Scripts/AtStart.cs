using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AtStart2 : MonoBehaviour
{
    public TMP_Text HighScoreText;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (!PlayerPrefs.HasKey("UzayHighScore"))
        {
            PlayerPrefs.SetInt("UzayHighScore", 0);
            PlayerPrefs.Save();
        }
        int LastHighScore = PlayerPrefs.GetInt("UzayHighScore");
        HighScoreText.text = "En Yuksek Skor: " + LastHighScore;
    }
}
