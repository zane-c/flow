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
			title.text = "Level Complete";
			next.gameObject.SetActive (true);
			restart.gameObject.SetActive (false);

		} else {
			title.text = "Level Failed";
			next.gameObject.SetActive (false);
			restart.gameObject.SetActive (true);
		}

		ballText.text = scoredBalls + " / " + totalBalls;
		stageText.text = stage + " / 4";
		dialogue.SetActive (true);
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
		print("Ball Died");
		deadBalls += 1;
		activeBalls -= 1;
	}
	public void ballScored() {
		print("Ball Scored");
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
			print(activeBalls + " - " + reserveBalls + " - " + deadBalls + " - " + scoredBalls + " - " + totalBalls);
		});
	}
}
