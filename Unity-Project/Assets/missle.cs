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

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        ////Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
