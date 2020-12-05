using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
{
    private float moveTime;
    private float time = 0;
    private Rigidbody2D rb;
    private Vector2 moveVector = new Vector2(0, 0.05f);
    private float direction;
    private float shootTime = 4f;
    private bool enter = true;
    private float speed = 7f;
    private EnemyBase enemyBase;

    public GameObject bullet_prefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveTime = Random.Range(1f, 2f);
        direction = Random.Range(-1f, 1f);
        enemyBase = GetComponent<EnemyBase>();

    }

    // Update is called once per frame
    void Update()
    {
        BoundsCheck();
    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        
        if (time < moveTime && enter)
        {
            rb.position -= moveVector;
        }
        else
        {
            enter = false;
            moveVector.x = 0.05f;
            moveVector.y = 0f;
            if (direction >= 0)
            {
                rb.position += moveVector;
            }
            else
            {
                rb.position -= moveVector;
            }

        }

        if (time > shootTime && !enter)
        {
            Fire();
            time = 0;
        }
    }

    void Fire()
    {
        Vector2 test = new Vector2(0f, -1f);
        GameObject my_bullet = Instantiate(bullet_prefab, transform.TransformPoint(new Vector3(0, 1.5f, 0)), transform.rotation);
        my_bullet.GetComponent<Rigidbody2D>().velocity = test* speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
        if(collision.gameObject.tag == "bullet")
        {
            //Debug.Log("hit");
            enemyBase.Hit(1f);
        }
    }

    void BoundsCheck()
    {
        if (transform.position.x > 10.4f)
        {
            Vector2 pos = transform.position;
            pos.x = 10.4f;
            transform.position = pos;

            direction = direction * -1;
        }
        if (transform.position.x < -10.4f)
        {
            Vector2 pos = transform.position;
            pos.x = -10.4f;
            transform.position = pos;


            direction = direction * -1;
        }

    }
}
