using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioClip ButtonSound;   
    AudioSource myAudio; 
    public static SoundManager instance;

    void Awake()  
    {
        if (SoundManager.instance == null)  
            SoundManager.instance = this;  
    }

    void Start()
    {
        myAudio = this.GetComponent<AudioSource>();  
    }

    public void PlaySound()
    {
        myAudio.PlayOneShot(ButtonSound);
      
    }

    void Update()
    {
        myAudio.volume = PlayerPrefs.GetFloat(Prefstype.SoundVol,0.5f);
    }
}
