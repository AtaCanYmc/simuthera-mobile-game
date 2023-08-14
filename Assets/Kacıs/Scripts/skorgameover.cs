using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skorgameover : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (int)scoreAmount + " Score";
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
    }
}
