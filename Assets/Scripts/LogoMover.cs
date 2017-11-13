using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoMover : MonoBehaviour {

	private float fixedY;
	public GameObject ghost;

	// Use this for initialization
	void Start () {
		fixedY = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		double radians = (Time.realtimeSinceStartup * 2) % (2 * System.Math.PI);
		float ySpeed = (float) (0.25 * System.Math.Cos (radians));
		transform.position = new Vector3 (transform.position.x, fixedY + ySpeed, 0);

		Instantiate (ghost, transform.position, transform.rotation);
	}
}
