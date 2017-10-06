using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager instance;
    [SerializeField]
    [Tooltip("The range that the player should be able to look")]
    private float distance = 1f;
    [SerializeField]
    [Tooltip("The time between raycasts if the button is held")]
    private float timeBetween = 0.5f;

    private float timer = 0;
    private GameObject pickedUpObject;
    private bool equip;
    private int layer;
    private bool FlashLight = false;
    private bool isLightOn = false;
    private bool sitting = false;
    private Sitting seat;
    private float baseFOV;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization
    void Start()
    {
        layer = LayerMask.GetMask("Interactable");
        baseFOV = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (Camera.main.fieldOfView > 40f)
                Camera.main.fieldOfView = Camera.main.fieldOfView - 0.5f;
            else
                Camera.main.fieldOfView = 40f;
        }
        else if (Camera.main.fieldOfView < baseFOV)
        {
            Camera.main.fieldOfView = Camera.main.fieldOfView + 0.5f;

        }

        if (Input.GetMouseButton(0))
        {
            if (equip)
            {
                DropItem();
            }
            else
            {
                 CheckForInteractables();
                
             }
        }
        if (Input.GetKeyDown(KeyCode.F) && FlashLight == true)
        {
            if (isLightOn)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Light>().intensity = .1f;
                GameObject.FindGameObjectWithTag("Item").GetComponent<Light>().intensity = 0f;
                isLightOn = false;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Light>().intensity = 1f;
                GameObject.FindGameObjectWithTag("Item").GetComponent<Light>().intensity = 1f;
                isLightOn = true;
            }
        }

    }
    void CheckForInteractables()
    {

        timer += Time.deltaTime;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, distance, layer) && timer > timeBetween)
        {
            CheckTag(hit);
            timer = 0f;
        }

        else if (sitting && timer > timeBetween)
            seat.StartSitting();
    }
    void CheckTag(RaycastHit hit)
    {

        //Everything should have a collider
        switch (hit.collider.gameObject.tag)
        {
            case "Item":
                EquipItem(hit.collider.gameObject);
                break;
            case "Food":
                Survival.AddFood(10);
                break;
            case "Key":
                Destroy(hit.collider.gameObject);
                break;
            case "Door":
                hit.collider.gameObject.GetComponent<DoorHandler>().RotateSetUp();
                break;
            case "Light":
                hit.collider.gameObject.GetComponent<LightSwitch>().SwitchLight();
                break;
            case "Stair":
                hit.collider.gameObject.GetComponent<Stairs>().StairClimb();
                break;
            case "Sitting":
                hit.collider.gameObject.GetComponent<Sitting>().StartSitting();
                break;
            case "ComboLock":
                Debug.Log("I haven't put this shite in yet :/");
                break;
            case "Flashlight":
                Destroy(hit.collider.gameObject);
                FlashLight = true;
                break;
            default:
                Debug.LogError("Unknown tag. Did you forget to add the tag to CheckTag in Mouse Manager?");
                break;
        }
    }
    void EquipItem(GameObject gameObject)
    {
        pickedUpObject = gameObject;
        if (pickedUpObject.GetComponent<Rigidbody>() != null)
        {
            pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
        }
        pickedUpObject.transform.parent = transform;
        pickedUpObject.transform.localPosition = new Vector3(0, 0, 2);


        equip = !equip;
    }
    void DropItem(){
            if (pickedUpObject.GetComponent<Rigidbody>() != null)
                {
                    pickedUpObject.GetComponent<Rigidbody>().useGravity = true;

                }
                pickedUpObject.transform.parent = null;
                pickedUpObject = null;
                equip = !equip;
        }
    public void IsSitting(bool value, Sitting seated = null)
    {
        sitting = value;
        seat = seated;
    }
    
}