using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    Rigidbody2D ballrigidbody;
    public float speed;
    public float addedspeed;
    GameController cont;

    // Start is called before the first frame update
    void Start()
    {
        ballrigidbody = GetComponent<Rigidbody2D>();
        cont = FindObjectOfType<GameController>();
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameStart()
    {
        transform.position=(new Vector3(0, 0, 0));
        new WaitForSeconds(5);
        float x = Random.Range(0, 2);
        float y = Random.Range(-45, 46);
        if (x == 0)
        {
            x = -1;
            
        }
        else if (x == 1)
        {
            x = 1;
        }
        
        ballrigidbody.AddForce(new Vector2(x*speed,y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector2 vel;
            if (ballrigidbody.position.x < 0)
            {
                vel.x = ballrigidbody.velocity.x+addedspeed;
            }
            else
            {
                vel.x = ballrigidbody.velocity.x - addedspeed;
            }
            vel.y = (ballrigidbody.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 2);

            ballrigidbody.velocity = vel;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            if (ballrigidbody.velocity.x < 0)
            {
                cont.Score(false);
            }
            if(ballrigidbody.velocity.x > 0)
            {
                cont.Score(true);
            }
            ballrigidbody.velocity = Vector2.zero;
            new WaitForSeconds(5);
            GameStart();
        }
    }
}
