using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoardRoom3b : MonoBehaviour {

	public Text boardText;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			boardText.text = "Zirconium Monoxide";	//"Zirconium (II) Oxide"
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			boardText.text = "";
		}
	}
}
