using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom7bWithExplode : MonoBehaviour {
	
	private int numS = 0;
	private int numH = 0;
	
	private int numSMax = 1;
	private int numHMax = 1;

	public GameObject player;
	public Score playerScore;

	public GameObject door;
	public GameObject elements;

	public GameObject otherHole;
	public HoleRoom7aWithExplode otherHoleScript;
	public bool holeDone = false;

	public GameObject secretRoom;
	public SecretRoom secretRoomScript;
	
	public Detonator explosion;
	public AudioSource boom; 


	void Start(){
		otherHoleScript = otherHole.GetComponent<HoleRoom7aWithExplode> ();
		secretRoomScript = secretRoom.GetComponent<SecretRoom> ();
		playerScore = player.GetComponent<Score> ();
	}


	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (102.5f, 0f, 0f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
		    (other.gameObject.CompareTag ("Cl")) ||
			(other.gameObject.CompareTag ("S") && numS >= numSMax) ||
			(other.gameObject.CompareTag ("H") && numH >= numHMax)) {
			other.gameObject.transform.position = new Vector3 (102.5f, 1f, 0f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("S")) {
			numS++;
			playerScore.increment();
		} else if (other.gameObject.CompareTag ("H")) {
			numH++;
			playerScore.increment();
		}
				
		if ((numS == numSMax) && (numH == numHMax)) {
			numS++;
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
