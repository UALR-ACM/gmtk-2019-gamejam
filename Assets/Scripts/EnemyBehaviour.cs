using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public PathWaypoint currentWaypoint;
    public const float SPEED_MODIFIER = 0.6f;

    private float speed;
    private float startTime;

    // bool to set the mouvement on or off (when reached the city)
    private bool mouv = true;

    private Animator charactAnim;
    private GameObject soundManager;

    private void Start() {
        speed = gameObject.GetComponent<EntityStats>().GetSpeed() * SPEED_MODIFIER;
        startTime = Time.time;
        charactAnim = transform.GetComponent<Animator>();
        soundManager = GameObject.Find("SoundManager");
        //transform.LookAt(currentWaypoint.GetNextOnPath().transform.position);
    }

    private void Update() {

        if (currentWaypoint.type != WaypointType.CITY && mouv == true) {

            Vector3 start = currentWaypoint.transform.position;
            Vector3 end = currentWaypoint.GetNextOnPath().transform.position;

            float journeyLength = Vector3.Distance(start, end);

            float distCovered = (Time.time - startTime) * speed;
            float t = distCovered / journeyLength;

            if (t > 1f) {
                currentWaypoint = currentWaypoint.GetNextOnPath();
                transform.LookAt(currentWaypoint.GetNextOnPath().transform.position);
                startTime = Time.time;
            } else {
                //transform.Translate(Vector3.Lerp(start, end, t), Space.World);
                transform.position = Vector3.Lerp(start, end, t);
            }
        }


        if (currentWaypoint.type == WaypointType.WALL)
        {

            switch (currentWaypoint.name)
            {
                case "Wall Waypoint 1":
                    AttackWall("Wall1");
                    break;
                case "Wall Waypoint 2":
                    AttackWall("Wall2");
                    break;
                case "Wall Waypoint 3":
                    AttackWall("Wall3");
                    break;
                
                // TO DO 
                case "Wall Waypoint 4":
                    AttackWall("Wall1");
                    break;

            }

            

            

        }


    }


    // attack a specific wall
    private void AttackWall(string wallName)
    {
        if (GameObject.Find(wallName) != null)
        {
            GameObject wall = GameObject.Find(wallName);
            StopMouvementAndAttack();
            var damagePower = this.GetComponent<EntityStats>().attackPercent;
            wall.transform.GetChild(0).GetComponent<WallHealth>().GetDamage(damagePower * 100 * Time.deltaTime);
        }

        else
        {
            Vector3 start = currentWaypoint.transform.position;
            Vector3 end = currentWaypoint.GetNextOnPath().transform.position;
            currentWaypoint = currentWaypoint.GetNextOnPath();
            transform.position = Vector3.Lerp(start, end, 50);
            charactAnim.SetBool("Attack", false);
            charactAnim.SetBool("isIdle", true);
        }
    }




    // ennemy reach the city an start to attack it
    public void StopMouvementAndAttack()
    {
        mouv = false;
        charactAnim.SetBool("Attack", true);

    }





}
