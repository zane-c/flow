using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resize : MonoBehaviour {

	GridLayoutGroup grid;
	int height;
	int width;
	public float hRatio;
	public float wRatio;
	public Vector2 _cellSize;
	public Vector2 _spacing;

	// Use this for initialization
	void Start () {
		grid = GetComponent<GridLayoutGroup>();
		height = Screen.height;
		width = Screen.width;
		if (grid != null)
		{
			grid.padding.left = Mathf.RoundToInt(width * wRatio);
			grid.padding.top = Mathf.RoundToInt(height * hRatio);
			grid.cellSize = new Vector2(Mathf.RoundToInt(_cellSize.x * width), Mathf.RoundToInt(_cellSize.y * height));
			grid.spacing = new Vector2(Mathf.RoundToInt(_spacing.x * width), Mathf.RoundToInt(_spacing.y * height));
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
