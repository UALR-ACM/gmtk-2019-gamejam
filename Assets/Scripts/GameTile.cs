using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour{
    [SerializeField] Transform arrow = default;
    GameTile north, east, south, west, nextOnPath;
    int distance;
    
    // Makes tiles easy to search by horizontally
    public static void MakeEastWestNeighbors (GameTile east, GameTile west) {
        Debug.Assert( west.east == null && east.west == null, "Redfined Neighbors!");
        west.east = east;
        east.west = west;
    }

    // Makes tiles easy to search by horizontally
    public static void MakeNorthSouthNeighbors(GameTile north, GameTile south) {
        Debug.Assert(south.north == null && north.south == null, "Redfined Neighbors!");
        south.north = north;
        north.south = south;
    }
}
