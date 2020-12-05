using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float cooldown_time = 0;
    public GameObject bullet_prefab;
    public GameObject missile_prefab;
    public float speed = 10f;

    // firing method
    void Fire()
    {
        Vector2 test = new Vector2(0f, 1f);
        GameObject my_bullet = Instantiate(bullet_prefab, transform.TransformPoint(new Vector3(0, 1.25f, 0)), transform.rotation);
        my_bullet.GetComponent<Rigidbody2D>().velocity = test * speed;
    }

    void FireMissile()
    {
        Vector2 test = new Vector2(0f, 1f);
        GameObject my_missile = Instantiate(missile_prefab, transform.TransformPoint(new Vector3(0, 1.25f, 0)), transform.rotation);
        my_missile.GetComponent<Rigidbody2D>().velocity = test * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown_time > 0f)
        {
            float seconds = Mathf.FloorToInt(cooldown_time % 60);
            cooldown_time -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && cooldown_time <= 0f)
        {
            FireMissile();
            cooldown_time = 3f;
        }
    }

}