using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	private ScoreKeeper keeperScript;
	private GameObject rotateArrow;

	void Start () {
		rotateArrow = transform.GetChild (1).gameObject;
		keeperScript = GameObject.Find ("ScoreKeeper").GetComponent<ScoreKeeper> ();
	}
	
	void Update () {
		if (keeperScript.getActiveBalls() > 0) {
			rotateArrow.SetActive(false);
		} else {
			rotateArrow.SetActive(true);
		}
	}
}
