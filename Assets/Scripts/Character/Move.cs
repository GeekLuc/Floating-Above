using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    GameJam 2024-2025 - Team 3
    ButtonScript.cs
    Rougefort Luca B3JV1
*/

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float friction = 0.9f; // Friction pour ralentir le personnage
    private Rigidbody rb;
    private bool facingRight = true; // Indique si le personnage fait face à droite

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0);
        rb.velocity = new Vector3(move.x, rb.velocity.y, 0);

        // Appliquer la friction pour ralentir le personnage progressivement
        if (moveInput == 0)
        {
            rb.velocity = new Vector3(rb.velocity.x * friction, rb.velocity.y, 0);
        }

        // Retourner le personnage en fonction de la direction du mouvement
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
