using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class CharacterMove : MonoBehaviour {

	Character character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Resource.character != null) {
			character = Resource.character;


			if (character.Moving && character.characterStatus.action == ObjectHierachy.Action.MOVE) {
		
				if (character.characterStatus.direction == INSTRUCTION.UP)
					character.moveUp ();
				else if (character.characterStatus.direction == INSTRUCTION.DOWN)
					character.moveDown ();
				else if (character.characterStatus.direction == INSTRUCTION.RIGHT)
					character.moveRight ();
				else if (character.characterStatus.direction == INSTRUCTION.LEFT)
					character.moveLeft ();
			}

			if (character.onNext ())
				character.Stop ();
			
			Debug.Log ("crruent : " + character.currentPosition.ToString ());
		}

	}
}
