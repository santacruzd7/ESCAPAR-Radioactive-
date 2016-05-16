using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom6bWithExplode : MonoBehaviour {
	
	private int numN = 0;
	private int numH = 0;
	
	private int numNMax = 1;
	private int numHMax = 3;

	public GameObject player;
	public Score playerScore;

	public GameObject door;
	public GameObject elements;

	public GameObject otherHole;
	public HoleRoom6aWithExplode otherHoleScript;
	public bool holeDone = false;

	public GameObject secretRoom;
	public SecretRoom secretRoomScript;

	public Detonator explosion;
	public AudioSource boom; 


	void Start(){
		otherHoleScript = otherHole.GetComponent<HoleRoom6aWithExplode> ();
		secretRoomScript = secretRoom.GetComponent<SecretRoom> ();
		playerScore = player.GetComponent<Score> ();
	}


	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (95.25f, 0f, 7.15f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
		    (other.gameObject.CompareTag ("C")) ||
			(other.gameObject.CompareTag ("N") && numN >= numNMax) ||
			(other.gameObject.CompareTag ("H") && numH >= numHMax)) {
			other.gameObject.transform.position = new Vector3 (95.25f, 1f, 7.15f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("N")) {
			numN++;
			playerScore.increment();
		} else if (other.gameObject.CompareTag ("H")) {
			numH++;
			playerScore.increment();
		}
				
		if ((numN == numNMax) && (numH == numHMax)) {
			numN++;
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
