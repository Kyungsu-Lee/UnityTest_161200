using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;

public class CharacterImgChange : MonoBehaviour {

	public Sprite[] img;
	float i = 0;
	float speed = 7f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		foreach(Character c in Character.characters)
			if(c.obj != null && c.obj.transform.Equals(this.transform) && c.Moving 
				|| (CharacterErrorEvent.error_mov && c.obj.transform.Equals(this.transform) && CharacterErrorEvent.index == c.index)
			)
				this.transform.GetComponent<SpriteRenderer> ().sprite = img [(int)Mathf.Floor((i++)/speed)%img.Length];
		
	}
}