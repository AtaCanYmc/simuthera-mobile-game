using UnityEngine;

namespace Obstacles_And_Backgrounds
{
    public class FlashScript : MonoBehaviour
    {
        private Material matWhite;
        private Material matDefault;
        private SpriteRenderer sr;
        // Start is called before the first frame update
        void Start()
        {

            sr = GetComponent<SpriteRenderer>();

            matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
            matDefault = sr.material;

        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();
            if (other.CompareTag("Player") && sr.sortingOrder == sr2.sortingOrder)
            {
                sr.material = matWhite;
                Invoke(nameof(ResetMaterial), .1f);
                Invoke(nameof(DestroyObject), .1f);
            }
        
            if (other.CompareTag("Newspaper") && sr.sortingOrder == sr2.sortingOrder)
            {
                sr.material = matWhite;
                GetComponent<AudioSource>().Play();
                Invoke(nameof(ResetMaterial), .1f);
                Invoke(nameof(DestroyObject), .1f);
                Destroy(other.gameObject);
            }
        }
        void ResetMaterial()
        {
            sr.material = matDefault;
        }
    
        void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}
