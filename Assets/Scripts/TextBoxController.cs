using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour
{

    public GameObject textBox;
    public Text text;

    public List<Text> textObjects;

    public TextAsset file;
    public string[] lines;

    public int currentLine;

    public bool active;

    static float duration = 0.5f;

    void Update()
    {   
        if (!active)
        {
            return;
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

        this.text.text = lines[currentLine];

        Text firstLine = createText();
        textObjects.Add(firstLine);

        StartCoroutine(FadeInText(duration, firstLine));

        active = true;
    }

    public void requestNext()
    {
        if (currentLine >= lines.Length - 1)
        {
            destroyTextBox();
            return;
        }

        currentLine++;
        this.text.text = lines[currentLine];

        Text nextLine = createText();
        textObjects.Add(nextLine);

        StartCoroutine(FadeInText(duration, nextLine));
    }

    void destroyTextBox()
    {
        active = false;

        foreach (Text text in textObjects)
        {
            Destroy(text);
        }

        textBox.SetActive(false);

        FindObjectOfType<StateController>().changeState(StateController.STATE.Normal);
    }

    public IEnumerator FadeInText(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);

        while (i.color.a < 1f)
        {   
            if (i == null)
            {
                yield break;

            } else
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
                yield return null;
            }

        }

    }

    Text createText()
    {
        Vector3 pos = new Vector3(textBox.transform.position.x + 60, textBox.transform.position.y + 50 - (50 * currentLine), 0f);
        return Instantiate<Text>(text, pos, Quaternion.identity, textBox.transform);
    }

}
