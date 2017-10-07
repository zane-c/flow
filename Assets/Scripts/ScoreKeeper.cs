using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	private int deadBalls = 0;
	private int activeBalls = 10;
	private int scoredBalls = 0;

	void Start () {
	}

	void Update () {
		if (activeBalls == 0) {
			print("Game over");
		}
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
}
