using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

	private float MAX_SPEED = 50.0f;
	private float speed = 10f;
	public GameObject Dust;
	private float theta_rad;
	private float theta_deg;

	void Start () {
		theta_deg = transform.parent.rotation.eulerAngles.z;
		theta_rad = theta_deg / Mathf.Rad2Deg;
		StartCoroutine ("SpawnDust");
	}

	IEnumerator SpawnDust() {
		yield return new WaitForSeconds(.08f);
		float x = 0.1f * Random.Range (-4, 4) * 0;
		float y = 0.1f * Random.Range (-8, 8);
		Instantiate (
			Dust, 
			transform.parent.position + new Vector3(
				x * Mathf.Cos(theta_rad) - y * Mathf.Sin(theta_rad),
				x * Mathf.Sin(theta_rad) + y * Mathf.Cos(theta_rad),
				0),
			transform.rotation
		);
		yield return SpawnDust ();
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.layer == 11 || col.gameObject.tag == "dust") {
			Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D> ();
			if (rb.velocity.magnitude < MAX_SPEED) {
				rb.AddForce (Quaternion.Euler(0, 0, theta_deg) * new Vector3 (speed, 0, 0));
			}
		}
	}
}
