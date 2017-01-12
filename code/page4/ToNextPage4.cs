using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Instruction;


public class ToNextPage4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnMouseUp()
	{
		int idx = 0;

		for (int i = 0; i < 12; i++)
			if (this.transform.Equals (GameObject.Find ("stage_circle_" + i).transform))
				idx = i;

		//if (idx == 0 || SetCircle.isclear [idx] || SetCircle.isclear [idx - 1])
		{
			for (int i = 0; i < 12; i++)
				if (this.transform.Equals (GameObject.Find ("stage_circle_" + i).transform))
					Resource.stage += i;

			Resource.previousScene = "p4";

			SceneManager.LoadScene ("Main");
		}
	}
}
