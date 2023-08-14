using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class DifficultyManager : MonoBehaviour
    {
        private AudioSource audioSource;
        public GameObject soundOn, soundOff, infoImage, infoButton, closeInfoButton, easyButton, normalButton, hardButton;

        void Start()
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            PlayerPrefs.SetInt("isMute", 0);
            audioSource = GetComponent<AudioSource>();
        }
    
        public void Easy()
        {
            PlayerPrefs.SetFloat("MoveSpeed", 4);
            PlayerPrefs.SetInt("Health", 15);
            PlayerPrefs.SetInt("directionX", 2);
            PlayerPrefs.SetInt("directionY", 3);
            PlayerPrefs.SetInt("homeFreqMin", 6);
            PlayerPrefs.SetInt("homeFreqMax", 8);
            PlayerPrefs.SetInt("carFreqMin", 6);
            PlayerPrefs.SetInt("carFreqMax", 8);
            SceneManager.LoadScene(18);
        }

        public void Normal()
        {
            PlayerPrefs.SetFloat("MoveSpeed", 6);
            PlayerPrefs.SetInt("Health", 10);
            PlayerPrefs.SetInt("directionX", 3);
            PlayerPrefs.SetInt("directionY", 4);
            PlayerPrefs.SetInt("homeFreqMin", 3);
            PlayerPrefs.SetInt("homeFreqMax", 5);
            PlayerPrefs.SetInt("carFreqMin", 3);
            PlayerPrefs.SetInt("carFreqMax", 5);
            SceneManager.LoadScene(18);
        }

        public void Hard()
        {
            PlayerPrefs.SetFloat("MoveSpeed", 9);
            PlayerPrefs.SetInt("Health", 5);
            PlayerPrefs.SetInt("directionX", 5);
            PlayerPrefs.SetInt("directionY", 5);
            PlayerPrefs.SetInt("homeFreqMin", 2);
            PlayerPrefs.SetInt("homeFreqMax", 4);
            PlayerPrefs.SetInt("carFreqMin", 1);
            PlayerPrefs.SetInt("carFreqMax", 3);
            SceneManager.LoadScene(18);
        }

        public void Sound()
        {
            if (PlayerPrefs.GetInt("isMute") == 0)
            {
                soundOn.SetActive(false);
                soundOff.SetActive(true);
                audioSource.Stop();            
                PlayerPrefs.SetInt("isMute", 1);
            }
            else
            {
                soundOn.SetActive(true);
                soundOff.SetActive(false);
                audioSource.Play();
                PlayerPrefs.SetInt("isMute", 0);
            }
        }

        public void Info()
        {
            infoImage.SetActive(true);
            closeInfoButton.SetActive(true);
            easyButton.SetActive(false);
            normalButton.SetActive(false);
            hardButton.SetActive(false);
        }

        public void CloseInfo()
        {
            infoImage.SetActive(false);
            closeInfoButton.SetActive(false);
            easyButton.SetActive(true);
            normalButton.SetActive(true);
            hardButton.SetActive(true);
        }

        public void Home()
        {
            SceneManager.LoadScene(0);  
        }
    }
}
