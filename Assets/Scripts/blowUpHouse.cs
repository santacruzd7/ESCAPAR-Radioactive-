using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class blowUpHouse : MonoBehaviour {
	
	//public GameObject victoryText;
	
	public GameObject mansion;
	public GameObject room1;
	public GameObject room2;
	public GameObject room3;
	public GameObject room4;

	public GameObject Win;
	public WinScript WinScript;
	
	public bool youWon = false;
	
	public Detonator explosion;
	public AudioSource boom; 

	//public Text winText;
	
	void Start () {
		//victoryText.SetActive (false);
		WinScript = Win.GetComponent<WinScript> ();
	}
	
	void Update () {
		if (WinScript.victory) {
			if(Input.GetKey(KeyCode.X)) {
				//EXPLODE THE MANSION YESSSSS
				Instantiate (explosion, room1.transform.position, Quaternion.identity);
				boom.Play ();
				Instantiate (explosion, room2.transform.position, Quaternion.identity);
				boom.Play ();
				Instantiate (explosion, room3.transform.position, Quaternion.identity);
				boom.Play ();
				Instantiate (explosion, room4.transform.position, Quaternion.identity);
				boom.Play ();
				mansion.SetActive(false);
				youWon = true;
				WinScript.winText.text = "Press “Q” to go back to the main menu!";
			}
		}

		if (youWon && Input.GetKey(KeyCode.Q)) {
			//wait so you can experience the explosive glory, then load main menu
			//Wait ();
			Application.LoadLevel("NewMenu");
		}
	}
	
	
	IEnumerator Wait() {
		yield return new WaitForSeconds(25);
	}
}