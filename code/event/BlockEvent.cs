using UnityEngine;
using System.Collections;
using ObjectHierachy;

public class BlockEvent : MonoBehaviour {

	Block block;


	// Use this for initialization
	void Start () {
		
		block = new Block (this.transform);


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

}
