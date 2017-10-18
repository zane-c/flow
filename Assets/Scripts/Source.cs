using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Source : MonoBehaviour {


	public GameObject ballObject;

	public Button StartButton;

	public bool start = false;

	// Use this for initialization
	void Start () {
		// Button startComp = StartButton.GetComponent<Button>();
		StartCoroutine (DropBall ());
		// startComp.onClick.AddListener(StartPauseGame);
	}

	void StartPauseGame() {
		if (!start) {
			StartCoroutine (DropBall ());
			StartButton.GetComponentInChildren<Text>().text = "STOP";
			start = true;
		} else {
			StopAllCoroutines ();
			StartButton.GetComponentInChildren<Text>().text = "START";
			start = false;
		}
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
