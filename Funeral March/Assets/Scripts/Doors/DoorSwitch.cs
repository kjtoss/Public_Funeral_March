using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour {
    [SerializeField]
    private DoorHandler handler; // the door that the switch triggers.
	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="item")
        handler.Unlock();

    }
}
