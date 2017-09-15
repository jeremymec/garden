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
    public int endAtLine = 1;

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
        }

        StartCoroutine(FadeInText(1f, this.text));

        active = true;
    }

    void destroyTextBox()
    {

    }

    public IEnumerator FadeInText(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);

        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));

            yield return null;
        }
    }
}
