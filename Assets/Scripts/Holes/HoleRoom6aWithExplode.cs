using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom6aWithExplode : MonoBehaviour {
	
	private int numC = 0;
	private int numH = 0;
	
	private int numCMax = 1;
	private int numHMax = 2;

	public GameObject player;
	public Score playerScore;

	public GameObject otherHole;
	public HoleRoom6bWithExplode otherHoleScript;
	public bool holeDone = false;

	public GameObject secretRoom;
	public SecretRoom secretRoomScript;

	public GameObject door;
	public GameObject elements;

	public Detonator explosion;
	public AudioSource boom; 
	
	void Start(){
		otherHoleScript = otherHole.GetComponent<HoleRoom6bWithExplode> ();
		secretRoomScript = secretRoom.GetComponent<SecretRoom> ();
		playerScore = player.GetComponent<Score> ();
	}


	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (95.25f, 0f, 7.15f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
		    (other.gameObject.CompareTag ("N")) ||
			(other.gameObject.CompareTag ("C") && numC >= numCMax) ||
			(other.gameObject.CompareTag ("H") && numH >= numHMax)) {
			other.gameObject.transform.position = new Vector3 (95.25f, 1f, 7.15f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("C")) {
			numC++;
			playerScore.increment();
		} else if (other.gameObject.CompareTag ("H")) {
			numH++;
			playerScore.increment();
		}
				
		if ((numC == numCMax) && (numH == numHMax)) {
			numC++;
			numH++;
			holeDone = true;

			if(!otherHoleScript.holeDone){
				Instantiate (explosion, door.transform.position, Quaternion.identity);
				boom.Play ();
				door.SetActive(false);
			} else {
				secretRoomScript.checkRoomCondition();
				elements.SetActive(false);
			}
		}
	}
}
