using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public bool hasLocket;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void setHasLocket(bool data)
    {
        this.hasLocket = data;
    }

    public bool getHasLocket()
    {
        return this.hasLocket;
    }
	
}
