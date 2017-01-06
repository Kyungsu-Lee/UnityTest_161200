using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Instruction;

public class toNextPage : MonoBehaviour {

	// clicked 		: 1
	// unclicked 	: 2
	public Sprite[] img;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		this.transform.GetComponent<SpriteRenderer> ().sprite = img [1];
	}

	void OnMouseUp()
	{
		this.transform.GetComponent<SpriteRenderer> ().sprite = img [0];
		SceneManager.LoadScene ("p3");
	}
}
