using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoardRoom3a : MonoBehaviour {

	public Text boardText;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			boardText.text = "Manganic Hydride";	//"Manganese (III) Hydride"
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			boardText.text = "";
		}
	}
}
