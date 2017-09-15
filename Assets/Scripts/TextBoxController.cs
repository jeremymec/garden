using System;
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

    public bool active;

    void Update()
    {   
        if (!active)
        {
            return;
        }

        // text.text += lines[currentLine];
    }

    public void initTextBox(TextAsset text)
    {
        currentLine = 0;

        textBox.SetActive(true);

        if (text != null)
        {
            this.lines = text.text.Split('\n');
        }

        this.text.text = lines[currentLine];

        Text firstLine = createText();

        StartCoroutine(FadeInText(1f, firstLine));

        active = true;
    }

    public void requestNext()
    {
        currentLine++;
        this.text.text = lines[currentLine];

        Text nextLine = createText();

        StartCoroutine(FadeInText(1f, nextLine));
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

    Text createText()
    {
        Vector3 pos = new Vector3(textBox.transform.position.x + 80, textBox.transform.position.y + 50 - (50 * currentLine), 0f);
        return Instantiate<Text>(text, pos, Quaternion.identity, textBox.transform);
    }

}
