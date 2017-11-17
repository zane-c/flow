using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Sink : MonoBehaviour {

	public GameObject[] balls = new GameObject[10];
	private int numBalls = 0;

	public bool flip = false;
	private int deg = 0;

	public bool changed = false;
	public bool sorted = false;
	private ScoreKeeper god;
	public int releaseNum = 0;

	// Use this for initialization
	void Start () {
		balls = new GameObject[10];
	}

	public void AddBall(GameObject ball) {
		balls [numBalls] = ball;
		numBalls++;
		print ("numballs: " + numBalls);
	}

	void GravityOff() {
		// also revive balls
		foreach (GameObject b in balls) {
			b.GetComponent<Rigidbody2D> ().gravityScale = 0;
			b.transform.gameObject.GetComponent<Ball> ().isDead = false;

		}
	}

	// Update is called once per frame
	void Update () {
		if (flip) {
			// this should happen once
			if (!changed) {
				Change ();
			}
			deg += 3;
			if (deg < 183) {
				transform.Rotate (0, 0, 3);
			} else {

				if (!sorted) {
					balls = balls.OrderBy (ball => ball.transform.position.y).ToArray ();
					sorted = true;
				}
			}
		}



	}

	void Change() {
		transform.Find("Trigger").gameObject.GetComponent<BoxCollider2D>().enabled = false;
		createFittingArray ();
		GravityOff ();

		Button playBtn = GameObject.Find ("DropBall").GetComponent<Button>();
		playBtn.onClick.AddListener(() => {
			ReleaseBall();
		});
		changed = true;
		god = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
		god.nextStage (numBalls);
		//		balls.OrderBy( b => b.transform.position.y);
	}

	void ReleaseBall() {
		if (numBalls != 0 && flip) {
			print ("releasing from sink");
			GameObject ball = balls [releaseNum];
			ball.GetComponent<CircleCollider2D> ().enabled = true;
			ball.GetComponent<Rigidbody2D> ().gravityScale = 1;
			numBalls--;
			releaseNum++;
		}
	}

	void createFittingArray() {
		GameObject[] temp = new GameObject[numBalls];
		for (int i = 0; i < balls.Length; i++) {
			GameObject b = balls [i];
			if (b != null) {
				temp [i] = b;
			}
		}
		balls = temp;
	}

}
