using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom2aWithExplode : MonoBehaviour {
	
	private int numSr = 0;
	private int numH = 0;
	
	private int numSrMax = 1;
	private int numHMax = 1;

	public GameObject player;
	public Score playerScore;

	public GameObject door;
	public GameObject elements;

	public Detonator explosion;
	public AudioSource boom; 


	void Start(){
		playerScore = player.GetComponent<Score> ();
	}


	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (0f, 0f, -3.5f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
			(other.gameObject.CompareTag ("Sr") && numSr >= numSrMax) ||
			(other.gameObject.CompareTag ("H") && numH >= numHMax)) {
			other.gameObject.transform.position = new Vector3 (0f, 1f, -3.5f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("Sr")) {
			numSr++;
			playerScore.increment();
		} else if (other.gameObject.CompareTag ("H")) {
			numH++;
			playerScore.increment();
		}
				
		if ((numSr == numSrMax) && (numH == numHMax)) {
			numSr++;
			numH++;
			Instantiate (explosion, door.transform.position, Quaternion.identity);
			boom.Play ();
			door.SetActive(false);
			elements.SetActive(false);
		}
	}
}
