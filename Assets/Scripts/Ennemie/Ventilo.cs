// Rougefort Luca B3JV1 Prog
// Ventilo.cs
// GameJam rentr�e 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilo : MonoBehaviour
{
    public float pushForce = 10f; // Force de l'impulsion
    public float colliderLengthY = 5f; // Longueur en X du Box Collider

    public bool pouss�eGauche = false;
    public bool pouss�eHaut = false;
    public bool pouss�eBas = false;
    public bool pouss�eDroite = true;

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
            Debug.LogError("BoxCollider non trouv� sur l'objet");
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
        Debug.Log("Le joueur est entr� dans la zone de pouss�e du ventillo");
        PlayEnterSound();
        PlayEnterVFX();
    }

    private void PushPlayer(Collider player)
    {
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            Vector3 direction = Vector3.zero;

            if (pouss�eGauche)
            {
                direction = Vector3.left;
            }
            else if (pouss�eHaut)
            {
                direction = Vector3.up;
            }
            else if (pouss�eBas)
            {
                direction = Vector3.down;
            }
            else if (pouss�eDroite)
            {
                direction = Vector3.right;
            }

            player.transform.Translate(direction * pushForce * Time.deltaTime);
            Debug.Log("Le joueur est pouss� avec une force de " + pushForce + " dans la direction " + direction);
        }
        else
        {
            Debug.Log("Le joueur n'a pas de Rigidbody");
        }
    }

    private void HandlePlayerExit()
    {
        Debug.Log("Le joueur a quitt� la zone de pouss�e du ventillo");
        PlayExitSound();
        PlayExitVFX();
    }

    private void PlayEnterSound()
    {
        // Int�gration des sons
        // TODO: Ajouter le code pour jouer un son � l'entr�e de la zone de pouss�e
    }

    private void PlayEnterVFX()
    {
        // Int�gration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel � l'entr�e de la zone de pouss�e
    }

    private void PlayExitSound()
    {
        // Int�gration des sons
        // TODO: Ajouter le code pour jouer un son � la sortie de la zone de pouss�e
    }

    private void PlayExitVFX()
    {
        // Int�gration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel � la sortie de la zone de pouss�e
    }
}
