using UnityEngine;
using System.Collections;
using System.IO;
using Instruction;

public class Base : MonoBehaviour {

	public Sprite sprite;

	// Use this for initialization
	void Start () {

		Resource.deadCharacter = sprite;

		Screen.SetResolution (Screen.width ,  (int)(Screen.width * 4.0 /3) , true);

		//this.transform.GetComponent<Transform> ().position = new Vector3 (this.transform.GetComponent<Transform> ().position.x, this.transform.GetComponent<Transform> ().position.y, this.transform.GetComponent<Transform> ().position.z * 2f);
		/*
		TextAsset data = Resources.Load ("text", typeof(TextAsset)) as TextAsset;
		StringReader str = new StringReader (data.text);

		string line;

		while ((line = str.ReadLine ()) != null) {

			line.Trim ();

			int index = line.IndexOf ("//");

			if(index >= 0)
			line = line.Substring (0, index);

			if(line != "" )
			Debug.Log (line);
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
