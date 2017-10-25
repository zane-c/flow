﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private ScoreKeeper keeperScript;
	private float initialSpeed = 5;
	public GameObject GhostBall;
	private Rigidbody2D rb;


	void Start () {
		keeperScript = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
		rb = gameObject.GetComponent<Rigidbody2D> ();
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;
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
		switch (collider.tag) {
			case "BallDeath": {
				keeperScript.ballDied();
				Destroy(gameObject);
				break;
			}
			case "Sink": {
				keeperScript.ballScored();
				break;
			}
			default: {
				break;
			}
		}
	}
}
