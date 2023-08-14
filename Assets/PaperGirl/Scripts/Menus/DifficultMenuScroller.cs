using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class DifficultMenuScroller : MonoBehaviour
    {
        public Button easy, normal, hard;
    
        public float finalPosY;
    
        private Vector3 origPos, targetPos;
        private float timeToMove = 0.9f;
        private SpriteRenderer sr;
        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            StartCoroutine(ScrollMenu(new Vector3(0, finalPosY,0)));
        }

        IEnumerator ScrollMenu(Vector3 direction)
        {
            float elapsedTime = 0;

            origPos = transform.position;
            targetPos = direction;

            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, elapsedTime / timeToMove);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        
            transform.position = targetPos;
            sr.sortingOrder = 5;
            easy.gameObject.SetActive(true);
            normal.gameObject.SetActive(true);
            hard.gameObject.SetActive(true);
        }
    }
}
