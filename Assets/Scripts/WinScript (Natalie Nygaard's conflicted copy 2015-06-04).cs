using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScript2 : MonoBehaviour {

	public Text winText;

	public bool victory = false;

	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.CompareTag ("Player")) {
			winText.text = "Congratulations!" + System.Environment.NewLine + "Y O U  W O N !";
			victory = true;
		}
	}
}
