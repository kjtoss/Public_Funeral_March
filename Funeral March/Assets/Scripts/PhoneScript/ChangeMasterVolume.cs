using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMasterVolume : MonoBehaviour {

    public Slider MasterSlider;

    private void Start()
    {
        //sets up a listener to check if the slider's value is being changed
        MasterSlider.onValueChanged.AddListener(delegate {ValueChangeCheck();});
    }

    public void ValueChangeCheck()
    {

        AudioListener.volume = MasterSlider.value;
        //Debug.Log(MasterSlider.value);
    }

}
