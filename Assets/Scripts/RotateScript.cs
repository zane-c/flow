using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {

	private Transform parent;

	void Start () {
		parent = gameObject.transform.parent;
	}

	void Update () {
		// this is how you rotate the conveyor belt
		// parent.Rotate(0,0, 20 * Time.deltaTime);
	}
}
