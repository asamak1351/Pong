using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public bool LeftPlayer;
    public int score;
    Rigidbody2D myrigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftPlayer)
        {
            if (Input.GetKey(KeyCode.W))
            {
                myrigidbody.AddForce(Vector2.up * speed * Time.deltaTime);
            }           
            if (Input.GetKeyUp(KeyCode.W))
            {
                myrigidbody.velocity = Vector3.zero;
                myrigidbody.Sleep();
            }
            if (Input.GetKey(KeyCode.S))
            {
                myrigidbody.AddForce(Vector2.down * speed * Time.deltaTime);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                myrigidbody.velocity = Vector3.zero;
                myrigidbody.Sleep();
            }
        }
        if (!LeftPlayer)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                myrigidbody.AddForce(Vector2.up * speed * Time.deltaTime);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                myrigidbody.velocity = Vector3.zero;
                myrigidbody.Sleep();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                myrigidbody.AddForce(Vector2.down * speed * Time.deltaTime);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                myrigidbody.velocity = Vector3.zero;
                myrigidbody.Sleep();
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            myrigidbody.velocity = Vector2.zero;
            myrigidbody.Sleep();
            
        }
    }
}


