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

	public void OnMouseOver()
	{
		((Character)Character.characters [0]).move (block);
	}

}
