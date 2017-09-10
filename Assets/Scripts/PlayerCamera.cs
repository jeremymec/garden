using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    BoxCollider2D cameraCollider;

	// Use this for initialization
	void Start () {
        cameraCollider =  GameObject.FindGameObjectWithTag("CameraCollider").GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
