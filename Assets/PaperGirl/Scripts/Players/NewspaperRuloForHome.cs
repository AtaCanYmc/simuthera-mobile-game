using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class NewspaperRuloForHome : MonoBehaviour
    {
        private PlayerManager pm;
        [SerializeField]
        private float speed, rotSpeed;
        private Rigidbody2D newspaper;
        private Vector2 direction;

        void Start()
        {
            newspaper = GetComponent<Rigidbody2D>();
            pm = GameObject.Find("Player").GetComponent<PlayerManager>();
            GetComponent<AudioSource>().Play();
            pm.currentHomeNum++;
        }

        void FixedUpdate()
        {
            newspaper.velocity = direction * speed;
            transform.Rotate(0, 0, -rotSpeed);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        public void İnitialize(Vector2 direct)
        {
            direction = direct;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Home"))
            {
                Destroy(gameObject);
            }
        }
    }
}
