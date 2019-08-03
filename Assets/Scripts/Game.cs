﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField]
    Vector2Int boardSize = new Vector2Int(50, 50);

    [SerializeField]
    GameBoard board = default;

    private void OnValidate() {
        if(boardSize.x < 2) boardSize.x = 2;
        if(boardSize.y < 2) boardSize.y = 2;    
    }

    void Awake() {
        board.Initialize(boardSize);
    }
}