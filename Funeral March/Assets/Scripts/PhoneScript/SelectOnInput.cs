using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool buttonSelected;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //allows the user to use a keyboard to interact with the menus
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            //if the up/down arrows are pressed, the buttons will be highlighted
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
    }

    private void OnDisable()
    {
        //if a given button is disabled, then keyboard controls for it are also disabled
        buttonSelected = false;
    }
}
