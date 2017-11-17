using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private int totalBalls = 0;
	private int numberOfSources;
	private int deadBalls = 0;
	private int reserveBalls = 0;
	private int activeBalls = 0;
	private int scoredBalls = 0;
	public GameObject dialogue;
	private bool isGameOver = false;
	private int stage = 1;

	void Start () {
	}

	void Update () {
		if (totalBalls <= (deadBalls + scoredBalls) && !isGameOver) {
			gameOver ();
		}
	}

	private void gameOver() {
		isGameOver = true;
		Text title = dialogue.transform.GetChild (0).GetComponent<Text> ();
		Transform restart = dialogue.transform.GetChild (3);
		Transform next = dialogue.transform.GetChild (4);

		Text ballText = dialogue.transform.GetChild (1).GetComponentInChildren<Text> ();
		Text stageText = dialogue.transform.GetChild (2).GetComponentInChildren<Text> ();

		if (scoredBalls > 0) {
			title.text = "Stage Complete";
			next.gameObject.SetActive (true);
			restart.gameObject.SetActive (false);

		} else {
			title.text = "Stage Failed";
			next.gameObject.SetActive (false);
			restart.gameObject.SetActive (true);
		}

		ballText.text = scoredBalls + " / " + totalBalls;
		stageText.text = stage + " / 4";
		dialogue.SetActive (true);
	}

	public void nextStage(int balls) {
		totalBalls = balls;
		deadBalls = 0;
		reserveBalls = balls;
		activeBalls = 0;
		scoredBalls = 0;
		isGameOver = false;
		stage++;
	}


	public int getDeadBalls() {
		return deadBalls;
	}
	public int getActiveBalls() {
		return activeBalls;
	}
	public int getScoredBalls() {
		return scoredBalls;
	}
	public void ballDied() {
		deadBalls += 1;
		activeBalls -= 1;
	}
	public void ballScored() {
		scoredBalls += 1;
		activeBalls -= 1;
	}
	public void addReserveBalls(int toAdd) {
		totalBalls += toAdd;
		reserveBalls += toAdd;
		numberOfSources += 1;
		Button playBtn = GameObject.Find ("DropBall").GetComponent<Button>();
		playBtn.onClick.AddListener(() => {
			if (reserveBalls > 0) {
				activeBalls += 1;
				reserveBalls -= 1;
			}
			// print(activeBalls + " - " + reserveBalls + " - " + deadBalls + " - " + scoredBalls + " - " + totalBalls);
		});
	}
}
