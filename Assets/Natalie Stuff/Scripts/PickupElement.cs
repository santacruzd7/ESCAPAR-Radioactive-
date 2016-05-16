using UnityEngine;
using System.Collections;

public class PickupElement2 : MonoBehaviour {
	bool carrying = false;
	GameObject carriedObject;

	public float distance; //1.5
	public float smooth; //1
	
	void FixedUpdate() {
		if (carrying) {
			carry (carriedObject);
			checkDrop();
		} else {
			pickup ();
		}
	}

	void carry(GameObject element) {
		//check distance between player and wall - if less than distance, lerp to wall position.

		element.transform.position = Vector3.Lerp (element.transform.position, 
				                                           (transform.position + new Vector3 (0, 1)) + transform.forward * distance, 
				                                           Time.deltaTime * smooth);
	}

	void pickup() {
		if(Input.GetKeyDown(KeyCode.E)) {
			Ray ray = new Ray(transform.position + new Vector3(0,.2f), transform.forward);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)) {
				if(hit.collider.tag != "Untagged") {
					carrying = true;
					carriedObject = hit.collider.gameObject;
					carriedObject.GetComponent<Rigidbody>().isKinematic = true;
				}
			}
		}
	}

	void checkDrop() {
		if (Input.GetKeyDown (KeyCode.E)) {
			dropObject();
		}
	}

	void dropObject() {
		carrying = false;
		carriedObject.GetComponent<Rigidbody>().isKinematic = false;
		carriedObject = null;

	}

}