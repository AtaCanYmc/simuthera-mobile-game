using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove= Input.GetAxisRaw("Horizontal")*runSpeed;
        horizontalMove = SimpleInput.GetAxis("Horizontal") * runSpeed;
        /*      if (Input.GetButtonDown("Jump")|| SimpleInput.GetButtonDown("Jump"))
               {
                   Debug.Log("sa");
                   jump = true;
               }*/
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            crouch = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = false;
        }

    }
    public void Jump()
    {
        jump = true;
        Debug.Log("sa");
    }

    private void FixedUpdate()
    {
        //move our character.
        controller.Move(horizontalMove*Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }
}
