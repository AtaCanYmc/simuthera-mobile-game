using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdYenile : MonoBehaviour
{
    public TextMeshProUGUI Ad;

    // Start is called before the first frame update
    void Start()
    {
        Ad.text = PlayerPrefs.GetString("OyuncuAdı");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Ad.text != PlayerPrefs.GetString("OyuncuAdı"))
            Ad.text = PlayerPrefs.GetString("OyuncuAdı");
    }
}
