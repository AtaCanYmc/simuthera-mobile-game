using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Players
{
    public class PlayerManager : MonoBehaviour
    {
        public int currentHealth, aimHomeNum, currentHomeNum, directionX, directionY; 
        public bool isDead = false;
        public Text healthText, scoreText, highScoreText, aimHomeNumText, currentHomeNumText;
        public GameObject throwObject;
    
        private int score, highScore;
        private float decimalScore;
        private PlayerController pc;
        private SpriteRenderer sr;
        private Transform muzzle;
        public AudioClip UpgradeSesi;

        void Start()
        {
            muzzle = transform.GetChild(0);
            pc = GetComponent<PlayerController>();
            sr = GetComponent<SpriteRenderer>();

            directionX = PlayerPrefs.GetInt("directionX");
            directionY = PlayerPrefs.GetInt("directionY");
        
            currentHealth = PlayerPrefs.GetInt("Health");
            healthText.text = currentHealth.ToString();
        
            aimHomeNumText.text = aimHomeNum.ToString();
            currentHomeNumText.text = currentHomeNum.ToString();
        
            highScore = PlayerPrefs.GetInt("PGHighScore");
            highScoreText.text = highScore.ToString();
        }

        void Update()
        {
            decimalScore += 50 * Time.deltaTime;
            score = Mathf.RoundToInt(decimalScore);
            scoreText.text = score.ToString();
            currentHomeNumText.text = currentHomeNum.ToString();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();
            if (other.CompareTag("Obstacle") && sr.sortingOrder == sr2.sortingOrder)
            {
                GetComponent<AudioSource>().Play();
                if (currentHealth == 0)                 // bir if else ile 
                {
                    KillSelf();
                    pc.moveSpeed = 0;
                    if (score > highScore)
                    {
                        PlayerPrefs.SetInt("PGHighScore", score);
                    }
                    PlayerPrefs.SetInt("Score", score);
                    PlayerPrefs.SetInt("isWin", 0);        // 0 for lose, 1 for win
                    SceneManager.LoadScene("FinalScene");
                }
                else
                {
                    currentHealth--;
                    healthText.text = currentHealth.ToString();    
                }
            }
            else if (other.CompareTag("NewspaperPile") && sr.sortingOrder == sr2.sortingOrder)
            {
                currentHealth++;
                healthText.text = currentHealth.ToString();
                GetComponent<AudioSource>().PlayOneShot(UpgradeSesi);
            }
            else if (other.CompareTag("Ellipse") && sr.sortingOrder == sr2.sortingOrder && currentHealth > 0)
            {
                currentHealth--;
                Throw();
                healthText.text = currentHealth.ToString();
            }
            else if (other.CompareTag("Finish"))    //OYUN TAMAMLANIRSA !!!
            {
                Time.timeScale = 1;     /////
                //pc.moveSpeed = 0;
            
                // SCORE += (CURRENTHEALTH * POİNT) + FİNİSH POİNT//
                score += (currentHealth * 1000) + 3000;
                if (score > highScore)
                {
                    PlayerPrefs.SetInt("PGHighScore", score);
                }
                PlayerPrefs.SetInt("Score", score);
                PlayerPrefs.SetInt("isWin", 1);        // 0 for lose, 1 for win
                SceneManager.LoadScene("FinalScene");
            }
        }

    
        private void Throw()
        {
            Transform tempThrowObject;
            throwObject.GetComponent<SpriteRenderer>().sortingOrder = sr.sortingOrder;
            tempThrowObject = Instantiate(throwObject.transform, muzzle.position, Quaternion.identity);
            tempThrowObject.GetComponent<NewspaperRuloForHome>().İnitialize(new Vector2(4, 4));
        }
    
        private void KillSelf()
        {
            isDead = true;
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
