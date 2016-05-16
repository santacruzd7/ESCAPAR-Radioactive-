using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom3bWithExplode : MonoBehaviour {
	
	private int numZr = 0;
	private int numO = 0;

	private int numZrMax = 2;
	private int num0Max = 1;

	public GameObject player;
	public Score playerScore;

	public GameObject otherHole;
	public HoleRoom3aWithExplode otherHoleScript;
	public bool holeDone = false;
	
	public GameObject door;
	public GameObject elements;

	public Detonator explosion;
	public AudioSource boom; 

	void Start(){
		otherHoleScript = otherHole.GetComponent<HoleRoom3aWithExplode> ();
		playerScore = player.GetComponent<Score> ();
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (62f, 0f, -3.5f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
		    (other.gameObject.CompareTag ("H")) ||
		    (other.gameObject.CompareTag ("Mn")) ||
		    (other.gameObject.CompareTag ("Zr") && numZr >= numZrMax) ||
			(other.gameObject.CompareTag ("O") && numO >= num0Max)) {
			other.gameObject.transform.position = new Vector3 (62f, 1f, -3.5f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("Zr")) {
			numZr++;
			playerScore.increment();
		} else if (other.gameObject.CompareTag ("O")) {
			numO++;
			playerScore.increment();
		}
				
		if ((numZr == numZrMax) && (numO == num0Max)) {
			numZr++;
			numO++;
			holeDone = true;
			if(otherHoleScript.holeDone == true){
				Instantiate (explosion, door.transform.position, Quaternion.identity);
				boom.Play ();
				door.SetActive(false);
				elements.SetActive(false);
			}
		}
	}
}
