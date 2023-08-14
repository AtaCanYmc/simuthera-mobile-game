using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YazıAyarı : MonoBehaviour
{
    [TextArea(15, 20)]
    public string[] yazılar;
    private Queue<string> credits;
    public Animator yazıAnimasyon;
    public Animator logoAnimasyon;
    public GameObject logo;
    public GameObject buton;
    public TextMeshProUGUI yazımız;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        credits = new Queue<string>();

        foreach (var item in yazılar)
        {
            credits.Enqueue(item);
        }

        InvokeRepeating("ekranaYazdır", 1f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ekranaYazdır()
    {
        if (credits.Count != 0)
        {
            yazımız.text = credits.Dequeue();
            yazıAnimasyon.SetTrigger("Göster");
        }
        else
        {
            CancelInvoke();
            final();
        }

    }

    public void final()
    {
        logo.SetActive(true);
        buton.SetActive(true);
        logoAnimasyon.SetBool("Panel", true);
    }

    public void website(string Url)
    {
        Application.OpenURL(Url);
        Debug.Log("site aç");
    }

    public void menü()
    {
        SceneManager.LoadScene(0);
    }
}
