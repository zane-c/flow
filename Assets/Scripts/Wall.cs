using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	private ScoreKeeper keeperScript;
	private GameObject rotateArrow;
	private SpriteRenderer sr;

	public bool disabledOnStart = false;
	private bool isPlaceable = true;

	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
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

	public void setPlaceable(bool isPlaceable) {
		this.isPlaceable = isPlaceable;
		if (!isPlaceable) {
			sr.color = new Color (255.0f, 0.0f, 0.0f, 0.3f);
		} else {
			sr.color = new Color (255, 255, 255, 1);
		}
	}

	public bool getPlaceable() {
		return isPlaceable;
	}
}
