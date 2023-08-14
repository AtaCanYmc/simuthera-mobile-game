using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menus
{
    public class FinalMenuManager : MonoBehaviour
    {
        public GameObject win,lose;
        public Text score, highscore;
        private int isWin;
    
        void Start()
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            isWin = PlayerPrefs.GetInt("isWin");
            if (isWin == 1)
            {
                win.SetActive(true);
            }
            else
            {            
                lose.SetActive(true);
            }
            score.text = PlayerPrefs.GetInt("Score").ToString();
            highscore.text = PlayerPrefs.GetInt("PGHighScore").ToString();
        }
    
        public void RestartButton()
        {
            SceneManager.LoadScene(18);
        }

        public void HomeButton()
        {
            SceneManager.LoadScene(0);  
        }

        public void DifficultyButton()
        {
            SceneManager.LoadScene(17);
        }
    }
}
