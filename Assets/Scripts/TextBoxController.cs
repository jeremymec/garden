using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour
{

    public GameObject textBox;
    public Text text;

    public TextAsset file;
    public string[] lines;

    public int currentLine;
    public int endAtLine;

    public bool active;

    void Update()
    {   
        if (!active)
        {
            return;
        }

        text.text = lines[currentLine];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }

        if (currentLine > endAtLine)
        {
            destroyTextBox();
        }
    }

    public void initTextBox(TextAsset text)
    {
        currentLine = 0;

        textBox.SetActive(true);

        if (text != null)
        {
            this.lines = text.text.Split('\n');
            endAtLine = this.lines.Length;
        }

        active = true;
    }

    void destroyTextBox()
    {

    }
}
