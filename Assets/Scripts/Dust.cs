using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour {

	private float lifespan = 2.5f;
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		if (lifespan < 0)
			Destroy (gameObject);
	}
}
