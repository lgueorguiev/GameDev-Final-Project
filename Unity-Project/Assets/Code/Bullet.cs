using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D bullet_rb;
    public float bullet_vel = 10f;

    // Start is called before the first frame update
    void Start()
    {
        bullet_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // firing method
    public void Fire() 
    {
        Rigidbody2D bulletClone = (Rigidbody2D) Instantiate(bullet_rb, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bullet_vel;
    }

    // Update is called once per frame
    void Update()
    {

    }


}
