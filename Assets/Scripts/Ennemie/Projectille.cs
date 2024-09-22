// Rougefort Luca B3JV1 Prog
// Projectille.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectille : MonoBehaviour{
    public float tempsDeVie = 10.0f;

    void Start(){
        Destroy(gameObject, tempsDeVie);
    }
}
