// Rougefort Luca B3JV1 Prog
// Oiseau.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oiseau : MonoBehaviour
{
    public float vitesse = 5.0f;
    public float positionMaxX = 10.0f;
    public float amplitude = 1.0f;
    public float frequence = 1.0f;

    private float startY;

    void Start()
    {
        InitializeStartY();
    }

    void Update()
    {
        MoveOiseau();
        UpdateVerticalPosition();
        CheckAndDestroyOiseau();
    }

    private void InitializeStartY()
    {
        startY = transform.position.y;
    }

    private void MoveOiseau()
    {
        transform.Translate(Vector3.forward * vitesse * Time.deltaTime);
    }

    private void UpdateVerticalPosition()
    {
        float newY = CalculateNewYPosition();
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private float CalculateNewYPosition()
    {
        return startY + Mathf.Sin(Time.time * frequence) * amplitude;
    }

    private void CheckAndDestroyOiseau()
    {
        if (transform.position.x >= positionMaxX)
        {
            DestroyOiseau();
        }
    }

    private void DestroyOiseau()
    {
        Destroy(gameObject);
        PlayDestroySound();
        PlayDestroyVFX();
    }

    private void PlayDestroySound()
    {
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de destruction de l'oiseau
    }

    private void PlayDestroyVFX()
    {
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de destruction de l'oiseau
    }
}
