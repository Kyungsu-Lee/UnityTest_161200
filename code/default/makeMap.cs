using UnityEngine;
using System.Collections;
using ObjectHierachy;

public class makeMap : MonoBehaviour
{
	public GameObject block;
	public GameObject character;

	// Use this for initialization
	void Start ()
	{
		Block _block = new Block (block.transform);
		Character _character = new Character (character.transform);

		Map map = new Map (_block, 4, 7);
		map.setPosition (-2.7f, -1.4f);

		_character.position = map.get (0, 0).getposition ();
		_character.locaScale = new Vector3 (map.Unitlength * 0.8f,map.Unitlength * 0.8f, character.transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

