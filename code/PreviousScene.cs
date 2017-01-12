using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Instruction;

public class PreviousScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		SceneManager.LoadScene ("p3");
	}
}
