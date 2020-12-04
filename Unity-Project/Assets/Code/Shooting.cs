using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullet_prefab;
    public float speed = 10f;

    // firing method
    void Fire() 
    {
        Vector2 test = new Vector2(0f, 1f);
        GameObject my_bullet = Instantiate(bullet_prefab, transform.TransformPoint(new Vector3(0, 1.25f, 0)), transform.rotation); 
        my_bullet.GetComponent<Rigidbody2D>().velocity = test * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Fire();
    }

}
