// Rougefort Luca B3JV1 Prog
// move.cs SCRIPT POUR ADMIN DEBUG
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement du personnage
    private Rigidbody rb;
    private bool isAdminMode = false;
    public Ballon ballonScript; // Assurez-vous de lier le script Ballon dans l'inspecteur

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleAdminModeToggle();
        HandleMovement();
    }

    private void HandleAdminModeToggle()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            isAdminMode = !isAdminMode;
            rb.useGravity = !isAdminMode;
            rb.velocity = Vector3.zero; // Réinitialiser la vélocité pour éviter des mouvements indésirables
            ballonScript.enabled = !isAdminMode; // Activer/désactiver le script Ballon
        }
    }

    private void HandleMovement()
    {
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        if (isAdminMode)
        {
            Vector3 move = new Vector3(moveInputX * moveSpeed, moveInputY * moveSpeed, 0);
            transform.position += move * Time.deltaTime;
        }
        else
        {
            Vector3 move = new Vector3(moveInputX * moveSpeed, rb.velocity.y, 0);
            rb.velocity = new Vector3(move.x, rb.velocity.y, 0);
        }
    }
}
