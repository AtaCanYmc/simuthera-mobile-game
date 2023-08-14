using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AtStart : MonoBehaviour
{
    public TMP_Text HighScoreText;

    void Start()
    {
        int HighScore = PlayerPrefs.GetInt("PiyanoHighScore", 0);
        HighScoreText.text = "En Yuksek Skor: " + HighScore;
    }
}
