using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
   public GameObject pickedUpObject;
   public RaycastHit hit;
   public bool equip = false;
    
	// Use this for initialization
	void Start ()
    {
    }

    // Update is called once per frame
    void Update () {
        

        if (Input.GetKeyDown("e"))
        {
            if (equip)
            {
                if (pickedUpObject.GetComponent<Rigidbody>() != null)
                {
                    pickedUpObject.GetComponent<Rigidbody>().useGravity = true;

                }
                pickedUpObject.transform.parent = null;
                pickedUpObject = null;
                equip = !equip;
            }
               /* if (hit.collider.gameObject.tag == "item" && !equip)
                { //add collider reference otherwise you can't access gameObject!

                    pickedUpObject = hit.collider.gameObject;
                     if(pickedUpObject.GetComponent<Rigidbody>() != null)
                    {
                        pickedUpObject.GetComponent<Rigidbody>().useGravity = false; 
                    }
                    pickedUpObject.transform.parent = transform;
                    pickedUpObject.transform.localPosition = new Vector3(0, 0, 2);


                    equip = !equip;
                }
                if (hit.collider.gameObject.tag == "food")
                {
                    Survival.AddFood(10);
                }
                if (hit.collider.gameObject.tag == "key")
                {
                    Destroy(hit.collider.gameObject);
                }*/
          
        }
    }
}  