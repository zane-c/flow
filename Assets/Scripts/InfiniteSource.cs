using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSource : MonoBehaviour {

	public GameObject ballObject;

	void Start () {
		StartCoroutine(DropBall());
	}

	IEnumerator DropBall() {
		while(true)
		{
			GameObject createdBall = Instantiate(ballObject);
			createdBall.transform.position = transform.position;
			createdBall.GetComponent<DemoBall>().init(new Vector2(0, -1));
			yield return new WaitForSeconds(1);
		}
	}
}