using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public PathWaypoint currentWaypoint;

    private float speed = 10f;
    private float startTime;

    private void Start() {
        startTime = Time.time;
    }

    private void Update() {

        if (currentWaypoint.type != WaypointType.CITY) {
            Vector3 start = currentWaypoint.transform.position;
            Vector3 end = currentWaypoint.GetNextOnPath().transform.position;

            float journeyLength = Vector3.Distance(start, end);

            float distCovered = (Time.time - startTime) * speed;
            float t = distCovered / journeyLength;
            Debug.Log(t);

            if (t > 0.95f) {
                currentWaypoint = currentWaypoint.GetNextOnPath();
                startTime = Time.time;
            } else {
                //transform.Translate(Vector3.Lerp(start, end, t), Space.World);

                transform.position = Vector3.Lerp(start, end, t);
            }
        }
    }
    
}
