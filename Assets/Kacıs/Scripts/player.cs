using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;

    public int hiz = 0;
    Vector2 v2;
    public GameObject groundcheck;
    float horizantalMove = 0f;
    public float runspeed = 40f;
    // Start is called before the first frame update
    public Transform yer;
    void Start()
    {
        v2 = new Vector2(hiz, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(v2 * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(-v2 * Time.deltaTime);

        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // If the Collider2D component is enabled on the collided object
        if (coll.collider.tag == "zemin")
        {
            // Disables the Collider2D component
            Debug.Log("hit");

        }
    }

    public void hareket(int yön)
    {
        rb.AddForce(yön * v2 * Time.deltaTime);
    }


}
