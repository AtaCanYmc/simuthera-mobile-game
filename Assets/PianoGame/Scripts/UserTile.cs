using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTile : MonoBehaviour
{
    public Vector3 Tile1, Tile2, Tile3, Tile4;
    Vector3 CurrentPosition;
    public bool Touched = false;

    void Start()
    {
        int randomStart = Random.Range(1, 5);
        switch (randomStart) {
            case 1:
                gameObject.transform.position = Tile1;
                break;
            case 2:
                gameObject.transform.position = Tile2;
                break;
            case 3:
                gameObject.transform.position = Tile3;
                break;
            default:
                gameObject.transform.position = Tile4;
                break;
        }
        
    }

    void Update()
    {
        if(Time.timeScale != 0.0f)
        {
            Move();
        }
    }

    void Move()
    {
        GameObject Player = GameObject.Find("Player");
        CurrentPosition = Player.transform.position;

        if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && CurrentPosition != Tile1)
        {
            if (CurrentPosition == Tile2) Player.transform.position = Tile1;
            else if (CurrentPosition == Tile3) Player.transform.position = Tile2;
            else if (CurrentPosition == Tile4) Player.transform.position = Tile3;
        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && CurrentPosition != Tile4)
        {
            if (CurrentPosition == Tile1) Player.transform.position = Tile2;
            else if (CurrentPosition == Tile2) Player.transform.position = Tile3;
            else if (CurrentPosition == Tile3) Player.transform.position = Tile4;
        }
    }
}
