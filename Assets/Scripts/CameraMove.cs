using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	private float panDown = 0;
	private float panUp = 0;
	private float panRight = 0;
	private float panLeft = 0;

	private float speed = 3;

	public float SCALING_CONSTANT;
	private MeshRenderer mr;
	private Material material;
	private Vector2 offset;

	// Use this for initialization
	void Start () {
		mr = transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
		material = mr.material;
		offset = material.mainTextureOffset;
	}
	
	// Update is called once per frame
	void Update () {
		if (panDown > 0) {
			transform.position = new Vector3(transform.position.x,transform.position.y - speed * Time.deltaTime, transform.position.z);
			panDown -= Time.deltaTime;
			offset.y -= Time.deltaTime / 5;
			material.mainTextureOffset = offset;
		}
		if (panUp > 0) {
			transform.position = new Vector3(transform.position.x,transform.position.y + speed * Time.deltaTime, transform.position.z);
			panUp -= Time.deltaTime;
			offset.y += Time.deltaTime / 5;
			material.mainTextureOffset = offset;
		}
		if (panLeft > 0) {
			transform.position = new Vector3(transform.position.x,transform.position.y - speed * Time.deltaTime, transform.position.z);
			panLeft -= Time.deltaTime;
			offset.x -= Time.deltaTime / 5;
			material.mainTextureOffset = offset;
		}
		if (panRight > 0) {
			transform.position = new Vector3(transform.position.x,transform.position.y + speed * Time.deltaTime, transform.position.z);
			panRight -= Time.deltaTime;
			offset.y += Time.deltaTime / 5;
			material.mainTextureOffset = offset;
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
