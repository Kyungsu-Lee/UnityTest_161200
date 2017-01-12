using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class Hint : MonoBehaviour {

	float time = 0;
	bool flag  = false;

	ArrayList blocks;

	// Use this for initialization
	void Start () {
		blocks = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{
		Map.instance.blockAction += hint;
		Map.instance.allBlockAction ();
		Map.instance.blockAction -= hint;
	}

	void hint(Block block)
	{
		if (block.index == Resource.character.index && block.color.Equals(new Color(1,1,1,1))) {
			changeColorCharacter (block, Resource.character);
		}

		Invoke ("changColorWhite", 0.5f);
	}

	void changColorWhite()
	{
		foreach(Block block in blocks)
			block.changeColor (new Color (1, 1, 1, 1));

		blocks.Clear ();
	}

	void changeColorCharacter(Block block, Character character)
	{
		blocks.Add (block);
		block.changeColor (character.Color);
	}
}
