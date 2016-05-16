using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class victoryScript : MonoBehaviour {

	//public GameObject victoryText;

	public GameObject mansion;
	public WinScript winScript;
	public bool youWon = false;

	public Detonator explosion;
	public AudioSource boom; 
	
	void Start () {
		//victoryText.SetActive (false);
	}

	void Update () {
		if (winScript.victory) {
			if(Input.GetKey(KeyCode.X)) {
				//EXPLODE THE MANSION YESSSSS
				Instantiate (explosion, mansion.transform.position, Quaternion.identity);
				boom.Play ();
				mansion.SetActive(false);
				youWon = true;
			}
		}

		if (youWon) {
			//wait so you can experience the explosive glory, then load main menu
			Wait ();
			Application.LoadLevel("Menu");
		}
	}
	

	IEnumerator Wait() {
		yield return new WaitForSeconds(5);
	}
}
