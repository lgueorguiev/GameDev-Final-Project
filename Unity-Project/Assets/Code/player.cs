using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health = 10f;
    private Rigidbody2D _rb;
    private Vector2 slide = new Vector2(0.2f, 0);
    private float initPos;
    public Scene currScene;
    public GameObject deathMenu;
    public Text healthStatus;
    public Text victory;

    public AudioSource audioSource;

    public AudioClip explosion;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        initPos = transform.position.y;
        currScene = SceneManager.GetActiveScene();
        audioSource = GetComponent<AudioSource>();
        healthStatus.text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 always = new Vector2(transform.position.x, initPos);
        transform.position = always;
        if (health <= 0f)
        {
            //audioSource.PlayOneShot(explosion, 0.2f);
            deathMenu.GetComponent<DeathMenu>().EnableMenu();
            
            Destroy(gameObject);
            //Invoke("killPlayer", 0.5f);
            
            
        }
        Movement();
        BoundsCheck();
        CheckEnd();
    }
    void killPlayer()
    {
        Destroy(gameObject);
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
        audioSource.PlayOneShot(explosion, 0.2f);
        health -= amount;
        Debug.Log(health);
        healthStatus.text = "Health: " + health.ToString();
    }

    public void CheckEnd()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0 && SceneManager.GetActiveScene().buildIndex + 1 <= 9)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (enemies.Length <= 0 && SceneManager.GetActiveScene().buildIndex == 9)
        {
            victory.enabled = true;
            Time.timeScale = 0;
        }
    }
}