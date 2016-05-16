using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial2 : MonoBehaviour {

	public Text step;
	public GameObject trigger;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			step.text = "It seems that the compound is “Sodium Oxide”. Now, you need to guess its formula: “Na20”. " +
				"Then, balance the combination reaction equation to get the amount of each element you need to put into " +
					"the hole." + System.Environment.NewLine + "Na + O2 = Na2O ; 4Na + O2 = 2Na20." + 
					System.Environment.NewLine + "So you need to put 4 Na and 1 O2. Go for it!";
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			step.text = "Move next to an element and press “E” to pick it up. Press “E” again to release it. " +
				"Do this next to the hole and create Na20!";
			trigger.SetActive(false);
		}
	}
}
