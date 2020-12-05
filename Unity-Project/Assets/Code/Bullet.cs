using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;

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
        Debug.Log(collision.gameObject.tag);
        Destroy(gameObject);
    }

}
