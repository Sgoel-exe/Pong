using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAI : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 10f;
    public GameObject ball;
    public float lerpSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    float calculateWhereToMove()
    {
        return ball.transform.position.y - transform.position.y;
    }

    bool isBallMovingTowardsMe()
    {
        return ball.GetComponent<Rigidbody>().velocity.x > 0;
    }
    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(0, Mathf.Sign(calculateWhereToMove())*speed);
    }

    void FixedUpdate()
    {
        if (ball.transform.position.y > transform.position.y)
        {
            if (rigidBody.velocity.y < 0) rigidBody.velocity = Vector2.zero;
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.up * speed, lerpSpeed * Time.deltaTime);
        }
        else if (ball.transform.position.y < transform.position.y)
        {
            if (rigidBody.velocity.y > 0) rigidBody.velocity = Vector2.zero;
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.down * speed, lerpSpeed * Time.deltaTime);
        }
        else
        {
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero * speed, lerpSpeed * Time.deltaTime);
        }
    }
}
