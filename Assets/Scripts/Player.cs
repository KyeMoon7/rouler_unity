using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float torqueForce = 1f;
    public float jumpForce = 5f;

    public float checkRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    public void AddTorque(float torque)
    {
        rb.AddTorque(torque);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() { }

    void Update() { }

    public bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            GetComponent<CircleCollider2D>().radius + extraHeight,
            groundLayer
        );
        return hit.collider != null;
    }
}
