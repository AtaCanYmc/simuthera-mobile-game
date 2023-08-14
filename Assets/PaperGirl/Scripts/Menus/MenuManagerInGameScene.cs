using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class MenuManagerInGameScene : MonoBehaviour
    {
        public GameObject inGameScreen, pauseScreen;

        private void Start()
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        public void PauseButton()
        {
            Time.timeScale = 0;
            inGameScreen.SetActive(false);
            pauseScreen.SetActive(true);
        }

        public void ContinueButton()
        {
            Time.timeScale = 1;
            inGameScreen.SetActive(true);
            pauseScreen.SetActive(false);
        }

        public void RestartButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(18);
        }

        public void HomeButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);  
        }

        public void DifficultyButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(17);
        }
    }
}
