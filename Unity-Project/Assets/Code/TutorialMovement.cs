using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
{
    private float moveTime;
    private float time = 0;
    private Rigidbody2D rb;
    private Vector2 moveVector = new Vector2(0, 0.05f);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveTime = Random.Range(1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        
        if (time < moveTime)
        {
            rb.position -= moveVector;
        }
        //else()
    }
}
