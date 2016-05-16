using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom3aWithExplode : MonoBehaviour {
	
	private int numMn = 0;
	private int numH = 0;

	private int numMnMax = 2;
	private int numHMax = 3;

	public GameObject player;
	public Score playerScore;

	public GameObject otherHole;
	public HoleRoom3bWithExplode otherHoleScript;
	public bool holeDone = false;
	
	public GameObject door;
	public GameObject elements;

	public Detonator explosion;
	public AudioSource boom; 

	void Start(){
		otherHoleScript = otherHole.GetComponent<HoleRoom3bWithExplode> ();
		playerScore = player.GetComponent<Score> ();
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (62f, 0f, -3.5f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
		    (other.gameObject.CompareTag ("O")) ||
		    (other.gameObject.CompareTag ("Zr")) ||
			(other.gameObject.CompareTag ("Mn") && numMn >= numMnMax) ||
			(other.gameObject.CompareTag ("H") && numH >= numHMax)) {
			other.gameObject.transform.position = new Vector3 (62f, 1f, -3.5f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("Mn")) {
			numMn++;
			playerScore.increment();
		} else if (other.gameObject.CompareTag ("H")) {
			numH++;
			playerScore.increment();
		}
				
		if ((numMn == numMnMax) && (numH == numHMax)) {
			numMn++;
			numH++;
			holeDone = true;
			if(otherHoleScript.holeDone){
				Instantiate (explosion, door.transform.position, Quaternion.identity);
				boom.Play ();
				door.SetActive(false);
				elements.SetActive(false);
			}
		}
	}


}
