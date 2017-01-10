using UnityEngine;
using System.Collections;
using System.IO;
using Instruction;

public class SetCircle : MonoBehaviour {

	public GameObject[] circles;

	public Sprite circle_clear;
	public Sprite circle_unclear;

	// Use this for initialization
	void Start () {

		int index = 0;
	
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
