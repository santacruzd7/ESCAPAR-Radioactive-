using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoardRoom6b : MonoBehaviour {

	public Text boardText;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			boardText.text = "Ammonia";
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			boardText.text = "";
		}
	}
}
