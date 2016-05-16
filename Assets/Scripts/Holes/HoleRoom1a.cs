using UnityEngine;
using System.Collections;

public class HoleRoom1a : MonoBehaviour {
	
	private int numNa = 0;
	private int numO = 0;
	
	private int numNaMax = 4;
	private int numOMax = 1;
	
	public GameObject door;
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Na")) {
			numNa++;
		} else if (other.gameObject.CompareTag ("O")) {
			numO++;
		} else if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3(0f,0f,7f);
		} else if (other.gameObject.CompareTag ("Wrong")){
			other.gameObject.transform.position = new Vector3(0f,1f,7f);
		}
				
		if ((numNa == numNaMax) && (numO == numOMax)) {
			door.SetActive(false);
		}
	}
}
