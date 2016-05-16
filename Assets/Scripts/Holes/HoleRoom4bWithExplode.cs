using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom4bWithExplode : MonoBehaviour {
	
	private int numHg = 0;
	private int numH = 0;

	private int numHgMax = 2;
	private int numHMax = 1;

	public GameObject player;
	public Score playerScore;

	public GameObject otherHole;
	public HoleRoom4aWithExplode otherHoleScript;
	public bool holeDone = false;
	
	public GameObject door;
	public GameObject elements;

	public Detonator explosion;
	public AudioSource boom; 

	void Start(){
		otherHoleScript = otherHole.GetComponent<HoleRoom4aWithExplode> ();
		playerScore = player.GetComponent<Score> ();
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (79.5f, 0f, -3.5f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
		    (other.gameObject.CompareTag ("O")) ||
		    (other.gameObject.CompareTag ("Fe")) ||
			(other.gameObject.CompareTag ("Hg") && numHg >= numHgMax) ||
			(other.gameObject.CompareTag ("H") && numH >= numHMax)) {
			other.gameObject.transform.position = new Vector3 (79.5f, 1f, -3.5f);
		} else if (other.gameObject.CompareTag ("Hg")) {
			numHg++;
		} else if (other.gameObject.CompareTag ("H")) {
			numH++;
		}
				
		if ((numHg == numHgMax) && (numH == numHMax)) {
			numHg++;
			numH++;
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
