using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class Create : MonoBehaviour, IPointerDownHandler // required interface when using the OnPointerDown method.
{

	public GameObject gizmo;
	public int count;
	public Text countTxt;
	RectTransform m_RectTransform;

	void Start () {
		Text component = countTxt.GetComponent<Text> ();
		component.text = "x" + count;
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		m_RectTransform = GetComponent<RectTransform>();

		Text component = countTxt.GetComponent<Text> ();
		string numStr = component.text.Substring (1, component.text.Length - 1);
		int numRemaining = int.Parse(numStr);

		if (numRemaining > 0) {
			GameObject createdConveyer = Instantiate (gizmo);
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 newPosition = new Vector3(mousePosition.x, mousePosition.y, m_RectTransform.position.z);
			createdConveyer.transform.position = newPosition;
			RaycastHit2D hit2d = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			numRemaining--;
			component.text = "x" + numRemaining;
		}
	}

	public void Increment() {
		Text component = countTxt.GetComponent<Text> ();
		string numStr = component.text.Substring (1, component.text.Length - 1);
		int numRemaining = int.Parse(numStr);

		numRemaining++;
		Debug.Log (numRemaining);
		component.text = "x" + numRemaining;
	}

}
