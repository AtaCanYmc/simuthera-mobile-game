using UnityEngine;

namespace Players
{
    public class NewspaperManager : MonoBehaviour
    {
        public float lifeTime, rotSpeed;
    
        void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        private void Update()
        {
            transform.Rotate (0,0,-rotSpeed);
        }

    }
}
