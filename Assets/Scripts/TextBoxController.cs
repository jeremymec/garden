using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour
{

    public GameObject textBox;
    public Text baseText;

    public List<Text> textObjects;

    public Queue<TextController> textControllers;
    public TextController currentTextController;

    public string[] textSections;
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

    /// <summary>
    /// Called once at the start of every text instance. It marks the TextBox as active to be displayed on the screen, and initializes a queue of TextControllers that the text
    /// box will be displaying in the current instance.
    /// </summary>
    /// <param name="controllers">Array of TextControllers to be displayed in current instance of TextBox.</param>
    public void initTextBox(TextController[] controllers)
    {
        textBox.SetActive(true);

        this.textControllers = new Queue<TextController>();

        foreach (TextController tc in controllers)
        {
            this.textControllers.Enqueue(tc);
        }

        requestNext();
    }


    /// <summary>
    /// Called when the player presses the determined key to advance dialog. It determines the current TextController has reached its end, and if so requests a new one.
    /// Regardless of result, calls nextSection function to display the next section of text.
    /// </summary>
    public void requestNext()
    {

        // Debug.Log("request next called with currentLine value of " + currentLine + " and textSections value of " + textSections.Length);

        if (currentTextController == null || currentLine >= (textSections.Length))
        {
            nextTextBoxController();

        }

        if (textBox.activeSelf)
        {
            nextSection();
        }

    }

    /// <summary>
    /// Attempts to process the next textController in the queue. Processing involves splitting the actual text contained in the controller into an array.
    /// Triggers the removal of the text box if the textController queue is empty.
    /// </summary>
    void nextTextBoxController()
    {
        if (textControllers.Count == 0)
        {
            destroyTextBox();

        } else
        {
            currentTextController = textControllers.Dequeue();
            currentLine = 0;
            this.textSections = currentTextController.getTextAsset().text.Split('|');
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void nextSection()
    {
        switch (currentTextController.getType())
        {
            case TextController.Type.Normal:
                Text nextSection = createText();

                nextSection.text = textSections[currentLine];
                currentLine++;

                textObjects.Add(nextSection);

                StartCoroutine(FadeInText(duration, nextSection));
                break;
        }
    }

    void clearText()
    {
        foreach (Text text in textObjects)
        {
            Destroy(text);
        }
    }

    void destroyTextBox()
    {
        active = false;

        foreach (Text text in textObjects)
        {
            Destroy(text);
        }

        this.currentTextController = null;

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
        Vector3 pos = new Vector3(textBox.transform.position.x + 60, textBox.transform.position.y + 30 - (50 * currentLine), 0f);
        Text createdText = Instantiate<Text>(baseText, pos, Quaternion.identity, textBox.transform);

        return createdText;
    }

}
