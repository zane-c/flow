using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	private float panDown = 0;
	private float panUp = 0;
	private float panRight = 0;
	private float panLeft = 0;

	private float speed = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (panDown > 0) {
			transform.position = new Vector3(transform.position.x,transform.position.y - speed * Time.deltaTime, transform.position.z);
			panDown -= Time.deltaTime;
		}
		if (panUp > 0) {
			transform.position = new Vector3(transform.position.x,transform.position.y + speed * Time.deltaTime, transform.position.z);
			panUp -= Time.deltaTime;
		}
		if (panLeft > 0) {
			transform.position = new Vector3(transform.position.x,transform.position.y - speed * Time.deltaTime, transform.position.z);
			panLeft -= Time.deltaTime;
		}
		if (panRight > 0) {
			transform.position = new Vector3(transform.position.x,transform.position.y + speed * Time.deltaTime, transform.position.z);
			panRight -= Time.deltaTime;
		}
	}

	public void PanDown(float x) {
		panDown = x;
	}

	public void PanUp(float x) {
		panUp = x;
	}

	public void PanLeft(float x) {
		panLeft = x;
	}

	public void PanRight(float x) {
		panRight = x;
	}


}
