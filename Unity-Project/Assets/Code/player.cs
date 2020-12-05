using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float health = 10f;
    private Rigidbody2D _rb;
    private Vector2 slide = new Vector2(0.2f, 0);
    private float initPos;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        initPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 always = new Vector2(transform.position.x, initPos);
        transform.position = always;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
        Movement();
        BoundsCheck();
    }

    // Controls Player movement and firing, gets called in Update
    void Movement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            _rb.MovePosition(_rb.position + slide);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            _rb.MovePosition(_rb.position - slide);  
    }

    // Keeps Player within Main Camera
    void BoundsCheck()
    {
        if (transform.position.x > 10.4f)
        {
            Vector2 pos = transform.position;
            pos.x = 10.4f;
            transform.position = pos;

            _rb.velocity = Vector2.zero;
        }
        if (transform.position.x < - 10.4f)
        {
            Vector2 pos = transform.position;
            pos.x = -10.4f;
            transform.position = pos;


            _rb.velocity = Vector2.zero;
        }

    }
    public void loseHealth(float amount)
    {
        health -= amount;
        Debug.Log(health);
    }
}