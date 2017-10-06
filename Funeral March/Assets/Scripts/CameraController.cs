using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float cameraSensitivity = 3.0f;
    public bool inverted = false;
    public float moveSpeed = 1.0f;
    
    private Rigidbody rbd;
    private Vector2 pos;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float baseFOV;
    private float position;
    private float rotation;
    //Vector3 reset = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        baseFOV = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if (Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));
        }
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = 40;
        }
        else if (Camera.main.fieldOfView != baseFOV)
        {
            Camera.main.fieldOfView = baseFOV;

        }


        yaw += cameraSensitivity * Input.GetAxis("Mouse X");
        if (inverted == false)
            pitch -= cameraSensitivity * Input.GetAxis("Mouse Y");
        else
            pitch += cameraSensitivity * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        Inputs();
    }
    void moveRight(float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + z * 0.05f);
    }

    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inverted = !inverted;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            cameraSensitivity = cameraSensitivity - 0.2f;
        }
        else if (Input.GetKeyDown(KeyCode.Equals))
        {
            cameraSensitivity = cameraSensitivity + 0.2f;
        }
        //increases and decreases camera sensitivity

    }


}