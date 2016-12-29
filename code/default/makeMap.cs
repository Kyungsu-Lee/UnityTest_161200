using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;

public class makeMap : MonoBehaviour
{
	public GameObject block;
	public GameObject character;
	Block _block;
	Character _character;

	// Use this for initialization
	void Start ()
	{
		_block = new Block (block.transform);
		_character = new Character (character.transform);

		Map map = new Map (_block, 8, 7);
		map.setPosition (-2.7f, -1.4f);

		_character.connectMap (map);
		_character.locateAt (0, 0);
		_character.locaScale = new Vector3 (map.Unitlength * 0.8f,map.Unitlength * 0.8f, character.transform.localScale.z);

		Resource.instruction.move ().up ().five ();

		_character.fails += failCondition;
		_character.move (Resource.instruction);



	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void failCondition()
	{
		// use for incorrect direction
	}
}

