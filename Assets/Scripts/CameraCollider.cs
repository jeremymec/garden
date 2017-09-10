using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour {

    CameraFollower cameraScript;

	// Use this for initialization
	void Start () {
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollower>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Protag")
        {
            cameraScript.setFollowing(false);
        }

    }

    void OnTriggerExit2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Protag")
        {
            cameraScript.setFollowing(true);
        }

    }
}
