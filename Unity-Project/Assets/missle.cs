using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;
    public float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ////Debug.Log(hitInfo.name);
        
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
