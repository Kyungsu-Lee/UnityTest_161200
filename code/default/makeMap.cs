using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;
using System.IO;
using System;

public class makeMap : MonoBehaviour
{
	public GameObject block;
	public GameObject[] character;
	public GameObject[] obtacle;
	public GameObject[] accessory;

	public ArrayList unclearedCharacter = new ArrayList ();

	Map map;
	int characterIndex = 0;


	// Use this for initialization
	void Start ()
	{
		loadStage (1);


		Resource.characters = character;
		Resource.character = Character.characters[0] as Character;


	}

	public void loadStage(int stage)
	{
		TextAsset data = Resources.Load ("text" + stage, typeof(TextAsset)) as TextAsset;
		StringReader str = new StringReader (data.text);

		string line;

		while ((line = str.ReadLine ()) != null) {

			if (line.Equals ("size")) {
				line = str.ReadLine ();
				int size = int.Parse (line);

				createMap (size);
			} else if (line.Equals ("character")) {
				int characterNum = int.Parse ((line = str.ReadLine ()));

				for (int i = 0; i < characterNum; i++) {
					line = str.ReadLine ();

					string[] s = line.Split (new char[]{ ' ' });

					createCharacter (int.Parse (s [0]), int.Parse (s [1]));

				}

				characterIndex = 0;
			} else if (line.Equals ("obtacle")) {

				int obtacleNum = int.Parse (line = str.ReadLine ());

				for (int i = 0; i < obtacleNum; i++) {
					line = str.ReadLine ();

					string[] s = line.Split (new char[]{ ' ' });

					createObtacle (int.Parse (s [0]), int.Parse (s [1]));
				}
			} else if (line.Equals ("Map")) {
				for (int i = Map.instance.size - 1; i >= 0; i--) {
					line = str.ReadLine ();
					string[] s = line.Split (new char[]{ ' ' });

					for (int j = 0; j < s.Length; j++) {
						Map.instance.get (j, i).index = int.Parse (s [j]);
					}
				}
			}else if (line.Equals ("accessory")) {
				int accessoryNum = int.Parse ((line = str.ReadLine ()));

				for (int i = 0; i < accessoryNum; i++) {
					line = str.ReadLine ();

					string[] s = line.Split (new char[]{ ' ' });

					createAccessory (int.Parse (s [0]), int.Parse (s [1]));

				}

				characterIndex = 0;
			} 
		}
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		int n = Map.instance.size;

		for (int i = 0; i < character.Length; i++) {
			if (character [i].GetComponent<Transform> ().position == accessory [i].GetComponent<Transform> ().position && Resource.canClear) 
			{
				for (int x = 0; x < n; x++)
					for (int y = 0; y < n; y++)
						if (map.get (x, y).index == i+1)
							map.get (x, y).changColor ();

				character [i].GetComponent<Transform> ().position = new Vector3 (100, 100, 100);
				accessory [i].GetComponent<Transform> ().position = new Vector3 (100, 100, 100);

			}
		}


	}

	private void createMap(int size)
	{
		Block _block = new Block (block.transform);
		Map map = new Map (_block, size, 7);
		map.setPosition (-2.3f, -0.85f);

		this.map = map;
	}

	private void createCharacter(int x, int y)
	{
		Character _character = new Character (character[characterIndex].transform);
		_character.connectMap (map);
		_character.locateAt (x, y);
		_character.locaScale = new Vector3 (map.Unitlength * 0.8f,map.Unitlength * 0.8f, character[0].transform.localScale.z);
		_character.index = (++characterIndex);

		unclearedCharacter.Add (_character);
	}

	public void createObtacle(int x, int y)
	{
		Obtacle _obtacle = new Obtacle (obtacle [0].transform);
		_obtacle = _obtacle.createObtacle ();
		_obtacle.connectMap (map);
		_obtacle.locateAt (x, y);
		_obtacle.locaScale = new Vector3 (map.Unitlength * 0.19f,map.Unitlength * 0.19f, obtacle[0].transform.localScale.z);
	}

	public void createAccessory(int x, int y)
	{
		Accessory _accessory = new Accessory (accessory[characterIndex].transform);
		_accessory.connectMap (map);
		_accessory.locateAt (x, y);
		_accessory.locaScale = new Vector3 (map.Unitlength * 0.5f,map.Unitlength * 0.5f, character[0].transform.localScale.z);
		_accessory.index = (++characterIndex);
	}
}

