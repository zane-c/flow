using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour {

	private int SPIN_CONSTANT = -250;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Transform t = gameObject.GetComponent<SpriteRenderer> ().transform;
		t.Rotate(new Vector3(0, 0, SPIN_CONSTANT * Time.deltaTime));
	}
}
