using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class BtnClear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		for (int i = Character.characters.Count - 1; i >= 0; i--) {
			Map.instance.blockAction += clean;
			Map.instance.allBlockAction ();
			Map.instance.blockAction -= clean;
			(Character.characters [i] as Character).toStartPoint ();
		}
	}

	private void clean(Block block)
	{
		block.changeColor(new Color(1,1,1,1));
	}
}
