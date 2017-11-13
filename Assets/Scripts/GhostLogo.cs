using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLogo : MonoBehaviour {

	// private SpriteRenderer sprite;
	private float timer = 0.2f;
	// private float opacity = 0.1f;

	void Start () {
		// sprite = gameObject.GetComponent<SpriteRenderer>();
		// sprite.color = new Vector4(255, 178, 140, opacity);
	}

	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Destroy(gameObject);
		}
	}
}
