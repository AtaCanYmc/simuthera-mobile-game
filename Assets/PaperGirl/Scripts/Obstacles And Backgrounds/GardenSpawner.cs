using System.Collections;
using UnityEngine;

namespace Obstacles_And_Backgrounds
{
    public class GardenSpawner : MonoBehaviour
    {

        public GameObject[] prefabs;
        public int spawnFreqMin, spawnFreqMax, orderInLayer;
        public GameObject launcher;
        public GameObject message;

        void Start()
        {
            spawnFreqMin = PlayerPrefs.GetInt("homeFreqMin");
            spawnFreqMax = PlayerPrefs.GetInt("homeFreqMax");
            StartCoroutine(Spawn());
        }

        public IEnumerator Spawn()
        {
            int temp = 0;
            int randomSpawn = Random.Range(0, prefabs.Length);
            GameObject tempGameObject;
            while (true)
            {
                while (temp == randomSpawn)
                {
                    randomSpawn = Random.Range(0, prefabs.Length);
                }
                temp = randomSpawn;

                tempGameObject = prefabs[randomSpawn];
                tempGameObject.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;

                Instantiate(tempGameObject, new Vector3(transform.position.x, tempGameObject.transform.position.y, 1), Quaternion.identity);

                int randomRequest = Random.Range(0, 2);
                if (tempGameObject.CompareTag("Home") && randomRequest == 1)
                {
                    int random = Random.Range(5, 9);
                    launcher.GetComponent<SpriteRenderer>().sortingOrder = random;
                    Instantiate(launcher, new Vector3((float)transform.position.x - 0.5f, (float)(launcher.transform.position.y - (random - 5) * 1.6), 1), Quaternion.identity);
                    Instantiate(message, new Vector3((float)transform.position.x - 1, transform.position.y, 1), Quaternion.identity);
                }
                yield return new WaitForSeconds(Random.Range(spawnFreqMin, spawnFreqMax));

            }

        }
    }
}
