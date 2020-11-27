using UnityEngine;

public class player : MonoBehaviour
{

    /// rigid body object for the player
    public Rigidbody2D player_rb;

    /// continuous vs. discrete movement flag
    public bool isDiscrete = true;

    // Update is called once per frame
    void Update()
    {
        Vector2 continuosIncRight = new Vector2(0.5f, 0f);
        Vector2 continuosIncLeft = new Vector2(-0.5f, 0f);

        if(isDiscrete){
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
                player_rb.MovePosition(Vector2.right + player_rb.position);
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
                player_rb.MovePosition(Vector2.left + player_rb.position);
            }
        }else{
            if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
                player_rb.MovePosition(continuosIncRight + player_rb.position);
            }
            else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
                player_rb.MovePosition(continuosIncLeft + player_rb.position);
            }
        }

    }
}
