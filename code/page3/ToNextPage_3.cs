using UnityEngine;
using System.Collections;
using Instruction;
using UnityEngine.SceneManagement;

public class ToNextPage_3 : MonoBehaviour {

	int index;

	// Use this for initialization
	void Start () {
		Resource.stage = 0;



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		for(int i=3; i<7; i++)
			if(this.transform.Equals(GameObject.Find("stage_" + i).transform))
				Resource.stage += i * 100;

		Resource.previousScene = "p3";
		SceneManager.LoadScene ("p4");	
	}
}
