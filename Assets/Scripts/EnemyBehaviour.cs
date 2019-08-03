using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    private PathWaypoint currentWaypoint;

    private void Update() {
        //Lerp(Vector3, Vector3, float)
        // distance/speed

        Vector3 start = currentWaypoint.transform.position;
        Vector3 end = currentWaypoint.GetNextOnPath().transform.position;
        float t = (Vector3.Distance(transform.position, end) + Time.deltaTime * 5f) / Vector3.Distance(start, end);

        transform.Translate(Vector3.Lerp(start, end, t)); //vec3

    }
    
}
