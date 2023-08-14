using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpaceship : MonoBehaviour
{
    public float laserSpeed = 10.0f;
    public Rigidbody2D rb;
    public Collider2D cd;
    public float Speed = 2.00f; 
    public float MoveTime = 2.00f;
    private bool isCollided = false;
    public bool isFront = false, isShot = false, scaleUp = false;
    GameManagement2 Management;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        Management = GameObject.Find("GameManagement").GetComponent<GameManagement2>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!Management.GameDiff.Equals("Easy"))
        {
            transform.position += Vector3.down * Time.deltaTime * 0.50f;
        }  

        if (isShot)
        {
            cd.enabled = false;
            float scaleX = gameObject.transform.localScale.x;
            float scaleY = gameObject.transform.localScale.y;
            if (!scaleUp)
            {
                gameObject.transform.localScale = new Vector3(scaleX * 2.5f, scaleY * 2.5f, -1.89f);
                scaleUp = true;
            }
            anim.Play("Explode");
            Destroy(gameObject, 0.417f);
        }
    }

    public void EnemyFire(int ID)
    {
        if (gameObject.tag.Equals("Enemy1") && (isFront || !isCollided))
        {
            GameObject laser1 = (GameObject)Resources.Load("Prefabs\\Laser1", typeof(GameObject));
            GameObject enemylaser = Instantiate(laser1, new Vector3(transform.position.x, transform.position.y - 1.326f, 0), Quaternion.identity);
            enemylaser.name = "EnemyLsr" + ID.ToString();
            enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed); 
        }
        
        if (gameObject.tag.Equals("Enemy2") && (isFront || !isCollided)) {
            GameObject laser2 = (GameObject)Resources.Load("Prefabs\\Laser2", typeof(GameObject));
            GameObject enemylaser = Instantiate(laser2, new Vector3(transform.position.x, transform.position.y - 1.344f, 0), Quaternion.identity);
            enemylaser.name = "EnemyLsr" + ID.ToString();
            enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
        }
        
        if (gameObject.tag.Equals("Enemy3") && (isFront || !isCollided))
        {
            GameObject laser3 = (GameObject)Resources.Load("Prefabs\\Laser3", typeof(GameObject));
            GameObject enemylaser = Instantiate(laser3, new Vector3(transform.position.x - 0.421f, transform.position.y - 0.974f, 0), Quaternion.identity);
            GameObject enemylaser2 = Instantiate(laser3, new Vector3(transform.position.x + 0.421f, transform.position.y - 0.974f, 0), Quaternion.identity);
            enemylaser.name = "EnemyLsr" + ID.ToString();
            enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
            enemylaser2.name = "EnemyLsr" + (ID + 1).ToString();
            enemylaser2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
        }
        isCollided = false;
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3"))
        {
            isCollided = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3"))
        {
            isCollided = true;
        }
    }
}
