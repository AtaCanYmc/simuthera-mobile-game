using UnityEngine;

namespace Players
{
    public class NewspaperLauncher : MonoBehaviour
    {
        private SpriteRenderer sr;
        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();
            if (other.CompareTag("Obstacle") && sr.sortingOrder == sr2.sortingOrder)
            {
                Destroy(other.gameObject);
            }
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();
            if (other.CompareTag("Obstacle") && sr.sortingOrder == sr2.sortingOrder)
            {
                Destroy(other.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();
            if (other.CompareTag("Obstacle") && sr.sortingOrder == sr2.sortingOrder)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
