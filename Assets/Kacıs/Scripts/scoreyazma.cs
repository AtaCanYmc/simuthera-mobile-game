using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class scoreyazma : MonoBehaviour
{
    // Start is called before the first frame update
    int Score;
    public Text scoreText;
    public TextMeshProUGUI mesaj_txt;
    void Start()
    {
        Score = PlayerPrefs.GetInt("Kacısscore");
        MesajGöster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MesajGöster()
    {
        scoreText.text = ""+Score;
    }
}
