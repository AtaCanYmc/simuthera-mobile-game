using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    private int ID = 0;
    public float Speed = 10.0f, laserSpeed = 10.0f;
    private float FireDelay = 0.25f, FireInterval = 0.5f;
    private bool StartedFiring = false;
    public Rigidbody2D rb;
    public AudioSource audioSrc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        rb.velocity = new Vector2(SimpleInput.GetAxis("Horizontal") * Speed, 0);
    }

    void Fire()
    {
        GameObject laser1 = (GameObject)Resources.Load("Prefabs\\Laser4", typeof(GameObject));
        GameObject laser = Instantiate(laser1, new Vector3(transform.position.x, transform.position.y + 1.151f, 0), Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
        laser.name = "UsrLaser" + ID.ToString();
        ID++;
        audioSrc.Play();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3") || collision.name.Contains("Heart") || collision.name.Contains("Star")) && !StartedFiring)
        {
            InvokeRepeating("Fire", FireDelay, FireInterval);
            StartedFiring = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3") || collision.name.Contains("Heart") || collision.name.Contains("Star")) && !StartedFiring)
        {
            InvokeRepeating("Fire", FireDelay, FireInterval);
            StartedFiring = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3") || collision.name.Contains("Heart") || collision.name.Contains("Star")) && StartedFiring)
        {
            CancelInvoke();
            StartedFiring = false;
        }
    }
}
