using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    GameManagement management;
    SpriteRenderer spriteRenderer;
    string TileType;
    
    void Start()
    {
        management = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        TileType = gameObject.tag;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Background"))
        {
            if (spriteRenderer.material.color != Color.green && Time.timeScale != 0)
            {
                int live = management.Lives;
                live--;
                management.Lives = live;
                management.LifeText.text = ": " + management.Lives.ToString();
            }
            
            Destroy(this.gameObject);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            spriteRenderer.material.SetColor("_Color", Color.green);
            if (TileType.Equals("FallingTile"))
            {
                management.Score++;
            }

            else if (TileType.Equals("BonusTile"))
            {
                management.Score += 3; // Değiştirilebilir
            }

            else if (TileType.Equals("StarTile"))
            {
                management.Score += 5; // Değiştirilebilir
            }

            else if (TileType.Equals("LifeTile"))
            {
                management.Lives++; // Değiştirilebilir?
                management.LifeText.text = ": " + management.Lives.ToString();
            }
            
            management.ScoreText.text = ": " + management.Score.ToString();
        }
         
    }
}
