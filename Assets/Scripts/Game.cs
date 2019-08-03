using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
    [SerializeField] Vector2Int boardSize = new Vector2Int(50, 50);
    [SerializeField] GameBoard board = default;
    [SerializeField] GameTileContentFactory tileContentFactory = default;

    Ray TouchRay => Camera.main.ScreenPointToRay(Input.mousePosition);    

    void HandleTouch() {
        GameTile tile = board.GetTile(TouchRay);
        if(tile != null) tile.Content = tileContentFactory.Get(GameTileContentType.Destination);
    }

    private void OnValidate() {
        if(boardSize.x < 2) boardSize.x = 2;
        if(boardSize.y < 2) boardSize.y = 2;    
    }

    void Awake() {
        board.Initialize(boardSize);
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            HandleTouch();
        }
    }
}
