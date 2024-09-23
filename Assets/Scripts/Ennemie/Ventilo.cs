// Rougefort Luca B3JV1 Prog
// Ventilo.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilo : MonoBehaviour
{
    public float pushForce = 10f; // Force de l'impulsion
    public float colliderLengthY = 5f; // Longueur en X du Box Collider

    public bool pousséeGauche = false;
    public bool pousséeHaut = false;
    public bool pousséeBas = false;
    public bool pousséeDroite = true;

    private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            Vector3 size = boxCollider.size;
            size.x = 2;
            size.y = colliderLengthY;
            size.z = 1;
            boxCollider.size = size;
        }
        else
        {
            Debug.LogError("BoxCollider non trouvé sur l'objet");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            HandlePlayerEnter();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsPlayer(other))
        {
            PushPlayer(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsPlayer(other))
        {
            HandlePlayerExit();
        }
    }

    private bool IsPlayer(Collider other)
    {
        return other.CompareTag("Player");
    }

    private void HandlePlayerEnter()
    {
        Debug.Log("Le joueur est entré dans la zone de poussée du ventillo");
        PlayEnterSound();
        PlayEnterVFX();
    }

    private void PushPlayer(Collider player)
    {
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            Vector3 direction = Vector3.zero;

            if (pousséeGauche)
            {
                direction = Vector3.left;
            }
            else if (pousséeHaut)
            {
                direction = Vector3.up;
            }
            else if (pousséeBas)
            {
                direction = Vector3.down;
            }
            else if (pousséeDroite)
            {
                direction = Vector3.right;
            }

            player.transform.Translate(direction * pushForce * Time.deltaTime);
            Debug.Log("Le joueur est poussé avec une force de " + pushForce + " dans la direction " + direction);
        }
        else
        {
            Debug.Log("Le joueur n'a pas de Rigidbody");
        }
    }

    private void HandlePlayerExit()
    {
        Debug.Log("Le joueur a quitté la zone de poussée du ventillo");
        PlayExitSound();
        PlayExitVFX();
    }

    private void PlayEnterSound()
    {
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son à l'entrée de la zone de poussée
    }

    private void PlayEnterVFX()
    {
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel à l'entrée de la zone de poussée
    }

    private void PlayExitSound()
    {
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son à la sortie de la zone de poussée
    }

    private void PlayExitVFX()
    {
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel à la sortie de la zone de poussée
    }
}
