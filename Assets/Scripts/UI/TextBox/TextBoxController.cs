using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextBoxController : MonoBehaviour
{
    public GameObject textBox;
}


/*
/// <summary>
/// Controller for the DialogBox Gameobject. Scene-persistent, i.e. created at the start of any scene where dialog is required, persists until the screen is destroyed.
/// Handles the display of the Canvas TextBox, and the loading and unloading of text onto this box.
/// </summary>
public class TextBoxController : MonoBehaviour
{
    // Canvas Image of a textbox to draw text on
    public GameObject textBox;

    // Canvas Image of the selection arrow
    public GameObject selectionArrow;

    // Text prefab to be initialized with custom text
    public Text baseText;

    // A list of all Text currently displayed on the box, for use in clearing the box
    public List<Text> textObjects;
    
    // Needs a refrence to StateController for dialog
    StateController stateController;

    // The textcontrollers currently queued up to this instance of TextBoxController
    public Queue<TextController> textControllers;
    public TextController currentTextController;

    // Information about the raw text to be displayed
    public string[] textSections;
    public int currentLine;

    // STATIC VARS
    public static int lineSpacing = 50;

    // Text fade-in duration, larger float results in a longer fade in time
    static float duration = 0.5f;

    void Start()
    {
        this.stateController = FindObjectOfType<StateController>();
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
    /// Regardless of result, calls nextSection function to display the next section of text. Also triggers the execute() function of the previous script contoller,
    /// to simulate onExit behaviour.
    /// </summary>
    public void requestNext()
    {

        if (currentTextController == null)
        {
            nextTextBoxController();
            clearText();
        }
        else if (currentLine >= (textSections.Length))
        {
            executeText();
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
                newTextFromCurrentLine(0, 0);
                break;

            case TextController.Type.Question:
                stateController.changeState(StateController.STATE.DialogQuestion);

                newTextFromCurrentLine(0, 0);
                newTextFromCurrentLine(0, 1);
                newTextFromCurrentLine(1, 0);

                selectText(currentTextController.getSelected());
                break;
        }
    }

    public void executeText()
    {

        currentTextController.Execute();
        
    }

    public void switchSelection()
    {
        currentTextController.switchSelection();
        selectText(currentTextController.getSelected());
    }

    void selectText(int option)
    {
        selectionArrow.SetActive(true);
        RectTransform arrowTransform = selectionArrow.GetComponent<RectTransform>();

        arrowTransform.SetPositionAndRotation(new Vector3(230f + (100f * (option)), 86f, 0f), Quaternion.identity);

    }

    void newTextFromCurrentLine(int xInc, int yInc)
    {
        Text nextSection = createText(xInc, yInc);
        nextSection.text = textSections[currentLine];
        currentLine++;

        textObjects.Add(nextSection);

        StartCoroutine(FadeInText(duration, nextSection));
    }
    
    /// <summary>
    /// Clears all current text from the dialog box by calling Destroy() on the TextObjects
    /// </summary>
    void clearText()
    {
        foreach (Text text in textObjects)
        {
            Destroy(text.gameObject);
        }

        textObjects.Clear();
    }

    /// <summary>
    /// "Destroys" the current instance of the TextBox by clearing all the text, nulling revelent fields and setting active to false so it is removed from the screen.
    /// Instructs the state controller to change state from Dialog to normal
    /// </summary>
    void destroyTextBox()
    {
        clearText();

        this.currentTextController = null;

        if (FindObjectOfType<StateController>().getState() != StateController.STATE.Frozen)
        {
            FindObjectOfType<StateController>().changeState(StateController.STATE.Normal);
        }

        selectionArrow.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(410f + (100f * (2)), 86f, 0f), Quaternion.identity);
        selectionArrow.SetActive(false);

        textBox.SetActive(false);

    }



    /// <summary>
    /// Initializes a new Text object from the base prefab, sets its position based on the current line, and returns the object. 
    /// </summary>
    /// <returns>Newly instantiated Text object</returns>
    Text createText(int xIncrement, int yIncrement)
    {

        float xPos = (textBox.transform.position.x + 60) + (xIncrement * 100);
        float yPos = (textBox.transform.position.y + 30) - (50 * currentLine) - (yIncrement * 50);

        Vector3 pos = new Vector3(xPos, yPos, 0f);
        Text createdText = Instantiate<Text>(baseText, pos, Quaternion.identity, textBox.transform);

        return createdText;
    }

}
*/
