using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoBall : MonoBehaviour {

	private float initialSpeed = 5;
	public GameObject GhostBall;
	private Rigidbody2D rb;
	private bool isDead = false;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	public void init(Vector2 direction) {
		GetComponent<Rigidbody2D>().velocity = direction * initialSpeed;
	}

	void Update () {
		if (rb.velocity.magnitude > 0.1f) {
			Instantiate (GhostBall, transform.position, transform.rotation);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.CompareTag ("BallDeath") && !isDead) {
			Destroy (gameObject);
			isDead = true;
		} else if (collider.tag == gameObject.name && !isDead) {
			isDead = true;
		} else if (collider.gameObject.layer == 8 && !isDead) {
			isDead = true;
		}
	}
}
