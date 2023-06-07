using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 10f;
    public float minSpeed = 5f;
    public float maxSpeed = 15f;
    [Range(-6f, 6f)]
    public float multiplier = 3f;
    public Rigidbody2D rb;
    // Start is called before the first frame update

    Vector2 lastVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(speed * 15, speed * 15));
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float y = 0;
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        Vector2 velocity = direction * Mathf.Max(Mathf.Min(maxSpeed, speed), minSpeed);

        if(collision.gameObject.tag == "Player")
        {
            Vector2 paddlePos = collision.gameObject.transform.position;
            Vector2 ballPos = transform.position;
            y = ballPos.y - paddlePos.y;
            y *= multiplier;
        }
        if(velocity.x == Mathf.Epsilon)
        {
            velocity.x = Random.Range(-10f, 10f);
        }
        rb.velocity = new Vector2(velocity.x, velocity.y + y);
    }
}
