using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom5aWithExplode : MonoBehaviour {
	
	private int numGa = 0;
	private int numO = 0;
	
	private int numGaMax = 4;
	private int numOMax = 3;

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
			other.gameObject.transform.position = new Vector3 (91.5f, 0f, 0f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
			(other.gameObject.CompareTag ("Ga") && numGa >= numGaMax) ||
			(other.gameObject.CompareTag ("O") && numO >= numOMax)) {
			other.gameObject.transform.position = new Vector3 (91.5f, 1f, 0f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("Ga")) {
			numGa++;
			playerScore.increment();
		} else if (other.gameObject.CompareTag ("O")) {
			numO++;
			playerScore.increment();
		}
				
		if ((numGa == numGaMax) && (numO == numOMax)) {
			numGa++;
			numO++;
			Instantiate (explosion, door.transform.position, Quaternion.identity);
			boom.Play ();
			door.SetActive(false);
			elements.SetActive(false);
		}
	}
}
