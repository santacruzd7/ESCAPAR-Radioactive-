using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial1 : MonoBehaviour {

	public Text step;
	public GameObject trigger;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			step.text = "Go to the hole. If you fell into the hole, you will reappear in the " +
				"center of the room. The same applies with the incorrect elements, but watch out: " +
				"You will lose points in this case! If a correct element is introduced it will stay " +
				"and you will score.";
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			trigger.SetActive(false);
		}
	}
}
