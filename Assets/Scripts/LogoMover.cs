using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoMover : MonoBehaviour {

	private float fixedY;
	private float fixedX;
	public GameObject ghost;
	private float distance = 0.8f;
	private float scale = 0.3f;
	private bool goingUp = true;

	// Use this for initialization
	void Start () {
		fixedY = transform.position.y;
		fixedX = transform.position.x;
	}

	// Update is called once per frame
	void Update () {
		double radians = (Time.realtimeSinceStartup * 2) % (2 * System.Math.PI);
		float ySpeed = (float) (0.25 * System.Math.Cos (radians));
		transform.position = new Vector3 (fixedX, fixedY + ySpeed, 0);
		Instantiate (ghost, transform.position, transform.rotation);

		//if (goingUp) {
		//	transform.position = new Vector3 (transform.position.x, transform.position.y + scale * Time.deltaTime, 0);
		//	distance -= Time.deltaTime;
		//} else {
		//	transform.position = new Vector3 (transform.position.x, transform.position.y - scale * Time.deltaTime, 0);
		//	distance -= Time.deltaTime;
		// }
		// if (distance < 0) {
		//	distance = 0.8f;
		// 	goingUp = !goingUp;
		// }
	}
}
