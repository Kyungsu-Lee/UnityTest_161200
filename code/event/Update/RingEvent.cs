using UnityEngine;
using System.Collections;
using ObjectHierachy;

public class RingEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		foreach (Character c in Character.characters)
			if (c == null)
				Debug.Log ("a");

		float rate = Character.clearedCharacter / (float)(Character.Count);

		if (rate == 1) {
			Application.Quit ();
			}
	}
}
