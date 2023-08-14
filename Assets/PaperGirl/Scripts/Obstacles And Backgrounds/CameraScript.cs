using UnityEngine;

namespace Obstacles_And_Backgrounds
{
    public class CameraScript : MonoBehaviour
    {
        private Transform playerTransform;
        public float camOffSet;
    
        void Start()
        {
            playerTransform = GameObject.Find("Player").transform;
        }

        void Update()
        {
            Vector3 camPos = transform.position;
            camPos.x = playerTransform.position.x;

            camPos.x += camOffSet;
            transform.position = camPos;
        }
    }
}
