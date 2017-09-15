using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public GameObject protag;

    STATE state;

    public enum STATE
    {
        Normal,
        Dialog
    }

	// Use this for initialization
	void Start () {
        this.state = STATE.Normal;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeState(STATE state)
    {

        switch (state)
        {
            case STATE.Dialog:
                this.state = state;
                PlayerMovement playerMovement = protag.GetComponent<PlayerMovement>();
                playerMovement.setFrozen(true);
                break;
        }

    }

    public STATE getState()
    {
        return state;
    }
}
