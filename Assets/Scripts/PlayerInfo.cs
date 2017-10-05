using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public enum FlowerType
    {   
        None,
        Red,
        Blue
    }

    public bool hasLocket;
    public FlowerType lookedAtFlower = FlowerType.None;

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

    public void setLookedAtFlower(FlowerType data)
    {
        this.lookedAtFlower = data;
    }

    public FlowerType getLookedAtFlower()
    {
        return this.lookedAtFlower;
    }

	
}
