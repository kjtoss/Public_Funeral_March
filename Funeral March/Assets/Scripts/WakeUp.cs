using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Cameras;

public class WakeUp : MonoBehaviour {

    private GameObject _player;
    private Quaternion toQuaternion = Quaternion.identity;
    private Quaternion fromQuaternion = Quaternion.identity;


    // Use this for initialization
    void Start () {

        _player = GameObject.FindGameObjectWithTag("Player");
        fromQuaternion = Quaternion.Euler(-90, 91.54f, 0);
        toQuaternion = Quaternion.Euler(0, 181.54f, 0);

        //The rotation and position are hard coded because the camera controller only needs to be there for a very brief period.
        //default rotation: Quaternion.Euler(0, 181.54f, 0) 
        transform.rotation = Quaternion.Euler(-90, 91.54f, 0);
        
        //default position: Vector3(-11.34f, 3.26f, -3.4f
        transform.position = new Vector3(-11.8f, 1.26f, -3.4f);

        //starts the coroutine as soon as the scene is loaded
        //(axis = Vector3.left, angle = 270)
        StartCoroutine(Rotate(1.0f));
        this.GetComponent<Collider>().enabled = false;
        Debug.Log("collider is off");
    }

    IEnumerator Rotate (float duration)
    {
        //establishes the start and end points of the coroutine
        //Quaternion from = transform.rotation;
        //Quaternion to = transform.rotation;
        //to *= Quaternion.Euler(axis * angle);
        /*^ Quaternion shit that I dare not touch (its a remnant of the script that this is based on).
         Also helps to determine how the camera will be rotated.  */

        //sets where the camera controller will be moved to
        Vector3 posdes = new Vector3(transform.position.x - 0.26f, transform.position.y + 2, transform.position.z);

        float elapsed = 0.0f;
        //helps to establish the period of time during which the rotation and movement will occur
        while (elapsed < duration)
        {
            //rotates the camera controller AND relocates it over the course of the duration
            transform.rotation = Quaternion.Slerp(fromQuaternion, toQuaternion, elapsed / duration);
            transform.position = Vector3.Slerp(transform.position, posdes, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        //sets the rotation and position of the camera controller to their new angle/location
        transform.rotation = toQuaternion;
        transform.position = posdes;
        this.GetComponent<Collider>().enabled = true;
        Debug.Log("collider is on");
    }

}
