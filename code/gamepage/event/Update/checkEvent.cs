using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;

public class checkEvent : MonoBehaviour {

	public GameObject Squre;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//pathErrorcheck ();
	}


	void pathErrorcheck()
	{
		int n = Map.instance.size;

		Resource.canClear = true;

		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				if(Map.instance.get(i,j).OnObject != null && Map.instance.get(i,j).OnObject is Character)
					Resource.canClear &= (Map.instance.get (i, j).OnObject.index == Map.instance.get (i, j).index);
		
		for (int i = 0; i < Character.characters.Count; i++)
			foreach (Point p in (Character.characters[i] as Character).pointStack)
				Resource.canClear &= (Map.instance.get (p.x, p.y).index == (Character.characters [i] as Character).index);
		
		/*
		if (Resource.canClear)
			Squre.GetComponent<SpriteRenderer> ().color = Color.white;
		else
			Squre.GetComponent<SpriteRenderer> ().color = new Color (1f, 0f, 0f, 0.2f);
			*/

	}
}
