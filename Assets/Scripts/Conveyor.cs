using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {

	private SurfaceEffector2D effector;
	private Transform gears;

	void Start () {
		effector = gameObject.GetComponent<SurfaceEffector2D> ();
		gears = gameObject.transform.GetChild (0).transform;
	}

	public void flip() {
		gears.Rotate(new Vector3(0, 180, 0));
		effector.speed *= -1;
	}
}
