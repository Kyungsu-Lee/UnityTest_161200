﻿using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class CharacterJump : MonoBehaviour {

	float time = 0;
	float due_time = 0.65f;
	float scaleRate = 1.2f;

	float x, y;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Resource.character.Jump) {


			if (time < due_time) {
				time += Time.deltaTime;
				Resource.character.obj.GetComponent<Transform> ().localScale = 
					new Vector3 (
					x * ((4 * (1 - scaleRate) / (due_time * due_time)) * time * (time - due_time) + 1),
					y * ((4 * (1 - scaleRate) / (due_time * due_time)) * time * (time - due_time) + 1),
					Resource.character.obj.GetComponent<Transform> ().localScale.z
				);
			} else {
				Resource.character.Jump = false;
				time = 0;
			}

			int n = Map.instance.size;

			for(int i=0; i<n; i++)
				for(int j=0; j<n; j++)
					if(!Resource.character.checkDistance(Map.instance.get(i,j) , Map.instance.unitSize/10))
						Map.instance.get(i,j).changeColor(Resource.character.color);

		} else {
			x = Resource.character.obj.GetComponent<Transform> ().localScale.x;
			y = Resource.character.obj.GetComponent<Transform> ().localScale.y;
		}
*/
	}
}