﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    public int Lifes;
    public Text LifesText;
    public Text GameOverText;
    public Vector3 SpawnPointCameraRelative;
    public GameObject Explosion;
    // Use this for initialization
    void Start()
    {
        Respawn();
        LifesText.text = ""+Lifes;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Shoot>().enabled = false;
        GameObject NewExplosion = (GameObject)Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    void Respawn()
    {
        transform.position = Camera.main.ViewportToWorldPoint(SpawnPointCameraRelative);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Shoot>().enabled = true;
    }

    void ReduceLife()
    {
        Lifes--;
        LifesText.text = ""+Lifes;
        if (Lifes < 0)
            Lifes = 0;
    }

    void GameOver()
    {
        GameOverText.text = "GameOver";
        Destroy(gameObject);
    }

    public IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("BulletEnemy"))
        {
            if (collision.gameObject.CompareTag("BulletEnemy")) Destroy(collision.gameObject);
            ReduceLife();
            Explode();
            if(Lifes <= 0)
            {
                GameOver();
                yield return 0;
            }
            yield return new WaitForSeconds(1);
            Respawn();
        }
    }
}