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

    public Type textType;

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

}
