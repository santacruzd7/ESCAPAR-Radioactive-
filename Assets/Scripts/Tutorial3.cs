using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial3 : MonoBehaviour {

	public GameObject tutorial;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			tutorial.SetActive(false);
		}
	}
}
