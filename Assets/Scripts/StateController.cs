﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public GameObject protag;

    public enum STATE
    {
        Normal,
        Dialog
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeState(STATE state)
    {

        switch (state)
        {
            case STATE.Dialog:
                PlayerMovement playerMovement = protag.GetComponent<PlayerMovement>();
                playerMovement.setFrozen(true);
                break;
        }

    }



}