using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public Transform target;

    public float zPos = -10f;

    public bool following = true;

    float offsetX = 0f;
    float offsetY = 0f;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Protag").transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (following)
        {

            this.transform.position = new Vector3(target.position.x - offsetX, target.position.y - offsetY, zPos);

        }
        else
        {
            this.offsetX = target.transform.position.x - this.transform.position.x;
            this.offsetY = target.transform.position.y - this.transform.position.y;
        }


	}

    public void setFollowing(bool state)
    {
        this.following = state;
    }
}
