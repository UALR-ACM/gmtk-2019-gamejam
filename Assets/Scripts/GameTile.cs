using UnityEngine;

public class GameTile : MonoBehaviour{
    [SerializeField] Transform arrow = default;
    GameTile north, east, south, west, nextOnPath;
    int distance;
    static Quaternion
        northRotation = Quaternion.Euler(90f, 0f, 0f),
        eastRotation = Quaternion.Euler(90f, 90f, 0f),
        southRotation = Quaternion.Euler(90f, 180, 0f),
        westRotation = Quaternion.Euler(90f, 270f, 0f);

    public bool HasPath => distance != int.MaxValue;
    public bool IsAlternative {get; set;}
    public GameTile GrowPathNorth() => GrowPathTo(north);
    public GameTile GrowPathEast() => GrowPathTo(east);
    public GameTile GrowPathSouth() => GrowPathTo(south);
    public GameTile GrowPathWest() => GrowPathTo(west);

    // Makes tiles easy to search by horizontally
    public static void MakeEastWestNeighbors (GameTile east, GameTile west) {
        Debug.Assert(west.east == null && east.west == null, "Redfined Neighbors!");
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

    GameTile GrowPathTo(GameTile neighbor) {
        if(!HasPath || neighbor == null || neighbor.HasPath) return null;
        neighbor.distance = distance + 1;
        neighbor.nextOnPath = this;
        return neighbor;
    }

    public void ShowPath() {
        if(distance == 0) {
            arrow.gameObject.SetActive(false);
            return;
        }
        arrow.gameObject.SetActive(true);
        arrow.localRotation = 
            nextOnPath == north ? northRotation :
            nextOnPath == east ? eastRotation :
            nextOnPath == south ? southRotation :
            westRotation;
    }
}
