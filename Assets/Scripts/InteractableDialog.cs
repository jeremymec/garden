using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDialog : MonoBehaviour {

    public TextController[] textControllers;

    public TextBoxController textBoxController;
    public StateController stateController;

	// Use this for initialization
	void Start () {
        textBoxController = FindObjectOfType<TextBoxController>();
        stateController = FindObjectOfType<StateController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Protag"))
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (stateController.getState() == StateController.STATE.Normal)
                {
                    stateController.changeState(StateController.STATE.Dialog);
                    textBoxController.initTextBox(textControllers);

                }
                else if (stateController.getState() == StateController.STATE.Dialog)
                {
                    textBoxController.requestNext();

                }
                else if (stateController.getState() == StateController.STATE.DialogQuestion)
                {

                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (stateController.getState() == StateController.STATE.DialogQuestion)
                {   
                    if (textBoxController.currentTextController.getSelected() == 1)
                    {
                        textBoxController.switchSelection();
                    }
                    
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (stateController.getState() == StateController.STATE.DialogQuestion)
                {
                    if (textBoxController.currentTextController.getSelected() == 2)
                    {
                        textBoxController.switchSelection();
                    }

                }
            }

        }

    }
}
