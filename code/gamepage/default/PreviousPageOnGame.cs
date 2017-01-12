using UnityEngine;
using System.Collections;
using Instruction;
using UnityEngine.SceneManagement;

public class PreviousPageOnGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		Resource.clear ();
		Resource.stage = (Resource.stage / 100) * 100;
		SceneManager.LoadScene ("p4");
	}
}
