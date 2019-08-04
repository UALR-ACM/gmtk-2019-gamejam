using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public PathWaypoint currentWaypoint;
    public const float SPEED_MODIFIER = 0.6f;

    private float speed;
    private float startTime;

    private void Start() {
        speed = gameObject.GetComponent<EntityStats>().GetSpeed() * SPEED_MODIFIER;
        startTime = Time.time;
        //transform.LookAt(currentWaypoint.GetNextOnPath().transform.position);
    }

    private void Update() {

        if (currentWaypoint.type != WaypointType.CITY) {
            Vector3 start = currentWaypoint.transform.position;
            Vector3 end = currentWaypoint.GetNextOnPath().transform.position;

            float journeyLength = Vector3.Distance(start, end);

            float distCovered = (Time.time - startTime) * speed;
            float t = distCovered / journeyLength;

            if (t > 1f) {
                currentWaypoint = currentWaypoint.GetNextOnPath();
                transform.Rotate(currentWaypoint.GetNextOnPath().transform.position);
                startTime = Time.time;
            } else {
                //transform.Translate(Vector3.Lerp(start, end, t), Space.World);
                transform.position = Vector3.Lerp(start, end, t);
            }
        }
    }
    
}
