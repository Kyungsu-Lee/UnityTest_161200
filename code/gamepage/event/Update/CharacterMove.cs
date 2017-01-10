using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class CharacterMove : MonoBehaviour {

	Character character;

	float time = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Resource.character != null) {
			character = Resource.character;


			if (character.Moving) {
				
				if (character.characterStatus.PointQueue.Count > 0 && !Map.instance.checkBound (character.characterStatus.NextPositionPoint)) {
					if ((time += Time.deltaTime) < 1) {
						return;
					} else {
						character.characterStatus.PointQueue.Dequeue ();
						character.Stop ();
						time = 0;
					}
				}
		
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
			
		}

	}
}
