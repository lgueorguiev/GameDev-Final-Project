using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float thrustSpeed = 0.25f;
    private float turnSpeed = 0.02f;
    private float health = 10f;
    private Rigidbody2D _rb;
    private Vector2 slide = new Vector2(0.2f, 0);

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        BoundsCheck();
    }

    // Controls Player movement and firing, gets called in Update
    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
            _rb.MovePosition(_rb.position + slide);
        if (Input.GetKey(KeyCode.A))
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
        if (transform.position.y > 4.8f)
        {
            Vector2 pos = transform.position;
            pos.y = 4.8f;
            transform.position = pos;

            _rb.velocity = Vector2.zero;
        }
        if (transform.position.y < -4.8f)
        {
            Vector2 pos = transform.position;
            pos.y = -4.8f;
            transform.position = pos;

            _rb.velocity = Vector2.zero;
        }

    }
}