using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocketPickup : MonoBehaviour, ScriptableBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void executeScript(int condition)
    {
        if (condition == 1)
        {
            Debug.Log("Locket Pickup");
            GameObject protag = GameObject.FindGameObjectWithTag("Protag");
            protag.GetComponent<PlayerInfo>().setHasLocket(true);

            Destroy(GameObject.FindGameObjectWithTag("Locket"));
            Destroy(this.gameObject);
        }

    }
    
    /*
    public IEnumerator freezePlayer()
    {
       
        Debug.Log("Freezing Player");
        StateController stateController = FindObjectOfType<StateController>();
        stateController.changeState(StateController.STATE.Frozen);

        yield return new WaitForSeconds(2f);
        // Time.timeScale = 0;

        Debug.Log("Timer Expired");
        stateController.changeState(StateController.STATE.Normal);

        Destroy(this.gameObject);

    }
    */

}
