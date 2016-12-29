using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;

public class CharacterTouchEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseUp()
	{

		for (int i = 0; i < Resource.characters.Length; i++) {
			if ( ((UnityEngine.GameObject)Resource.characters[i]).transform.Equals(this.transform)  )
			{
				Resource.character = ((Character)Character.characters [i]);
				break;
			}
		}

	}
}
