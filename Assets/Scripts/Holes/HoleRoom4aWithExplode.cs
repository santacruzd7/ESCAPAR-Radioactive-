using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom4aWithExplode : MonoBehaviour {
	
	private int numFe = 0;
	private int numO = 0;

	private int numFeMax = 4;
	private int numOMax = 3;

	public GameObject player;
	public Score playerScore;

	public GameObject otherHole;
	public HoleRoom4bWithExplode otherHoleScript;
	public bool holeDone = false;
	
	public GameObject door;
	public GameObject elements;

	public Detonator explosion;
	public AudioSource boom; 

	void Start(){
		otherHoleScript = otherHole.GetComponent<HoleRoom4bWithExplode> ();
		playerScore = player.GetComponent<Score> ();
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (79.5f, 0f, -3.5f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
		    (other.gameObject.CompareTag ("H")) ||
		    (other.gameObject.CompareTag ("Hg")) ||
			(other.gameObject.CompareTag ("Fe") && numFe >= numFeMax) ||
			(other.gameObject.CompareTag ("O") && numO >= numOMax)) {
			other.gameObject.transform.position = new Vector3 (79.5f, 1f, -3.5f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("Fe")) {
			numFe++;
			playerScore.increment();
		} else if (other.gameObject.CompareTag ("O")) {
			numO++;
			playerScore.increment();
		}
				
		if ((numFe == numFeMax) && (numO == numOMax)) {
			numFe++;
			numO++;
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
