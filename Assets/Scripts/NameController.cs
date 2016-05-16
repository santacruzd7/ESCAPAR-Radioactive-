using UnityEngine;
using System.Collections;

public class NameController : MonoBehaviour {

	public GameObject element;
	public GameObject cam;
	private Vector3 offsetPos;

	// Use this for initialization
	void Start () {
		offsetPos = transform.position - element.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (cam.transform);
		transform.eulerAngles = new Vector3 (0,transform.eulerAngles.y,0);
		transform.position = element.transform.position + offsetPos;
		//transform.rotation.Set(0.0f,transform.rotation.y,0.0f,transform.rotation.w);
	}
}
