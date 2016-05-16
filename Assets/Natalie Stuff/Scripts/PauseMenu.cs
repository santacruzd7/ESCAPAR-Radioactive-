using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour 
{
	public GameObject pauseMenu;
	public AudioSource music;
	bool paused;
	float time;


	// Use this for initialization
	void Start () 
	{
		music.volume = PlayerPrefs.GetFloat ("Volume");
		pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("escape") && !paused)
		{
			music.Pause();
			time = Time.timeScale;
			Time.timeScale = 0;
			paused = true;
			pauseMenu.SetActive(true);
		}
		else if (Input.GetKeyDown("escape") && paused)
		{
			music.UnPause();
			Time.timeScale = time;
			paused = false;
			pauseMenu.SetActive(false);
		}
	}

	public void ExitLevel() {
		Application.LoadLevel ("NewMenu");
	}

}
