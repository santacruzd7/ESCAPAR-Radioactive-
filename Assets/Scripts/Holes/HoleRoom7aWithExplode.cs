using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom7aWithExplode : MonoBehaviour {
	
	private int numCl = 0;
	private int numH = 0;
	
	private int numClMax = 1;
	private int numHMax = 1;

	public GameObject player;
	public Score playerScore;

	public GameObject door;
	public GameObject elements;

	public GameObject otherHole;
	public HoleRoom7bWithExplode otherHoleScript;
	public bool holeDone = false;

	public GameObject secretRoom;
	public SecretRoom secretRoomScript;
	
	public Detonator explosion;
	public AudioSource boom; 


	void Start(){
		otherHoleScript = otherHole.GetComponent<HoleRoom7bWithExplode> ();
		secretRoomScript = secretRoom.GetComponent<SecretRoom> ();
		playerScore = player.GetComponent<Score> ();
	}


	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (102.5f, 0f, 0f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
		    (other.gameObject.CompareTag ("S")) ||
			(other.gameObject.CompareTag ("Cl") && numCl >= numClMax) ||
			(other.gameObject.CompareTag ("H") && numH >= numHMax)) {
			other.gameObject.transform.position = new Vector3 (102.5f, 1f, 0f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("Cl")) {
			numCl++;
			playerScore.increment();
		} else if (other.gameObject.CompareTag ("H")) {
			numH++;
			playerScore.increment();
		}
				
		if ((numCl == numClMax) && (numH == numHMax)) {
			numCl++;
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
