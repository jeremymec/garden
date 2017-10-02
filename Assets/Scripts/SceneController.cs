using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    public GameObject startPos;

    public Image fadeImage;
    public Animator anim;

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
            case Transition.Fade:
                StartCoroutine(fadeScene((int)scene));
                break;
        }
        
    }

    IEnumerator fadeScene(int index)
    {   
        anim.SetBool("Fade", true);
        GameObject.FindObjectOfType<StateController>().changeState(StateController.STATE.Frozen);
        yield return new WaitForSeconds(.25f);
        SceneManager.LoadScene(index);
        anim.SetBool("Fade", false);
        GameObject.FindObjectOfType<StateController>().changeState(StateController.STATE.Normal);
    }

}