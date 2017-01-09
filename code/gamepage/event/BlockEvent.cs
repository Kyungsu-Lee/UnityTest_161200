using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;
using UnityEngine.SceneManagement;

public class BlockEvent : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnMouseDown()
	{

		int n = Map.instance.size;

		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				Debug.Log (i + " " + j + " : " +Map.instance.get (i, j).OnObject + " // " + Map.instance.get(i, j).index);
	}

	void OnMouseUp()
	{
		//makeMap.clearEvent ();

		//Resource.clear();
		//Resource.stage = 5;
		//SceneManager.LoadScene ("p2");
	}

}
