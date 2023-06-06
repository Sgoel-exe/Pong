using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleBoardControl : MonoBehaviour
{
    public float speed = 10f;
    public InputAction movement;
    // Start is called before the first frame update
    public Rigidbody2D rb;

    private Vector2 moveDirection = Vector2.zero;
    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = movement.ReadValue<Vector2>();
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, moveDirection.y * speed);
    }
}
