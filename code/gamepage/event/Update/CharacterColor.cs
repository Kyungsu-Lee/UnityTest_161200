using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class CharacterColor : MonoBehaviour {

	Character thisCharacter;

	// Use this for initialization
	void Start () {
	
		foreach (Character c in Character.characters)
			if (c.obj.transform.Equals (this.transform))
				thisCharacter = c;
	}
	
	// Update is called once per frame
	void Update () {

		if (thisCharacter.Break) {
			thisCharacter.Jump = true;
			thisCharacter.Break = false;

		}
	}
}
