using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour{
    [SerializeField] Transform arrow = default;
    GameTile north, east, south, west, nextOnPath;
    int distance;

    public bool HasPath => distance != int.MaxValue;
    public GameTile GrowPathNorth() => GrowPathTo(north);
    public GameTile GrowPathEast() => GrowPathTo(east);
    public GameTile GrowPathSouth() => GrowPathTo(south);
    public GameTile GrowPathWest() => GrowPathTo(west);

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

    // clears the path of a tile
    public void ClearPath() {
        distance = int.MaxValue;
        nextOnPath = null;
    }

    // makes the tile the destination
    public void BecomeDestination() {
        distance = 0;
        nextOnPath = null;
    }

    private void GrowPathTo(GameTile neighbor) {
        Debug.Assert(HasPath, "No Path!");
        if(neighbor == null || neighbor.HasPath) return;
        neighbor.distance = distance + 1;
        neighbor.nextOnPath = this;
    }

    public GameTile GrowPathTo(GameTile neighbor) {
        if(!HasPath || neighbor == null) return null;
        neighbor.distance = distance + 1;
        neighbor.nextOnPath = this;
        return neighbor;
    }
}
