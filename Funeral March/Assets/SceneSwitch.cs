using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
    [SerializeField, Tooltip("The player prefab being connected to this script. This should be a FPS controller prefab!")]
    GameObject _player;
    [SerializeField, Tooltip("The stairs position vector for the 1st floor. ")]
    Vector3 FirstFloorStairs;
    [SerializeField, Tooltip("The stairs position vector for the 1st floor. ")]
    Vector3 SecondFloorStairs;
    // Use this for initialization
    void Start()
    {
        //subscribe methods to the events
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update () {
		
	}


    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
       if(arg0.name == "SecondFloorTest")
        {
            Instantiate(_player, SecondFloorStairs, Quaternion.identity);
        }
        else
        {
            Instantiate(_player, FirstFloorStairs, Quaternion.identity);
        }
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
