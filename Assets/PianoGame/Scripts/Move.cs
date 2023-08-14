using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    GameObject playerTile;

    void Start()
    {
        playerTile = GameObject.Find("Player");
    }

    public void tile1()
    {
        playerTile.transform.position = playerTile.GetComponent<UserTile>().Tile1;
    }

    public void tile2()
    {
        playerTile.transform.position = playerTile.GetComponent<UserTile>().Tile2;
    }

    public void tile3()
    {
        playerTile.transform.position = playerTile.GetComponent<UserTile>().Tile3;
    }

    public void tile4()
    {
        playerTile.transform.position = playerTile.GetComponent<UserTile>().Tile4;
    }

}
