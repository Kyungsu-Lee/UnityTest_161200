using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;
using System.IO;
using System;


public class makeMap : MonoBehaviour
{
	public delegate void Clear();

	public static Clear clearEvent;

	public GameObject block;
	public GameObject mapBackground;
	public GameObject ring;
	public GameObject[] character;
	public GameObject[] obtacle;
	public GameObject[] accessory;
	public GameObject[] colorObject;
	public GameObject[] stars;

	public Sprite[] rubies;

	private Vector3[] startPosition;

	public ArrayList unclearedCharacter;

	Map map;
	int characterIndex = 0;

	private bool initialState = true;


	// Use this for initialization
	public void Start ()
	{

		unclearedCharacter = new ArrayList ();

		if (Resource.Accessories == null) {

			Resource.Accessories = new Sprite[5][];
			for(int i=0; i<5; i++)
				Resource.Accessories[i] = new Sprite[5];

			for (int i = 0; i < 5; i++)
				for (int j = 0; j < 5; j++)
					Resource.Accessories [i] [j] = rubies [5 * i + j];
		}

		if (Resource.stage == 0)
			Resource.stage = 300;

		loadStage (Resource.stage);
		
		Resource.characters = character;
		Resource.character = Character.characters[0] as Character;
		Resource.stars = stars;
		match ();


		/*
		(Character.characters[0] as Character).obj.GetComponent<SpriteRenderer> ().color = new Color ((Character.characters[0] as Character).obj.GetComponent<SpriteRenderer> ().color.r, (Character.characters[0] as Character).obj.GetComponent<SpriteRenderer> ().color.g, (Character.characters[0] as Character).obj.GetComponent<SpriteRenderer> ().color.b);
		(Accessory.accessory[0] as Accessory).obj.GetComponent<SpriteRenderer> ().color = new Color ((Accessory.accessory[0] as Accessory).obj.GetComponent<SpriteRenderer> ().color.r, (Accessory.accessory[0] as Accessory).obj.GetComponent<SpriteRenderer> ().color.g, (Accessory.accessory[0] as Accessory).obj.GetComponent<SpriteRenderer> ().color.b);
	*/


		for (int i = 0; i < colorObject.Length; i++)
			Resource.COLORS.Add (colorObject [i].GetComponent<SpriteRenderer> ().color);

		startPosition = new Vector3[stars.Length];

		for (int i = 0; i < stars.Length; i++)
			startPosition [i] = stars [i].GetComponent<Transform> ().position;

		Resource.starPosition = startPosition;
		Resource.ring = ring;
		Resource.movRuby = new bool[character.Length + 1];

		for (int i = 0; i < stars.Length; i++)
			stars [i].GetComponent<Transform> ().position = new Vector3 (100, 100, 100);

		for (int i = 0; i < character.Length; i++)
			Resource.movRuby [i] = false;

		clearEvent += clear;

		foreach (Character c in Character.characters)
			c.onBlock ().canOn = false;
		
		int n = Map.instance.size;

		string gdb = "";

		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				gdb += i + " " + j + " : " +Map.instance.get (i, j).OnObject + " // " + Map.instance.get(i, j).index + "\n";

		Debug.Log (gdb);
	}

	public void loadStage(int stage)
	{
		//Character.characters.Clear ();

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

					createObtacle (int.Parse (s [0]), int.Parse (s [1]), s[2]);
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

					createAccessory (int.Parse (s [0]), int.Parse (s [1]), int.Parse(s[2]));

				}

				characterIndex = 0;
			} 
		}

	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (initialState) {
			if (Resource.character != null)
			activate (Resource.character);
			initialState = false;
		}

	}

	private void createMap(int size)
	{
		Block _block = new Block (block.transform);
		Map map = new Map (_block, size, mapBackground.GetComponent<Transform>().localScale.x, 0.01f);
		map.setPositionAtCenter(0,0);

		this.map = map;
	}

	private void createCharacter(int x, int y)
	{
		Character _character = new Character (character[characterIndex].transform);
		_character.connectMap (map);
		_character.locateAt (x, y);
		_character.locaScale = new Vector3 (map.Unitlength * 0.258f,map.Unitlength * 0.258f, character[0].transform.localScale.z);
		_character.index = (++characterIndex);
		_character.StartPoint = new Point (x, y);

		float alpha = 1f;
		_character.obj.GetComponent<SpriteRenderer> ().color = new Color (_character.obj.GetComponent<SpriteRenderer> ().color.r, _character.obj.GetComponent<SpriteRenderer> ().color.g, _character.obj.GetComponent<SpriteRenderer> ().color.b, alpha);
	}

	public void createObtacle(int x, int y, string s)
	{
		Obtacle _obtacle = new UnMovableObtacle(obtacle[0].transform, ObtacleKind.NULL);

		if (s.Equals ("f")) {
			_obtacle = new UnMovableObtacle (obtacle [0].transform, ObtacleKind.FIRE);
		} else if (s.Equals ("w")) {
			_obtacle = new UnMovableObtacle (obtacle [1].transform, ObtacleKind.WATER);
			_obtacle.obtacleKind = ObtacleKind.WATER;
		} else if (s.Equals ("r")) {
			_obtacle = new UnMovableObtacle (obtacle [2].transform, ObtacleKind.ROCK);
			_obtacle.obtacleKind = ObtacleKind.ROCK;
		} else {
			_obtacle = new ObjectHierachy.BadCharacter (obtacle [3].transform);
			_obtacle.obtacleKind = ObtacleKind.BAD;
		}

		_obtacle = _obtacle.createObtacle ();
		_obtacle.StartPoint = new Point (x, y);
		_obtacle.connectMap (map);
		_obtacle.locateAt (x, y);
		_obtacle.locaScale = new Vector3 (map.Unitlength * 0.19f,map.Unitlength * 0.19f, obtacle[0].transform.localScale.z);
	}

	public void createAccessory(int x, int y, int idx)
	{
		Accessory _accessory = new Accessory (accessory[characterIndex].transform);
		_accessory.connectMap (map);
		_accessory.locateAt (x, y);
		_accessory.locaScale = new Vector3 (map.Unitlength * 0.15f,map.Unitlength * 0.15f, character[0].transform.localScale.z);
		_accessory.index = (++characterIndex);
		_accessory.StartPoint = new Point (x, y);

		float alpha = 1f;
		_accessory.obj.GetComponent<SpriteRenderer> ().color = new Color (_accessory.obj.GetComponent<SpriteRenderer> ().color.r, _accessory.obj.GetComponent<SpriteRenderer> ().color.g, _accessory.obj.GetComponent<SpriteRenderer> ().color.b, alpha);

		_accessory.obj.GetComponent<SpriteRenderer>().sprite = Resource.Accessories[_accessory.index-1][idx];
	}

	public void match()
	{
		for (int i = 0; i < Character.characters.Count; i++) {
			(Character.characters [i] as Character).Match = (Accessory.accessory [i] as Accessory);
			(Accessory.accessory [i] as Accessory).Match = (Character.characters [i] as Character);
		}
	}

	public void activate(Character c)
	{
		Resource.character = c;
		//Debug.Log (c.ToString ());
		c.onBlock ().changeColor (c.Color);
	}

	void OnMouseUp()
	{
		clear ();
	}

	public void clear()
	{
		Map.instance.blockAction += blockAction;
		Map.instance.allBlockAction ();
		Map.instance.blockAction -= blockAction;

		foreach (MapObject o in MapObject.ALLOBJECT)
			o.toStartPoint ();

		foreach (Character c in Character.characters)
			c.Cleared = false;

		foreach (Accessory a in Accessory.accessory)
			a.obj.GetComponent<Transform> ().localScale = new Vector3 (a.initScale.x, a.initScale.y, a.initScale.z);

		activate (Character.characters [0] as Character);

		Resource.canClear = true;
	}

	public void blockAction(Block block)
	{
		block.changeColor (Color.white);
		block.canOn = true;
	}
}

