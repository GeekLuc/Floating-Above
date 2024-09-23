// Rougefort Luca B3JV1 Prog
// Tireur.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tireur : MonoBehaviour{
    public GameObject bulletPrefab; // Le prefab de la balle
    public Transform firePoint; // Le point de départ de la balle
    public float bulletSpeed = 20f; // La vitesse de la balle
    public float fireRate = 1f; // Intervalle de tir en secondes

    private float nextFireTime = 0f;

    [SerializeField] AudioSource _sfx;

    void Update(){
        HandleShooting();
    }

    private void HandleShooting(){
        if (Time.time >= nextFireTime){
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot(){
        _sfx.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * bulletSpeed;
        PlayShootSound();
        PlayShootVFX();
    }

    private void PlayShootSound(){
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de tir
    }

    private void PlayShootVFX(){
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de tir
    }
}



