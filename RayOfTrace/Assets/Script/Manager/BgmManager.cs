using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour {


    AudioSource myAudio;
    public static BgmManager instance;

    void Awake()
    {
        if (BgmManager.instance == null)
            BgmManager.instance = this;
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

 

    void Update()
    {
        myAudio.volume = PlayerPrefs.GetFloat(Prefstype.BgmVol, 0.5f);
    }
}
