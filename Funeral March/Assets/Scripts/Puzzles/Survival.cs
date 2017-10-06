using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Survival : MonoBehaviour {
    static Slider foodSlider;
    [SerializeField]
    float timeTilHunger;
    float time;
    static int maxFood = 100;
    static int currentFood = 100;
   
    // Use this for initialization
    void Start () {
        
    }
    // Update is called once per frame
    private void OnEnable()
    {
        foodSlider = FindObjectOfType<Slider>();
        if (GameManager.instance.Level == "Will")
        {
            foodSlider.enabled = true;
        }
        else
        {
            foodSlider.enabled = false;
            this.GetComponent<Survival>().enabled = false;
        }
    }
    void Update () {
        if (time <= 0)
        {  AddFood(-1);
            time =timeTilHunger;
        }
        time -= Time.deltaTime;
	}
    public static void AddFood(int add)
    {
        currentFood += add;
        if (currentFood <= 0)
        {
            Debug.Log("Oh shit! Will died of hunger.");
            GameManager.instance.CharacterEnded("Will");
        }
        else if (currentFood >= maxFood)
        {
            currentFood = maxFood;
        }
        
        //Update UI
        foodSlider.value = currentFood;
       
    }
}
