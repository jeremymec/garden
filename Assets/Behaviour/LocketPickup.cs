using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocketPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Locket Pickup Script");
        Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
