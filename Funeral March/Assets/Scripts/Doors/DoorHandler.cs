using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class DoorHandler :MonoBehaviour
    {

    [SerializeField] private bool unlocked = false;
    [SerializeField] private float range; // The range from where the door can be opened.
    [SerializeField]
    [Tooltip("The rotation of the parent game object when this door is closed")]
    private float closeRotation = 0;
    [SerializeField]
    [Tooltip("The rotation of the parent game object when this door is open")]
    private float openRotation = 90;
    [SerializeField]
    [Tooltip("The speed at which the door opens")]
    private float doorAnimSpeed = .8f;
    private Quaternion toQuaternion = Quaternion.identity;
    private Quaternion fromQuaternion= Quaternion.identity;
    [SerializeField]
    private GameObject  parent;
    [SerializeField]
    private bool doorStatus = false; //false is close, true is open
    private bool doorGo = false; //for Coroutine, when start only one
    // Use this for initialization
    void Start()
    {
        fromQuaternion = Quaternion.Euler(0, closeRotation, 0);
        toQuaternion = Quaternion.Euler(0, openRotation, 0);
    }

    // Update is called once per frame
    public void RotateSetUp()
    {
        if (unlocked && !doorGo)
        {
            if (doorStatus)
            { //close door
                Debug.Log("Closing");
                StartCoroutine(this.Rotate(fromQuaternion));
            }
            else
            { //open door
                Debug.Log("Opening");
                StartCoroutine(this.Rotate(toQuaternion));
            }
        }
    }
    public  void Unlock()
    {
        unlocked = true;
    } 
    public void Lock()
    {
        unlocked = false;
    }
    IEnumerator Rotate(Quaternion dest)
    {

        doorGo = true;
        //Check if close/open, if angle less 4 degree, or use another value more 0
        while (Quaternion.Angle(parent.transform.localRotation, dest) > 4.0f)
        {
            parent.transform.localRotation = Quaternion.Slerp(parent.transform.localRotation, dest, Time.deltaTime * doorAnimSpeed);    
            yield return null;
        }
        //Change door status
        doorStatus = !doorStatus;
        doorGo = false;
        yield return null;
    }
    
}


