using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextModel : ScriptableObject {

    string[] lines;

    Text[] textObjects;
    int currentLine;

    private void initText(TextAsset rawText)
    {
        this.lines = rawText.text.Split('|');
        currentLine = 0;
    }

    public Text getTextByLine(int line)
    {
        return textObjects[line];
    }


}
