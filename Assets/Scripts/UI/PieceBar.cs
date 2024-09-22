// Rougefort Luca B3JV1 Prog
// PieceBar.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBar : MonoBehaviour{
    public int PieceCount = 0;
    public int MaxPieceCount = 3;
    public GameObject[] Piece;

    void Start(){
        InitializePieces();
    }

    private void InitializePieces(){
        for (int i = 0; i < Piece.Length; i++){
            Piece[i].SetActive(false);
        }
        if (Piece.Length > 0){
            Piece[0].SetActive(true);
        }
    }

    public void UpdatePieceDisplay(){
        if (PieceCount < Piece.Length){
            HideCurrentPiece();
            ShowNewPiece();
            PlayPieceUpdateSound();
            PlayPieceUpdateVFX();
        }
    }

    private void HideCurrentPiece(){
        if (PieceCount > 0){
            Piece[PieceCount - 1].SetActive(false);
        }
    }

    private void ShowNewPiece(){
        Piece[PieceCount].SetActive(true);
    }

    private void PlayPieceUpdateSound(){
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de mise à jour des pièces
    }

    private void PlayPieceUpdateVFX(){
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de mise à jour des pièces
    }
}

