using UnityEngine;
using System.Collections;

public class PreventFall : MonoBehaviour {

	public GameObject player;
	public Score playerScore;

	void Start(){
		playerScore = player.GetComponent<Score> ();
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (62f, 0f, -3.5f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("Wrong") || 
		           (other.gameObject.CompareTag ("O")) ||
		           (other.gameObject.CompareTag ("Zr")) ||
		           (other.gameObject.CompareTag ("Mn")) ||
		           (other.gameObject.CompareTag ("H"))) {
			other.gameObject.transform.position = new Vector3 (62f, 1f, -3.5f);
			playerScore.decrement();
		}
	}
}
