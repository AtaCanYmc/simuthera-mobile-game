using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kameraÖlümü : MonoBehaviour
{
    public Transform player;
    public Transform Camera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y - Camera.position.y >= 42 || player.position.y - Camera.position.y <= -42)
        {
            Debug.Log("öldün");
            SceneManager.LoadScene(11);
        }
    }
}
