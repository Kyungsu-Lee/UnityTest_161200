using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;

public class makeMap : MonoBehaviour
{
	public GameObject block;
	public GameObject[] character;

	Block _block;

	Character _character;
	Character _character2;

	// Use this for initialization
	void Start ()
	{
		_block = new Block (block.transform);
		_character = new Character (character[0].transform);
		_character2 = new Character (character[1].transform);


		Map map = new Map (_block, 5, 7);
		map.setPosition (-2.3f, -0.85f);

		_character.connectMap (map);
		_character.locateAt (0, 0);
		_character.locaScale = new Vector3 (map.Unitlength * 0.8f,map.Unitlength * 0.8f, character[0].transform.localScale.z);


		_character2.connectMap (map);
		_character2.locateAt (2, 2);
		_character2.locaScale = new Vector3 (map.Unitlength * 0.8f,map.Unitlength * 0.8f, character[1].transform.localScale.z);


		Resource.character = _character;
		Resource.characters = character;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

}

