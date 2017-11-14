using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour {

	private SpriteRenderer sprite;
	public double decrement = 0.0000000000001;

	// Use this for initialization
	void Start () {
		sprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Color tempColor = sprite.color;
		if (tempColor.a > 0.001f) {
			tempColor.a -= (float)decrement;
			sprite.color = tempColor;
		} else {
			Destroy (this);
		}
	}
}
