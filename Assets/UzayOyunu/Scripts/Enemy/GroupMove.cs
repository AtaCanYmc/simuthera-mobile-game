using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupMove : MonoBehaviour
{
    public float Speed = 2.00f;
    public bool isTouched = false;
    public int r;

    void Start()
    {
        r = Random.Range(1, 3);
    }

    void FixedUpdate()
    {
        Movement();

        if (transform.position.x < -5f || transform.position.x > 5f)
        {   
            if(!isTouched)
                isTouched = true;

            else
                isTouched = false;
        }

    }

    void Movement()
    {
        
        if (r == 1)
        {
            if (!isTouched)
            {
                transform.Translate(Speed * Time.deltaTime, 0, 0);
            }

            else
            {
                transform.Translate(-Speed * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            if (!isTouched)
            {
                transform.Translate(-Speed * Time.deltaTime, 0, 0);
            }

            else
            {
                transform.Translate(Speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
