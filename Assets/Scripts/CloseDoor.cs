using UnityEngine;
using System.Collections;

public class CloseDoor : MonoBehaviour {

	public GameObject door;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			door.SetActive(true);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
