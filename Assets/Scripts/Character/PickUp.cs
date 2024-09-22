// Rougefort Luca B3JV1 Prog
// PickUp.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour{
    private PieceBar pieceBar;

    void Start(){
        pieceBar = FindObjectOfType<PieceBar>();
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Piece")){
            HandlePieceCollection(other);
        }
    }

    private void HandlePieceCollection(Collider piece){
        Destroy(piece.gameObject);
        UpdatePieceBar();
        PlayCollectionSound();
        PlayCollectionVFX();
    }

    private void UpdatePieceBar(){
        if (pieceBar != null && pieceBar.PieceCount < pieceBar.MaxPieceCount){
            pieceBar.PieceCount++;
            pieceBar.UpdatePieceDisplay();
        }
    }

    private void PlayCollectionSound(){
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de collecte de pièce
    }

    private void PlayCollectionVFX(){
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de collecte de pièce
    }
}
