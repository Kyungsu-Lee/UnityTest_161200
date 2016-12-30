using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;

public class makeMap : MonoBehaviour
{
	public GameObject block;
	public GameObject[] character;
	public GameObject[] obtacle;

	Block _block;

	Character _character;
	Character _character2;

	Obtacle _obtacle;
	Obtacle _obtacle2;


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

		_obtacle = new Obtacle (obtacle [0].transform);
		_obtacle.connectMap (map);
		_obtacle.locateAt (3, 4);
		_obtacle.locaScale = new Vector3 (map.Unitlength * 0.19f,map.Unitlength * 0.19f, obtacle[0].transform.localScale.z);

		_obtacle2 = new Obtacle (obtacle [1].transform);
		_obtacle2.connectMap (map);
		_obtacle2.locateAt (2, 0);
		_obtacle2.locaScale = new Vector3 (map.Unitlength * 0.19f,map.Unitlength * 0.19f, obtacle[1].transform.localScale.z);

		Resource.character = _character;
		Resource.characters = character;

		Instruction.Instruction result = new Instructions ().move ().up ();

		Debug.Log (result.checkValid ());

		

	

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

}

