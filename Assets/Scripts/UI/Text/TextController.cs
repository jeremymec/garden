using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TextController: MonoBehaviour
{

    public TextAsset rawText;

    GameObject agent;

    public TextAsset getTextAsset()
    {
        return rawText;
    }

    protected void runScripts(GameObject[] scripts)
    {
        for (int i = 0; i < scripts.Length; i++)
        {
            GameObject scriptableBehaviour = Instantiate(scripts[i]);
            ScriptableBehaviour script = scriptableBehaviour.GetComponent<ScriptableBehaviour>();
            script.executeScript(agent);

        }
    }

}

/*
public class TextController : MonoBehaviour {

    public enum Type
    {
        Normal,
        Question
    }

    public TextAsset rawText;

    public GameObject[] attachedScripts;

    public Type textType;

    // The currently selected option in the TextBox
    int optionSelected = 1;

    // Use this for initialization
    void Start () {

	}
	
    public TextAsset getTextAsset()
    {
        return rawText;
    }

    public Type getType()
    {
        return textType;
    }

    public int getSelected()
    {
        return optionSelected;
    }

    public void switchSelection()
    {
        switch (optionSelected)
        {
            case 1:
                optionSelected = 2;
                break;
            case 2:
                optionSelected = 1;
                break;
        }
    }

    public void Execute()
    {   
        for (int i = 0; i < attachedScripts.Length; i++)
        {

            GameObject scriptableBehaviour = Instantiate(attachedScripts[i]);
            ScriptableBehaviour script = scriptableBehaviour.GetComponent<ScriptableBehaviour>();
            script.setTarget(gameObject);
            script.executeScript(optionSelected);

        }
            
        }
}
*/

