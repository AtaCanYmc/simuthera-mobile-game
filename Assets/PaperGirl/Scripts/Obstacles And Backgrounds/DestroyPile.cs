using UnityEngine;

namespace Obstacles_And_Backgrounds
{
    public class DestroyPile : MonoBehaviour
    {

        private SpriteRenderer sr;

        void OnTriggerEnter2D(Collider2D other)
        {
            sr = GetComponent<SpriteRenderer>();
            SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();
            if (sr2.sortingOrder == sr.sortingOrder)
            {
                Destroy(gameObject);
            }
        }
    }
}
