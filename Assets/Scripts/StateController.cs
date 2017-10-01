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
        Dialog,
        DialogQuestion,
        Frozen
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
        this.state = state;

        PlayerMovement playerMovement = protag.GetComponent<PlayerMovement>();


        switch (state)
        {
            case STATE.Normal:
                playerMovement.setFrozen(false);
                break;

            case STATE.Dialog:
                playerMovement.setFrozen(true);
                break;
            case STATE.Frozen:
                playerMovement.setFrozen(true);
                break;
        }

    }

    public STATE getState()
    {
        return state;
    }
}
