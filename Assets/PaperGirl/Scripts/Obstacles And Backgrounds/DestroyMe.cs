using UnityEngine;

namespace Obstacles_And_Backgrounds
{
    public class DestroyMe : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
