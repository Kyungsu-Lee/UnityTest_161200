using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		SceneManager.LoadScene ("p2");
	}
}
