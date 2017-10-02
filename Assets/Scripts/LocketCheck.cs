using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocketCheck : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Protag")
        {
            PlayerInfo playerInfo = FindObjectOfType<PlayerInfo>();

            if (playerInfo.getHasLocket())
            {
                int indexOfSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
                Debug.Log("Loading level at id: " + indexOfSceneToLoad + "!");
                SceneManager.LoadScene(indexOfSceneToLoad);
                FindObjectOfType<AudioController>().playClip(AudioController.Sounds.Wind);
            }

        }

    }

}
