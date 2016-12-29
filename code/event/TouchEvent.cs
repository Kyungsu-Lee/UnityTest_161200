using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TouchEvent : MonoBehaviour {

	bool overCheck = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown()
	{
		Debug.Log ("down");
		overCheck = true;
	}

	public void OnMouseUp()
	{
		Debug.Log ("UP");
		overCheck = false;

	}

	public void OnMouseOver()
	{
		if(overCheck)
			Debug.Log ("over");
	}
}
