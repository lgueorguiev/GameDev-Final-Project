using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private float damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoundsCheck();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        if (collision.gameObject.tag == "Player")
        {
            
            // Decrease Player health
            Die();
            collision.gameObject.GetComponent<Player>().loseHealth(damage);
        }
    }

    private void BoundsCheck()
    {
        if (transform.position.y < -5f)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
