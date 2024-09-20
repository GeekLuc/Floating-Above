using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    GameJam 2024-2025 - Team 3
    SliderScript.cs
    Rougefort Luca B3JV1
*/

public class Oiseau : MonoBehaviour{
    public float vitesse = 5.0f;
    public float positionMaxX = -10.0f;
    public float amplitude = 1.0f;
    public float frequence = 1.0f;

    private float startY;

    void Start(){
        startY = transform.position.y;
    }

    void Update(){
        transform.Translate(Vector3.left * vitesse * Time.deltaTime);

        float newY = startY + Mathf.Sin(Time.time * frequence) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (transform.position.x <= positionMaxX){
            Destroy(gameObject);
        }
    }
}
