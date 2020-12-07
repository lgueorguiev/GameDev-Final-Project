using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float health = 10f;
    public AudioSource audioSource;

    public AudioClip explosion;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Hit(float damage)
    {
        health -= damage;
        Debug.Log(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            audioSource.PlayOneShot(explosion, 0.2f);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
        if (collision.gameObject.tag == "bullet")
        {
            //Debug.Log("hit");
            Hit(1f);
        }
        if (collision.gameObject.tag == "missle")
        {
            //Debug.Log("hit");
            Hit(10f);
        }
    }
}
