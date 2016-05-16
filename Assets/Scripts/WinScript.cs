using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScript : MonoBehaviour {

	public Text winText;

	public bool victory = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.CompareTag ("Player")) {
			winText.text = "Congratulations!" + System.Environment.NewLine + "Y O U  W O N !"+ System.Environment.NewLine +
				"Press “X”... ;)";
			victory = true;
		}
	}
}
