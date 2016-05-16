using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoardRoom6a : MonoBehaviour {

	public Text boardText;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			boardText.text = "Methane";
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			boardText.text = "";
		}
	}
}
