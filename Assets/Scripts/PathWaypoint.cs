using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaypointType {
	NORMAL, SPAWN, WALL, CITY
}

public class PathWaypoint : MonoBehaviour {

	public List<PathWaypoint> neighbors;
	public WaypointType type;

	private PathWaypoint nextOnPath;
	private float distance;

	private void Awake() {
		if (type == WaypointType.CITY)
			distance = 0f;
		else
			distance = float.MaxValue;
	}

	private void Start() {
		if (type == WaypointType.CITY) {
			foreach (PathWaypoint neighbor in neighbors) {
				neighbor.AttemptToFormPath(this, distance);
			}
		}
	}

	private void FixedUpdate() {
		// This method currently only used for debugging purposes
		if(nextOnPath != null)
			Debug.DrawLine(this.transform.position, nextOnPath.transform.position, Color.white, 1.0f);
	}

	public void AttemptToFormPath(PathWaypoint otherWaypoint, float distanceFromCity) {
		distanceFromCity += Vector3.Distance(this.transform.position, otherWaypoint.transform.position);

		if (distance > distanceFromCity) {
			nextOnPath = otherWaypoint;
			distance = distanceFromCity;

			foreach(PathWaypoint neighbor in neighbors) {
				neighbor.AttemptToFormPath(this, distance);
			}
		}
	}

	public WaypointType GetWaypointType() {
		return type;
	}

	public PathWaypoint GetNextOnPath() {
		return nextOnPath;
	}

	public Vector3 GetVector3ToNext() {
		return nextOnPath.transform.position - this.transform.position;
	}
}
