using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Players
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject newspaper;
        public float moveSpeed, newspaperSpeed, shootFrequency = 1f, nextShootTime;
        public bool isMoving;
        public Text healthText;
    
        private Vector3 origPos, targetPos;
        private float timeToMove = 0.2f;
    
        private Rigidbody2D rb;
        private SpriteRenderer sr;
        private Transform muzzle;
        private PlayerManager pm;

        void Start()
        {
            muzzle = transform.GetChild(0);
            sr = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
            pm = GetComponent<PlayerManager>();
            moveSpeed = PlayerPrefs.GetFloat("MoveSpeed");
        }
    
        void FixedUpdate()
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        void Update()
        {
            if ((Input.GetKeyDown(KeyCode.DownArrow)))
            {
                MoveDown();
            }
            else if ((Input.GetKeyDown(KeyCode.UpArrow)))
            {
                MoveUp();
            }
            else if ((Input.GetKeyDown(KeyCode.Space)))
            {
                Shoot();
            }
        }

        IEnumerator MovePlayer(Vector3 direction)
        {
            isMoving = true;

            float elapsedTime = 0;

            origPos = transform.position;
            targetPos = origPos + direction;

            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, elapsedTime / timeToMove);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;

            isMoving = false;
        }

        public void Shoot()
        {
            if ((nextShootTime < Time.timeSinceLevelLoad))
            {
                if (pm.currentHealth > 0)
                {
                    nextShootTime = Time.timeSinceLevelLoad + shootFrequency;
                    pm.currentHealth--;
                    healthText.text = pm.currentHealth.ToString();

                    Transform tempNewspaper;
                    //Gazetenin sorting layer'ini player'in sorting layer'ına eşitler.
                    newspaper.GetComponent<SpriteRenderer>().sortingOrder = sr.sortingOrder;

                    //Gazete objesini oluşturur ve muzzle yönünde güç uygulayarak fırlatılmasını sağlar.
                    tempNewspaper = Instantiate(newspaper.transform, muzzle.position, Quaternion.identity);
                    tempNewspaper.GetComponent<AudioSource>().Play();
                    tempNewspaper.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * newspaperSpeed);
                }
            }
        }

        public void MoveUp()
        {
            if (!isMoving && transform.position.y < 1.2)
            {
                sr.sortingOrder--;
                StartCoroutine(MovePlayer(new Vector3(1,(float)1.6,0)));
            }
        }

        public void MoveDown()
        {
            if (!isMoving && transform.position.y > -3.5)
            {
                sr.sortingOrder++;
                StartCoroutine(MovePlayer(new Vector3(1,(float)-1.6,0)));
            }
        }
    }
}
