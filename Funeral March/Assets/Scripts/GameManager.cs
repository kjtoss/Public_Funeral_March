using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;   //Static instance of GameManager which allows it to be accessed by any other script.
    private string level; // The level that the player is currently on (stored as the name of the character, "firepit", or "titlemenu".
    public RawImage firepit;
    bool ng;
    [SerializeField]
    Vector3 startWill;
    [SerializeField]
    Vector3 startEmilia;
    [SerializeField]
    Vector3 startMiles;
    [SerializeField]
    Vector3 startNaomi;
    [SerializeField]
    Vector3 startAdam;
    [SerializeField]
    public GameObject player; //a reference to the current player
    [SerializeField]
    GameObject FPSController;// the gameobject that is instantiated on Load, and the position saved in Save
    private Survival survival;

    public string Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Set up event handlers for Scene changing
        SceneManager.sceneLoaded += OnSceneLoaded;

        //Get the Survival component 
        survival = this.gameObject.GetComponent<Survival>(); 
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject controller = new GameObject();
        if (!(scene.name == "MainMenu") && !(scene.name == "FoodTest"))
        {
            switch (Level)
            {
                case "Emilia":
                    controller = GameObject.Find("EmiliaFPSController");
                    if (controller == null) controller = GameObject.Instantiate(FPSController) as GameObject;
                    player = controller;
                    break;
                case "Naomi":
                    controller = GameObject.Find("NaomiFPSController");
                    if (controller == null) controller = GameObject.Instantiate(FPSController) as GameObject;
                    player = controller;
                    break;
                case "Will":
                    controller = GameObject.Find("WillFPSController");
                    if (controller == null) controller = GameObject.Instantiate(FPSController) as GameObject;
                    player = controller;
                    break;
                case "Adam":
                    controller = GameObject.Find("AdamFPSController");
                    if (controller == null) controller = GameObject.Instantiate(FPSController) as GameObject;
                    player = controller;
                    break;
                case "Miles":
                    controller = GameObject.Find("MilesFPSController");
                    if (controller == null) controller = GameObject.Instantiate(FPSController) as GameObject;
                    player = controller;
                    break;
                default:
                    Debug.Log("What is the level?");
                    break;
            }
        }
        if(player == null)
        {
            Debug.Log("Please be a Menu");
        }
        if(level == "Will" && !survival.enabled)
        {
            survival.enabled = true;
        }
        // make an else if to disable survival.
    }
    
    public void Save()
    {
        
        // Save ending floats
        //TODO: Save Ending Floats
       
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Create);
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            
        }
        playData data = new playData(player.transform.position.x, player.transform.position.y, player.transform.position.z, SceneManager.GetActiveScene().name, level);

        bf.Serialize(file, data);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
            playData data = bf.Deserialize(file) as playData;
            file.Close();

            level = data.Level;
            SceneManager.LoadScene(data.ActiveScene);
            player.transform.position = new Vector3(data.XPos, data.YPos, data.ZPos);
        }    
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            Save();
        }
    }
    public void NewGame()
    {
        firepit.gameObject.SetActive(true);
        
    }
    public void LoadLevel(string name)
    {
        level = name;
        //TODO: Input logic for finding the characters.
        if (name.Equals("Adam"))
        {
            SceneManager.LoadScene("SecondFloorTest");
        }
        else
        {
            SceneManager.LoadScene("FirstFloorTest");
            if (name.Equals("Emilia")){
                
            }
            else if (name.Equals("Miles")) {

            }
            else if (name.Equals("Will"))
            {
                
            }
            else if (name.Equals("Naomi"))
            {

            }
            else
            {
                Debug.Log("error");
            }
        }

    }
    public void CharacterEnded(string Character)
    {
        //TODO: Implement ending code.
    }
}

//Class to save player data
[System.Serializable]
class playData
{
    private float xPos;
    private float yPos;
    private float zPos;
    private string activeScene;
    private string level;
    
    public playData(float x, float y, float z, string Scene, string Level){
        xPos = x;
        yPos = y;
        zPos = z;
        activeScene = Scene;
        level = Level;
    }
    //position
    public float XPos
    { get{return xPos;} set{xPos = value;} }
    public float YPos
    { get{return yPos;} set{yPos = value;} }
    public float ZPos
    { get{return zPos;} set{zPos = value;} }
    //strings
    public string ActiveScene
    { get{return activeScene;} set{activeScene = value;} }
    public string Level
    { get{return level;} set{level = value;} }
    //Include ending floats
}