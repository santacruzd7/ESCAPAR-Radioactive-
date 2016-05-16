using UnityEngine;
using System.Collections;

public class SecretRoom : MonoBehaviour {

	public GameObject player;
	public Score playerScore;

	public GameObject trigger;

	public GameObject wall1;
	public GameObject wall2;

	public GameObject hole6a;
	public GameObject hole6b;
	public GameObject hole7a;
	public GameObject hole7b;

	public HoleRoom6aWithExplode hole6aScript;
	public HoleRoom6bWithExplode hole6bScript;
	public HoleRoom7aWithExplode hole7aScript;
	public HoleRoom7bWithExplode hole7bScript;

	// Use this for initialization
	void Start () {
		playerScore = player.GetComponent<Score> ();
		hole6aScript = hole6a.GetComponent<HoleRoom6aWithExplode> ();
		hole6bScript = hole6b.GetComponent<HoleRoom6bWithExplode> ();
		hole7aScript = hole7a.GetComponent<HoleRoom7aWithExplode> ();
		hole7bScript = hole7b.GetComponent<HoleRoom7bWithExplode> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			playerScore.extraPoints();
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			trigger.SetActive(false);
		}
	}

	public void checkRoomCondition(){
		if(hole6aScript.holeDone && hole6bScript.holeDone && hole7aScript.holeDone && hole7bScript.holeDone){
			wall1.SetActive(false);
			wall2.SetActive(false);
		}
	}
}
