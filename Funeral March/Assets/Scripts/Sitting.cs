using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Cameras;
public class Sitting : MonoBehaviour {


    private FirstPersonController me;
    private GameObject _player;
    private Quaternion toQuaternion = Quaternion.identity;
    private Quaternion fromQuaternion = Quaternion.identity;
    [Tooltip("The offset of the player when sitting in the chair. Defaults to x, y-.6, z-.6")]
    private Vector3 toVector = Vector3.zero;
    private bool sitting = false;
    [SerializeField]
    [Tooltip("The offset from the chair, should not be zero.")]
    private Vector3 offset= Vector3.zero;
    private bool sitGo = false; //for Coroutine, when start only one
    private MouseManager mouse;
    private CharacterController character;
    private Camera camLook;
    private FPSInputController jones;
    // Use this for initialization
    void Start()
    {

        _player = GameObject.FindGameObjectWithTag("Player");
        character = _player.GetComponent<CharacterController>();
        me = _player.GetComponent<FirstPersonController>();
        fromQuaternion = Quaternion.Euler(0, _player.transform.eulerAngles.y, 0);
        toQuaternion = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        camLook = _player.gameObject.GetComponentInChildren<Camera>();
        toVector = new Vector3(transform.position.x, transform.position.y, transform.position.z) + offset;
        jones = _player.GetComponent<FPSInputController>();

    }

    // Update is called once per frame
    public void StartSitting()
    {
        if (!sitGo)
        {
            if (sitting)
            { //Stand Up
               // Debug.Log("Standing");
                StartCoroutine(this.Rotate(fromQuaternion));
            }
            else
            { //Sit Down
               // Debug.Log("Sitting");
                StartCoroutine(this.Rotate(toQuaternion));
            }
        }
    }
    IEnumerator Rotate(Quaternion dest)
    {
       
            character.enabled = false;
       sitGo = true;
       if (!sitting) // if sitting is false here, it'll be true next
        {
            //Take out charactercontroller
            me.enabled = false;

            //Set the positions for the player and the camera
            _player.transform.position = toVector;
            Vector3 cam = new Vector3(_player.transform.position.x, _player.transform.position.y - 2, _player.transform.position.z);
    
            //Fix the x Rotation of the Camera
            Quaternion camRot = Quaternion.Euler(0, _player.transform.localRotation.y, _player.transform.localRotation.z);
            while (Quaternion.Angle(camLook.transform.localRotation, camRot) > 1.0f && 
                   Quaternion.Angle(_player.transform.localRotation, dest) > 1.0f &&
                   Vector3.Distance(camLook.gameObject.transform.position, cam) > 1.0f)
            {
                _player.transform.localRotation = Quaternion.Slerp(_player.transform.localRotation, dest, Time.deltaTime);
                camLook.gameObject.transform.position = Vector3.Slerp(camLook.transform.position, cam, Time.deltaTime);
                camLook.gameObject.transform.localRotation = Quaternion.Slerp(camLook.gameObject.transform.localRotation, camRot, Time.deltaTime);
                yield return null;
            }

            //re-enable camLooks and let the mouse manager know that we're sitting.
            camLook.enabled = true;
            me.enabled = true; 
            me.UseHeadBob = false;
            _player.GetComponent<AudioSource>().enabled = false;
            MouseManager.instance.IsSitting(true, this);
            sitting = true;
            //Debug.Log("Moving Disabled");
        }
        else if (sitting)
        {
            
            //re-enable the charactercontroller, move the camera to it's original position, and let the mouse manager know we aren't sitting
            character.enabled = true;
            me.UseHeadBob = true;
            camLook.gameObject.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
            _player.GetComponent<AudioSource>().enabled = true;
            MouseManager.instance.IsSitting(false);
            sitting = false;
           // Debug.Log("Moving ENabled");
        }
     
        sitGo = false;
        yield return null;
    }
}
