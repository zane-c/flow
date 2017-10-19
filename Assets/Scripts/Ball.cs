﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private ScoreKeeper keeperScript;
	private float initialSpeed = 5;
	public GameObject GhostBall;


	void Start () {
		keeperScript = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
	}

	public void init(Vector2 direction) {
		GetComponent<Rigidbody2D>().velocity = direction * initialSpeed;
	}

	void Update () {
		Instantiate(GhostBall, transform.position, transform.rotation);
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
