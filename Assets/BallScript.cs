using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Vector2 velocity = rb.velocity;
            velocity.y = velocity.y + collision.collider.attachedRigidbody.velocity.y / 3;
            velocity.x = -velocity.x * Mathf.Abs(velocity.y);
            rb.velocity = velocity;
        }
    }
}
