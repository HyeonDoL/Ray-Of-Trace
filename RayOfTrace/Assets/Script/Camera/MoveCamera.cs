using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public float _cameraSpeed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Input.GetAxis("Horizontal") * _cameraSpeed * Time.deltaTime, 
		                    Input.GetAxis("Vertical") * _cameraSpeed * Time.deltaTime, 0);
	
	}
}
