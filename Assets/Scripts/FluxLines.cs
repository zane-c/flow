﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxLines : MonoBehaviour {

	private float lifespan = 2.0f;

	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		if (transform.localScale.x > 0) {
			transform.localScale -= new Vector3 (0.009f, 0.0009f, 0);
		}
		if (lifespan < 0)
			Destroy (gameObject);
	}
}
