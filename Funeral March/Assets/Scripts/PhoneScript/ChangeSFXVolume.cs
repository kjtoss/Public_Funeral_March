using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSFXVolume : MonoBehaviour {

    //sets up both the slider and the audio source
    public Slider Volume;
    public AudioSource MySound;

    private void Start()
    {
        Volume.onValueChanged.AddListener(delegate {ValueChangeCheck();});
    }

    public void ValueChangeCheck()
    {
        //When the slider is being moved the audio is played
        //additionally, the volume of said audio is altered accordingly
        MySound.Play();
        MySound.volume = Volume.value;
        Debug.Log(Volume.value);
    }
    
}
