using UnityEngine;
using System.Collections;
using Instruction;
using UnityEngine.SceneManagement;

public class toHomeGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		Resource.clear ();
		SceneManager.LoadScene ("p2");
	}
}
