using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour {
    public Texture2D crosshairImage;

    // Use this for initialization
    void Start () {
    }

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairImage.width / 20);
        float yMin = (Screen.height / 2) - (crosshairImage.height / 20);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width/10, crosshairImage.height/10), crosshairImage);
    }

    // Update is called once per frame
    void Update () {
		
	}
}