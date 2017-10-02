using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Ring Ring I am called!");
        GameObject protag = GameObject.FindGameObjectWithTag("Protag");
        protag.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);
    }
}
