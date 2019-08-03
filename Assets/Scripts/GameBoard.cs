using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoard : MonoBehaviour {
    [SerializeField] Transform ground = default;
    Vector2Int size;
    Queue<PathWaypoint> searchFrontier = new Queue<PathWaypoint>();
	
    public PathWaypoint GetWayPoint (Ray ray) {
		return null;
	}

    void FindPaths() {
        return;
    }

    public void Initialize (Vector2Int size) {
        //Create board of x,y size
        this.size = size;
        ground.localScale = new Vector3(size.x, size.y, 1f);
    }
}
