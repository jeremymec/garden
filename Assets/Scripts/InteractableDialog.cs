using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDialog : MonoBehaviour {

    public TextAsset text;

    public TextBoxController textBoxController;
    public StateController stateController;

    static int i = 0;

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
        if (Input.GetKeyDown(KeyCode.F))
        {
        
            if (collision.CompareTag("Protag"))
            {

                if (stateController.getState() == StateController.STATE.Normal)
                {
                    stateController.changeState(StateController.STATE.Dialog);
                    textBoxController.initTextBox(text);

                } else if (stateController.getState() == StateController.STATE.Dialog)
                {
                    textBoxController.requestNext();
                }



            }
        }

    }
}
