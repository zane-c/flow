using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Source : MonoBehaviour {

	public GameObject ballObject;
	public Button playBtn;
	private bool isPlaying = false;

	void Start () {
		playBtn.onClick.AddListener(() => {
			isPlaying = !isPlaying;
			if (isPlaying) {
				StartCoroutine(DropBall());
			} else {
				StopCoroutine(DropBall());
			}
		});
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
}
