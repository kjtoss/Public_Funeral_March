using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObjects : MonoBehaviour {
	float Range = 8.0f;
	public GameObject selectedObject;

	// Update is called once per frame
	void Update(){
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, Range)) {
				// the object identified by hit.transform was clicked
				// do whatever you want
				GameObject hitObject = hit.transform.root.gameObject;

				SelectObject (hitObject);
			} 
			else {
				ClearSelection ();
			}
		}
	}

	void SelectObject(GameObject obj) {
		if (selectedObject != null) {
			if (obj == selectedObject)
				return;

			ClearSelection ();
		}

		selectedObject = obj;
	}

	void ClearSelection() {
		selectedObject = null;
	}

	public void ClickSwitch() {
		Debug.Log ("foo");
	}
}
