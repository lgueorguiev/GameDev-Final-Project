using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    private readonly float speed = 1f;
    private float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        birdPrefab = Resources.Load("Bird") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            Spawn();
            timer = 5f;
        }
    }

    public void Spawn()
    {
        GameObject g = Instantiate(birdPrefab, new Vector2(Random.Range(-4f, 4f), 6f), transform.rotation * Quaternion.Euler(0f, 0f, 180f));
        g.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * speed);
    }
}
