using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingTides : MonoBehaviour {
    [SerializeField] private GameObject water;  //the object that rises
    [SerializeField] private Camera cam;  //the camera
    [SerializeField]
    private float speed;
    [SerializeField]
    float time; // time until the water moves again.
    [SerializeField]
    bool canBeAbovePlayer;
    private float timer;
	void Start()
    {
        timer = time;
    }
    // Update is called once per frame
    void Update()
    {
        if (canBeAbovePlayer) { 

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                water.transform.Translate(new Vector3(0, speed, 0));
                timer = time;
            }
              
            if (water.transform.position.y >= cam.transform.position.y - 0.2f)
            {
                RenderSettings.fogMode = FogMode.Exponential;
                RenderSettings.fog = true;
                RenderSettings.fogDensity = .35f;
                RenderSettings.fogColor = new Color(.05f, .24f, .33f, .55f);
            }
            else
            {
                RenderSettings.fog = false;
            }
        }
    }
        
}
