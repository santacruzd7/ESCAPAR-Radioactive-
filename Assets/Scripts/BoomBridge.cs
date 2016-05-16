using UnityEngine;
using System.Collections;

public class BoomBridge : MonoBehaviour {

	private bool doIt = true;

	public GameObject bridge;
	public Detonator explosion;
	public AudioSource boom; 

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player") && doIt){
			Instantiate (explosion, bridge.transform.position, Quaternion.identity);
			boom.Play ();
			bridge.SetActive(false);
		}
		doIt = false; 
	}
}
