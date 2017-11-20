using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flux : MonoBehaviour {

	private float MAX_SPEED = 50.0f;
	private float speed = 10f;
	public GameObject lines;
	private float theta_rad;
	private float theta_deg;

	void Start () {
		theta_deg = transform.parent.rotation.eulerAngles.z;
		theta_rad = theta_deg / Mathf.Rad2Deg;
		StartCoroutine ("SpawnLines");
	}

	IEnumerator SpawnLines() {
		yield return new WaitForSeconds(.3f);
		float x = 0f;
		float y = -2.0f;
		Instantiate (
			lines, 
			transform.parent.position + new Vector3(
				x * Mathf.Cos(theta_rad) - y * Mathf.Sin(theta_rad),
				x * Mathf.Sin(theta_rad) + y * Mathf.Cos(theta_rad),
				0),
			transform.rotation
		);
		yield return SpawnLines ();
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.layer == 11 || col.gameObject.tag == "Flux") {
			Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D> ();
			if (rb.velocity.magnitude < MAX_SPEED) {
				rb.AddForce (Quaternion.Euler(0, 0, theta_deg) * new Vector3 (0, speed, 0));
			}
		}
	}
}
