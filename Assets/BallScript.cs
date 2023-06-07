using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 15f;
    public float minSpeed = 10f;
    public float maxSpeed = 30f;
    [Range(-6f, 6f)]
    public float multiplier = 3f;
    public Rigidbody2D rb;
    // Start is called before the first frame update

    Vector2 lastVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(speed * 15, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(rb.velocity.x, 0))
        {
           rb.AddForce(new Vector2(speed * 15 * Mathf.Sign(rb.velocity.x), 0));
        }
        lastVelocity = rb.velocity;
    }

    public void ResetBall(float direction)
    {
        transform.position = Vector2.zero;
        if(direction > 0)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float y = 0;
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        Vector2 velocity = direction * Mathf.Max(Mathf.Min(maxSpeed, speed), minSpeed);
        
        if(collision.gameObject.tag == "Destroyer")
        {
            velocity.y = 0;
        }
        else if(collision.gameObject.tag == "Player")
        {
            Vector2 paddlePos = collision.gameObject.transform.position;
            Vector2 ballPos = transform.position;
            y = ballPos.y - paddlePos.y;
            if (Mathf.Approximately(velocity.y, 0))
            {
                velocity.y = - rb.velocity.y / multiplier;
            }
            y *= multiplier;
        }
        rb.velocity = new Vector2(velocity.x, velocity.y + y);
    }
}
