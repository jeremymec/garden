using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocketNoPickup : MonoBehaviour, ScriptableBehaviour {

    public TextController[] replacementText;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void executeScript(int condition)
    {
        if (condition == 2)
        {
            GameObject locket = GameObject.FindGameObjectWithTag("Locket");
            InteractableDialog dialogScript = locket.GetComponent<InteractableDialog>();
            dialogScript.updateText(replacementText);
        }

        Destroy(this.gameObject);

    }

    public void setTarget(GameObject parent)
    {
        
    }
}
