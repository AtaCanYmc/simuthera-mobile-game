using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
        PlayerPrefs.SetInt("Kacısscore", (int)scoreAmount);
        PlayerPrefs.Save();
    }


}
