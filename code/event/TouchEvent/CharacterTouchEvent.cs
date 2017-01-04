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
		float alpha = 1f;

		foreach (Character _character in Character.characters) {
			_character.obj.GetComponent<SpriteRenderer> ().color = new Color (_character.obj.GetComponent<SpriteRenderer> ().color.r, _character.obj.GetComponent<SpriteRenderer> ().color.g, _character.obj.GetComponent<SpriteRenderer> ().color.b, alpha);
			Accessory _accessory = _character.Match;
			_accessory.obj.GetComponent<SpriteRenderer> ().color = new Color (_accessory.obj.GetComponent<SpriteRenderer> ().color.r, _accessory.obj.GetComponent<SpriteRenderer> ().color.g, _accessory.obj.GetComponent<SpriteRenderer> ().color.b, alpha);
		}
		for (int i = 0; i < Resource.characters.Length; i++) {
			if ( ((UnityEngine.GameObject)Resource.characters[i]).transform.Equals(this.transform)  )
			{
				Resource.character = ((Character)Character.characters [i]);
				Character c = Resource.character as Character;
				Debug.Log (Resource.character.index);
				c.obj.GetComponent<SpriteRenderer> ().color = new Color (c.obj.GetComponent<SpriteRenderer> ().color.r, c.obj.GetComponent<SpriteRenderer> ().color.g, c.obj.GetComponent<SpriteRenderer> ().color.b);
				c.Match.obj.GetComponent<SpriteRenderer> ().color = new Color (c.Match.obj.GetComponent<SpriteRenderer> ().color.r, c.Match.obj.GetComponent<SpriteRenderer> ().color.g, c.Match.obj.GetComponent<SpriteRenderer> ().color.b);
				break;
			}
		}


	}
}
