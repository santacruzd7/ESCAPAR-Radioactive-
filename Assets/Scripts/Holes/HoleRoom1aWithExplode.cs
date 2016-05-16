using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class HoleRoom1aWithExplode : MonoBehaviour {
	
	private int numNa = 0;
	private int numO = 0;
	
	private int numNaMax = 4;
	private int numOMax = 1;

	public GameObject player;
	public Score playerScore;
	
	public GameObject door;
	public GameObject elements;
	
	public Detonator explosion;
	public AudioSource boom; 

	public Text step;


	void Start(){
		playerScore = player.GetComponent<Score> ();
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.transform.position = new Vector3 (0f, 0f, 7f);
		} else if (other.gameObject.CompareTag ("Wrong") || 
			(other.gameObject.CompareTag ("Na") && numNa >= numNaMax) ||
			(other.gameObject.CompareTag ("O") && numO >= numOMax)) {
			other.gameObject.transform.position = new Vector3 (0f, 1f, 7f);
			playerScore.decrement();
		} else if (other.gameObject.CompareTag ("Na")) {
			numNa++;
			playerScore.increment();
		} else if (other.gameObject.CompareTag ("O")) {
			numO++;
			playerScore.increment();
		}
				
		if ((numNa == numNaMax) && (numO == numOMax)) {
			numNa++;
			numO++;
			Instantiate (explosion, door.transform.position, Quaternion.identity);
			boom.Play ();
			door.SetActive(false);
			elements.SetActive(false);
			step.text = "Congratulations! You’ve successfully completed the tutorial!"+ System.Environment.NewLine +
				"Keep playing and escape the Periodic Mansion!";
		}
	}
}
