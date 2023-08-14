using UnityEngine;

namespace Obstacles_And_Backgrounds
{
    public class FlippedScript : MonoBehaviour
    {
        void Start()
        {

            int random = Random.Range(0, 2);
            Vector3 newScale = gameObject.transform.localScale;

            if (random == 1) newScale.x *= -1;
            gameObject.transform.localScale = newScale;
        }
    }
}