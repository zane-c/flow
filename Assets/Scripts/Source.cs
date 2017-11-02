using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Source : MonoBehaviour {

	public GameObject b0;
	public GameObject b1;
	public GameObject b2;
	public GameObject b3;
	public GameObject b4;
	public GameObject b5;
	public GameObject b6;
	public GameObject b7;
	public GameObject b8;
	public GameObject b9;

	private Stack<GameObject> stack = new Stack<GameObject>();
	private ScoreKeeper god;

	void Start () {
		stack.Push (b0);
		stack.Push (b1);
		stack.Push (b2);
		stack.Push (b3);
		stack.Push (b4);
		stack.Push (b5);
		stack.Push (b6);
		stack.Push (b7);
		stack.Push (b8);
		stack.Push (b9);

		Button playBtn = GameObject.Find ("DropBall").GetComponent<Button>();
		playBtn.onClick.AddListener(() => {
			ReleaseBall();
		});

		god = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
		god.addReserveBalls (10);
	}

	void ReleaseBall() {
		if (stack.Count != 0) {
			GameObject ball = stack.Pop();
			ball.GetComponent<Rigidbody2D> ().gravityScale = 1;
			ball.GetComponent<CircleCollider2D> ().enabled = true;
		}
	}
}
