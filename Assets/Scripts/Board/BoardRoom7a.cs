using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoardRoom7a : MonoBehaviour {

	public Text boardText;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			boardText.text = "Hydrochloric Acid";
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			boardText.text = "";
		}
	}
}
