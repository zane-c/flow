using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

	private SpriteRenderer sprite;
	private float timer = 0.2f;
	private float opacity = 0.1f;

	void Start () {
		sprite = gameObject.GetComponent<SpriteRenderer>();
		sprite.color = new Vector4(255, 255, 255, opacity);
	}

	void Update () {
		timer -= Time.deltaTime;
		if (transform.localScale.x > 0) {
			transform.localScale -= new Vector3 (0.018f, 0.018f, 0);
		}
		if (timer <= 0) {
			Destroy(gameObject);
		}
	}
}
