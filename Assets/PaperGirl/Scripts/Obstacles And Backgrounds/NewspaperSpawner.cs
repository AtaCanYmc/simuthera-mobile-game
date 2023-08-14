using System.Collections;
using UnityEngine;

namespace Obstacles_And_Backgrounds
{
    public class NewspaperSpawner : MonoBehaviour
    {
        public GameObject newspaper;
        public int spawnFreqMin, spawnFreqMax;
        private SpriteRenderer sr;

        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            StartCoroutine(Spawn());
        }
        public IEnumerator Spawn()
        {
            while (true)
            {
                int random = Random.Range(5, 9);
                newspaper.GetComponent<SpriteRenderer>().sortingOrder = random;
                Instantiate(newspaper, new Vector3(transform.position.x, (float)(transform.position.y - (random - 5) * 1.6), 1), Quaternion.identity);

                yield return new WaitForSeconds(Random.Range(spawnFreqMin, spawnFreqMax));
            }
        }
    }
}
