using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour {

    public void LoadByIndex(int sceneIndex)
    {
        //When a button is clicked, a scene is loaded based on its scene index number 
        SceneManager.LoadScene(sceneIndex);
    }
}
