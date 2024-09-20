using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilo : MonoBehaviour
{
    public float pushForce = 10f; // Force de l'impulsion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur est entr� dans la zone de pouss�e du ventillo");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                other.transform.Translate(Vector3.right * pushForce * Time.deltaTime);
                Debug.Log("Le joueur est pouss�");
            }
            else
            {
                Debug.Log("Le joueur n'a pas de Rigidbody");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur a quitt� la zone de pouss�e du ventillo");
        }
    }
}
