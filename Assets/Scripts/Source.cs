using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour {


	public GameObject ballObject;


	// Use this for initialization
	void Start () {
		StartCoroutine(DropBall());
	}

	IEnumerator DropBall() {
		while(true)
		{
			GameObject createdBall = Instantiate(ballObject);
			createdBall.transform.position = transform.position;
			createdBall.GetComponent<Ball>().init(new Vector2(0, -1));
			yield return new WaitForSeconds(1);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
