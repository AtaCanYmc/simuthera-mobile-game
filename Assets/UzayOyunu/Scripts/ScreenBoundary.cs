using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundary : MonoBehaviour
{
    public GameManagement2 management;
    public GameObject player;
   
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Player")) {
            
            if (player.activeSelf)
            {
                float magnitude = 10000f;
                var force = transform.position - player.transform.position;
                force.Normalize();
                player.GetComponent<Rigidbody2D>().AddRelativeForce(force * magnitude);
            }
        }

        else if(collision.tag.Equals("Laser"))
        {
            Destroy(GameObject.Find(collision.name));
        }

        if ((collision.tag.Equals("Enemy2") || collision.tag.Equals("Enemy3")) && collision.transform.position.y < -10.6f)
        {
            Destroy(GameObject.Find(collision.name));
            int newEnemyCnt = management.EnemyCount;
            newEnemyCnt--;
            management.EnemyCount = newEnemyCnt;
        }
    }
}
