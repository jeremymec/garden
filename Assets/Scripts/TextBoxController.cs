using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for the DialogBox Gameobject. Scene-persistent, i.e. created at the start of any scene where dialog is required, persists until the screen is destroyed.
/// Handles the display of the Canvas TextBox, and the loading and unloading of text onto this box.
/// </summary>
public class TextBoxController : MonoBehaviour
{

    // Canvas Image of a textbox to draw text on
    public GameObject textBox;

    // Text prefab to be initialized with custom text
    public Text baseText;

    // A list of all Text currently displayed on the box, for use in clearing the box
    public List<Text> textObjects;

    // The textcontrollers currently queued up to this instance of TextBoxController
    public Queue<TextController> textControllers;
    public TextController currentTextController;

    // Information about the raw text to be displayed
    public string[] textSections;
    public int currentLine;

    // Text fade-in duration, larger float results in a longer fade in time
    static float duration = 0.5f;

    void Update()
    {   

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

        // Displays the first line of text on creation
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
            clearText();
        }

        // Only attempt to draw text when the box is active
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
    /// Requests and displays the next section of text in the current textController.
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
                currentTextController.execute();
                break;
        }
    }

    /// <summary>
    /// Clears all current text from the dialog box by calling Destroy() on the TextObjects
    /// </summary>
    void clearText()
    {
        foreach (Text text in textObjects)
        {
            Destroy(text);
        }
    }

    /// <summary>
    /// "Destroys" the current instance of the TextBox by clearing all the text, nulling revelent fields and setting active to false so it is removed from the screen.
    /// Instructs the state controller to change state from Dialog to normal
    /// </summary>
    void destroyTextBox()
    {
        clearText();

        this.currentTextController = null;

        textBox.SetActive(false);

        FindObjectOfType<StateController>().changeState(StateController.STATE.Normal);
    }

    /// <summary>
    /// Coroutine to fade in the given line of text onto the TextBox
    /// </summary>
    /// <param name="t">Length of fade in</param>
    /// <param name="i">Text to fade in</param>
    /// <returns></returns>
    public IEnumerator FadeInText(float t, Text i)
    {   
        // Creates new color at maximum alpha
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);

        // While colour is less than white, increment color
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

    /// <summary>
    /// Initializes a new Text object from the base prefab, sets its position based on the current line, and returns the object. 
    /// </summary>
    /// <returns>Newly instantiated Text object</returns>
    Text createText()
    {
        Vector3 pos = new Vector3(textBox.transform.position.x + 60, textBox.transform.position.y + 30 - (50 * currentLine), 0f);
        Text createdText = Instantiate<Text>(baseText, pos, Quaternion.identity, textBox.transform);

        return createdText;
    }

}
