using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Source : MonoBehaviour {

	public GameObject ballObject;
	private bool isPlaying = false;

	void Start () {
		Button playBtn = GameObject.Find ("Play").GetComponent<Button>();
		playBtn.onClick.AddListener(() => {
			isPlaying = !isPlaying;
			if (isPlaying) {
				StartCoroutine(DropBall());
			} else {
				StopAllCoroutines();
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
