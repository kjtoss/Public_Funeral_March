using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneFlip : MonoBehaviour {

    private Animator FlipAnimator;
    public GameObject PauseMenu;
    private bool MenuNotShown = true;

	// Use this for initialization
	void Start () {
        FlipAnimator = GetComponent<Animator>();
       
	}
	
	// Update is called once per frame
	void Update () {
        if (MenuNotShown == true && Input.GetKeyDown(KeyCode.P))
         {
            FlipAnimator.Play("Flipped");
        
             PauseMenu.SetActive(true);
             MenuNotShown = false;
         }
         else if (MenuNotShown == false && Input.GetKeyDown(KeyCode.P))
             {
            FlipAnimator.Play("Unflipped");     
             PauseMenu.SetActive(false);
             MenuNotShown = true;
         }

        MenuAppear();
        
    }

    void MenuAppear() {
    if (MenuNotShown == true)
        {
            PauseMenu.SetActive(false);
        }
        else if (MenuNotShown == false)
        {
            PauseMenu.SetActive(true);
        }
    }
}
