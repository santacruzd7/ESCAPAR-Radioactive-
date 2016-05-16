using UnityEngine;
using System.Collections;

public class MenuBehavior : MonoBehaviour {

	GameObject[] primaryMenu;
	GameObject[] optionsMenu;
	GameObject[] instructions;
	public AudioSource music;

	// Use this for initialization
	void Start () {
		primaryMenu = GameObject.FindGameObjectsWithTag ("Primary");
		optionsMenu = GameObject.FindGameObjectsWithTag ("Options");
		instructions = GameObject.FindGameObjectsWithTag ("Instructions");

		foreach (GameObject item in optionsMenu)
			item.SetActive (false);

		foreach (GameObject item in instructions)
			item.SetActive (false);
	}

	public void OptionsMenu() {
		foreach (GameObject item in primaryMenu)
			item.SetActive (false);

		foreach (GameObject item in instructions)
			item.SetActive (false);

		foreach (GameObject item in optionsMenu)
			item.SetActive (true);
	}

	public void PrimaryMenu()  {
		foreach (GameObject item in optionsMenu)
			item.SetActive (false);

		foreach (GameObject item in instructions)
			item.SetActive (false);

		foreach (GameObject item in primaryMenu)
			item.SetActive (true);
	}

	public void Instructions()  {
		foreach (GameObject item in optionsMenu)
			item.SetActive (false);
		
		foreach (GameObject item in primaryMenu)
			item.SetActive (false);
		
		foreach (GameObject item in instructions)
			item.SetActive (true);
	}

	public void LoadLevel() {
		PlayerPrefs.SetFloat("Volume", music.volume);
		Application.LoadLevel ("Natalie Exploding Doors David Modification 2");
	}

	public void Quit () {
		Application.Quit ();
	}
}
