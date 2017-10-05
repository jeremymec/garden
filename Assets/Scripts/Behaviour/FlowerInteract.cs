using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInteract : MonoBehaviour, ScriptableBehaviour {

    PlayerInfo playerInfo;

    GameObject target;

    public TextController[] replacementRedFlowerText;
    public TextController[] replacementBlueFlowerText;

    // Use this for initialization
    void Start () {
        playerInfo = GameObject.FindGameObjectWithTag("Protag").GetComponent<PlayerInfo>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void executeScript(int condition)
    {
        Debug.Log("Script called, parent is" + target.name);

        if (this.target.CompareTag("BlueFlowers"))
        {
            updateFlowerInfo(PlayerInfo.FlowerType.Blue);
            updateFlowerText("RedFlowers", replacementRedFlowerText);
        }
        else if (this.target.CompareTag("RedFlowers"))
        {
            updateFlowerInfo(PlayerInfo.FlowerType.Blue);
            updateFlowerText("BlueFlowers", replacementBlueFlowerText);
        }
    }

    void updateFlowerText(string flowerName, TextController[] replacementText)
    {
        Debug.Log("Updating " + flowerName + "text!");
        GameObject[] flowers = GameObject.FindGameObjectsWithTag(flowerName);

        for (int i = 0; i < flowers.Length; i++)
        {
            flowers[i].GetComponent<InteractableDialog>().textControllers = replacementText;
        }
    }

    void updateFlowerInfo(PlayerInfo.FlowerType flowerType)
    {   
        if (playerInfo.getLookedAtFlower() == PlayerInfo.FlowerType.None)
        {
            playerInfo.setLookedAtFlower(flowerType);
        }
        
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }
}
