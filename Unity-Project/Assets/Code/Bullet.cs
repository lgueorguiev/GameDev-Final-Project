﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        ////rb.velocity = transform.forward * speed;
    }
    /*
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
    */
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                Player player_obj = collision.gameObject.GetComponent<Player>();
                player_obj.loseHealth(damage);
            }
            Destroy(gameObject);
        }
    }

}
