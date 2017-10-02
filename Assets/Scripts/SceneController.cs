using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public GameObject startPos;

    public enum SceneType {
        ForestClearing = 0,
        ForestPath = 1,
        ForestPathUnlocked = 2
    }

    public enum Transition
    {
        None,
        Fade
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    public void loadScene(SceneType scene, Transition fade)
    {   
        switch (fade)
        {
            case Transition.None:
                SceneManager.LoadScene((int) scene);
                break;
        }
        
    }

}