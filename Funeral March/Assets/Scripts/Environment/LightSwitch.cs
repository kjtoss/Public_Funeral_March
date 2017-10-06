using UnityEngine;
using System;
using System.Collections.Generic;

public class LightSwitch : MonoBehaviour
{

    [SerializeField]
    [Tooltip("The lights that this switch will enable.")]
    private List<Light> lights = new List<Light>();
    [SerializeField]
    [Tooltip("The part of the light swtich that will move.")]
    private GameObject switchPart;
    [SerializeField, Tooltip("Will the switchPart move?.")]
    private bool Movable = false;
    [SerializeField]
    [Tooltip("The angle the Switch rotates. For light swtiches, this should be set to 180, for floor lamps, this should be 0.")]
    private float _Angle;
    [Tooltip("Audio Clips for Switching")]
    public AudioClip SwitchOn;
    [Tooltip("Audio Clips for Switching")]
    public  AudioClip SwitchOff;
    [Tooltip("Whether or not the switch is on at the start (keeps the lights on when the game starts"), SerializeField]
    private bool isSwitchOn = false;
    

	private AudioSource _audioSource;
    void Start () {

        if (isSwitchOn)
        {
            foreach (Light light in lights)
            {
                light.enabled = true;
            }
        }
        else
        {
            foreach (Light light in lights)
            {
                light.enabled = false;
            }
        }
	}

	void Awake()
	{    

		_audioSource = gameObject.GetComponentInChildren<AudioSource>();

	}

	public void SwitchLight()
	{
		

		if (isSwitchOn)
		{
            //Debug.Log("Turn me off");

            if (Movable)
            {
                switchPart.transform.eulerAngles = new Vector3(_Angle, switchPart.transform.eulerAngles.y, switchPart.transform.eulerAngles.z);
            }
            foreach (Light light in lights)
            {
                light.enabled = false;
            }
            if (_audioSource != null)
            {
                _audioSource.clip = SwitchOff;
                _audioSource.Play();
            }
            else
            {
                Debug.LogWarning("There's no Audio Source attached!");
            }
            isSwitchOn = false;
        }


		else if (!isSwitchOn)
		{
           // Debug.Log("Turn me on");
            if (Movable)
            {
                switchPart.transform.eulerAngles = new Vector3(_Angle, switchPart.transform.eulerAngles.y, switchPart.transform.eulerAngles.z);
            }
            foreach (Light light in lights)
            {
                light.enabled = true;
            }
            if (_audioSource != null)
            {
                _audioSource.clip = SwitchOff;
                _audioSource.Play();
            }
            else
            {
                Debug.LogWarning("There's no Audio Source attached!");
            }
            isSwitchOn = true;

        }

	}

	
}
