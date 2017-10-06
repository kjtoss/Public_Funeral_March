using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour {

    //sets up both the slider and the audio source
    public Slider Volume;
    private AudioSource MyAudio;

    private void Start()
    {
        MyAudio = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //makes it so that the audio's volume is = to the value of the slider
        MyAudio.volume = Volume.value;
    }
}
