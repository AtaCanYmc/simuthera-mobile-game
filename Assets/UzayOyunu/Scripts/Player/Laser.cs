using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    GameManagement2 Management;
    public AudioSource ExplosionSound, BonusSound;

    void Start()
    {
        Management = GameObject.Find("GameManagement").GetComponent<GameManagement2>();
        ExplosionSound = GameObject.Find("Explosion").GetComponent<AudioSource>();
        BonusSound = GameObject.Find("Bonus").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = GameObject.Find(collision.name);
        if ((collision.tag.Equals("Enemy1") || collision.tag.Equals("Enemy2") || collision.tag.Equals("Enemy3")) && !obj.GetComponent<EnemySpaceship>().isShot)
        {
            obj.GetComponent<EnemySpaceship>().isShot = true;
            ExplosionSound.Play();
            gameObject.transform.localScale = new Vector2(0, 0);
            int tempScore = Management.Score;
            if (collision.tag.Equals("Enemy1"))
                tempScore += 1;
            else if (collision.tag.Equals("Enemy2"))
                tempScore += 3;
            else
                tempScore += 5;
            Management.Score = tempScore;
            Management.ScoreText.GetComponent<UnityEngine.UI.Text>().text = ": " + Management.Score.ToString();

            int tempCount = Management.EnemyCount;
            int temp2Count = Management.frontEnemy_count;
            tempCount--;

            for(int i = 7; i < 14; i++)
            {
                if (collision.name.Equals("Enemy" + i.ToString()))
                {
                    temp2Count--;
                    break;
                }
            }
           
            Management.EnemyCount = tempCount;
            Management.frontEnemy_count = temp2Count;
            Destroy(gameObject);
        }

        else if (collision.tag.Equals("Bonus"))
        {
            BonusSound.Play();
            if (collision.name.Contains("Star"))
            {
                int NewScore = Management.Score;
                NewScore = NewScore + 3;
                Management.Score = NewScore;
                Management.ScoreText.GetComponent<UnityEngine.UI.Text>().text = ": " + NewScore.ToString();
            }

            else if (collision.name.Contains("Heart"))
            {
                int NewLife = Management.Lives;
                NewLife++;
                Management.Lives = NewLife;
                Management.LifeText.GetComponent<UnityEngine.UI.Text>().text = ": " + NewLife.ToString();
            }

            Destroy(obj);
            Destroy(gameObject);
        }
    }
}
