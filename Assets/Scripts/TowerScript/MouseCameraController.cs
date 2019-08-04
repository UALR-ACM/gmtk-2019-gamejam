using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraController : MonoBehaviour {

    private GameObject player;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    Vector2 smoothV;
    Vector2 mouseLook;

	// Use this for initialization
	void Start () {
        player = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector2 mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDirection = Vector2.Scale(mouseDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDirection.x, 2f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDirection.y, 2f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -50f, 50f);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.rotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }


    void OnGUI(){
     GUI.Box(new Rect(Screen.width/2,Screen.height/2, 10, 10), "");
    }

    public void changeSensitivity(float newSens){
        sensitivity = newSens;
    }
}
