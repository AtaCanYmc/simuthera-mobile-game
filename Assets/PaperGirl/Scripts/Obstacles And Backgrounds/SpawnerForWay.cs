using System.Collections;
using UnityEngine;

namespace Obstacles_And_Backgrounds
{
    public class SpawnerForWay : MonoBehaviour
    {
        public GameObject[] prefabs;
        public int spawnFreqMin, spawnFreqMax;

    
        void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            int temp = 0, randomSpawn = Random.Range(0, prefabs.Length);
            while (true)
            {
                int randomLine = Random.Range(0, 2);
                while (temp == randomSpawn)
                {
                    randomSpawn = Random.Range(0, prefabs.Length);
                }
                temp = randomSpawn;

                GameObject tempGameObject = prefabs[randomSpawn];
                if (randomLine == 0)
                {
                    tempGameObject.GetComponent<SpriteRenderer>().sortingOrder = 6;
                
                    Instantiate(tempGameObject, new Vector3(transform.position.x, tempGameObject.transform.position.y, 1),
                        Quaternion.identity);
                }
                else
                {
                    tempGameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
                
                    Instantiate(tempGameObject, new Vector3(transform.position.x, (float) (tempGameObject.transform.position.y-(1.6)), 1),
                        Quaternion.identity);
                }

                yield return new WaitForSeconds(Random.Range(spawnFreqMin, spawnFreqMax));
            }
        }
    }
}
