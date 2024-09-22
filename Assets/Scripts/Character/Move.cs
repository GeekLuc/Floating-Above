// Rougefort Luca B3JV1 Prog
// Move.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour{
    public float moveSpeed = 5f; // Vitesse de déplacement du personnage
    public float friction = 0.9f; // Friction pour ralentir le personnage
    private Rigidbody rb;
    private bool facingRight = true;
    private Ballon ballon;

    void Start(){
        rb = GetComponent<Rigidbody>();
        ballon = GetComponent<Ballon>();
    }

    void Update(){
        if (IsBallonFlying()){
            return;
        }

        HandleMovement();
        ApplyFriction();
        HandleFlip();
    }

    private bool IsBallonFlying(){
        return ballon != null && ballon.isFlying;
    }

    private void HandleMovement(){
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0);
        rb.velocity = new Vector3(move.x, rb.velocity.y, 0);
    }

    private void ApplyFriction(){
        if (Input.GetAxis("Horizontal") == 0){
            rb.velocity = new Vector3(rb.velocity.x * friction, rb.velocity.y, 0);
        }
    }

    private void HandleFlip(){
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput > 0 && !facingRight){
            Flip();
        }else if (moveInput < 0 && facingRight){
            Flip();
        }
    }

    private void Flip(){
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de retournement

        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de retournement
    }
}
