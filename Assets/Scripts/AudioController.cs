using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip windClip;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public enum Sounds
    {
        Wind
    }

	public void playClip(Sounds id)
    {
        switch (id)
        {
            case Sounds.Wind:
                audioSource.clip = windClip;
                audioSource.Play();
                break;
        }
    }
}
