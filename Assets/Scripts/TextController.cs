using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

    public enum Type
    {
        Normal,
        Question
    }

    public TextAsset rawText;

    public GameObject attachedScript;

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

    public void execute()
    {   
        if (attachedScript != null)
        {
            Instantiate(attachedScript);
        }
    }

}
