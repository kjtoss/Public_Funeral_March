using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GODMODE : MonoBehaviour {
    [SerializeField]
    private Text godModeUI;
    private bool isGod = false;
    private List<Collider> colliders = new List<Collider>();
	// Use this for initialization
	void Start () {
        godModeUI.enabled = false;
        Scene scene = gameObject.scene;
        GameObject[] objects = scene.GetRootGameObjects();
        foreach (GameObject game in objects)
        {
            foreach (Collider col in game.GetComponentsInChildren<Collider>())
            {
                if (col.gameObject.layer != 9 && col.gameObject.layer != 8 && col.gameObject.tag != "Player")
                {
                    colliders.Add(col);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Period)){
            if (isGod)
            {
                //Set God Mode off
                foreach (Collider col in colliders)
                    col.enabled = true;
                isGod = !isGod;
                godModeUI.enabled = false;
            }
            else
            {
                //Turn God Mode on
                foreach (Collider col in colliders)
                    col.enabled = false;
                isGod = !isGod;
                godModeUI.enabled = true;
            }

        }
    }
    
}
