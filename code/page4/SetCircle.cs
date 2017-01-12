using UnityEngine;
using System.Collections;
using System.IO;
using Instruction;
using FileHelper;
using UnityEngine.SceneManagement;

public class SetCircle : MonoBehaviour {

	public GameObject[] circles;

	public Sprite circle_clear;
	public Sprite circle_unclear;

	public static bool[] isclear;

	// Use this for initialization
	void Start () {
		int index = 0;
		/*
		TextAsset data = Resources.Load ("stage" + Resource.stage, typeof(TextAsset)) as TextAsset;
		StringReader str = new StringReader (data.text);

		string line;

		while ((line = str.ReadLine ()) != null) {

			if (line.Equals ("0")) {
				circles [(index)++].transform.GetComponent<SpriteRenderer> ().sprite = circle_unclear;
			} else if (line.Equals ("1")) {
				circles [(index)++].transform.GetComponent<SpriteRenderer> ().sprite = circle_clear;
			}
		}
		*/

		isclear = new bool[12];

		string str = FileStreamHelper.readStringFromFile ("stage" + Resource.stage + ".txt");

		if (str == null) {
			FileStreamHelper.writeStringToFile ("0,0,0,0,0,0,0,0,0,0,0,0", "stage" + Resource.stage + ".txt");
			str = FileStreamHelper.readStringFromFile ("stage" + Resource.stage + ".txt");
		}

		string[] stage = str.Split (new char[]{ ',' });

		string deb = "";

		foreach (string s in stage) {
			if (s != null && s != "") {
				if (!(isclear[index] = !s.Equals ("0")))
					circles [(index)++].transform.GetComponent<SpriteRenderer> ().sprite = circle_unclear;
				else
					circles [(index)++].transform.GetComponent<SpriteRenderer> ().sprite = circle_clear;

				deb += s;
			}
		}
	
		Debug.Log (deb);

	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnMouseUp()
	{
		
	}
}
