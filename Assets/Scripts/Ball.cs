using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float speed = 5;
	// Use this for initialization
	void Start () {

	}

	public void init(Vector2 direction) {
		GetComponent<Rigidbody2D> ().velocity = direction * speed;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		print ("collided with something");
	}


}
