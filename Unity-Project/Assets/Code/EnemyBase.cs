using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float health = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Hit(float damage)
    {
        health -= damage;
        //Debug.Log(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
