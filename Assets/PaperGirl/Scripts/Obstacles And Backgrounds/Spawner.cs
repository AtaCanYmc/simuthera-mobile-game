using System.Collections;
using UnityEngine;

namespace Obstacles_And_Backgrounds
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] prefabs;
        public int spawnFreqMin, spawnFreqMax, orderInLayer;
        public float coordY;

    
        void Start()
        {
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
            
                Instantiate(tempGameObject, new Vector3(transform.position.x, tempGameObject.transform.position.y+coordY, 1),
                    Quaternion.identity);
            
                yield return new WaitForSeconds(Random.Range(spawnFreqMin, spawnFreqMax));

            }
        }
    }
}
