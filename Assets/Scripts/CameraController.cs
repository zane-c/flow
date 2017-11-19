using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public bool move = false;
	public Vector3 dest;
	public float speed = 3.0f;
	private GameObject ballDeath;

	// Use this for initialization
	void Start () {
	}

	void Update() {
		if (move) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, dest, step);
			ballDeath = GameObject.Find ("BallDeath");
			Vector3 deathdest = new Vector3 (ballDeath.transform.position.x, ballDeath.transform.position.y - 3.0f, 0.0f);
			ballDeath.transform.position = Vector3.MoveTowards(ballDeath.transform.position, deathdest, step);
			if (transform.position == dest) {
				move = false;
			}
		}
	}

}
