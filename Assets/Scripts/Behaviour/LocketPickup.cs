using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocketPickup : MonoBehaviour, ScriptableBehaviour {

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

}
