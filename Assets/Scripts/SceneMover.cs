using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour {

    public SceneController.SceneType targetScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Protag")
        {
            GameObject.FindObjectOfType<SceneController>().loadScene(targetScene, SceneController.Transition.None);
        }

    }
}
