using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	private ScoreKeeper keeperScript;
	private GameObject rotateArrow;

	public bool disabledOnStart = false;

	void Start () {
		rotateArrow = transform.GetChild (1).gameObject;
		keeperScript = GameObject.Find ("ScoreKeeper").GetComponent<ScoreKeeper> ();
		if (disabledOnStart) {
			gameObject.tag = "Untagged";
		}
	}

	void Update () {
		if (keeperScript.getActiveBalls() > 0 || disabledOnStart) {
			rotateArrow.SetActive(false);
		} else {
			rotateArrow.SetActive(true);
		}
	}
}
