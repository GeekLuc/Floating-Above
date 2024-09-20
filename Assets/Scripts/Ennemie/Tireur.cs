using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    GameJam 2024-2025 - Team 3
    Tireur.cs
    Rougefort Luca B3JV1
*/

public class Tireur : MonoBehaviour{
    public GameObject bulletPrefab; // Le prefab de la balle
    public Transform firePoint; // Le point de départ de la balle
    public float bulletSpeed = 20f; // La vitesse de la balle
    public float fireRate = 1f; // Intervalle de tir en secondes

    private float nextFireTime = 0f;

    void Update(){
        if (Time.time >= nextFireTime){
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * bulletSpeed;
    }
}


