using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class CharacterInObtacles : MonoBehaviour {

	Character character;
	Vector3 localscale;

	float time = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		character = Resource.character;

		if (character.obtacles == ObtacleKind.BAD) {

			if ((time += Time.deltaTime) < 0.5f) {
				
				this.character.obj.GetComponent<Transform> ().localScale = 
					new Vector3 (
					localscale.x * (1 - 2 * time),
					localscale.y * (1 - 2 * time),
					localscale.z
				);

				this.character.obj.GetComponent<Transform> ().Rotate (new Vector3 (360 * 2 * time, 0));
				
			} else if (time >= 0.5f) {
				character.resetAction ();
				this.character.obj.GetComponent<Transform> ().localScale = new Vector3 (localscale.x, localscale.y, localscale.z);
				this.character.obj.GetComponent<Transform> ().localRotation = new Quaternion (0, 0, 0, 0);
				time = 0;
			}


		} else if (character.obtacles == ObtacleKind.FIRE) {
			if ((time += Time.deltaTime) < 0.5f) {
				this.character.obj.GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0, 1 - 2 * time);
			} else {
				character.resetAction ();
				this.character.obj.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
				time = 0;
			}
		}else if (character.obtacles == ObtacleKind.WATER) {
			if ((time += Time.deltaTime) < 0.5f) {
				this.character.obj.GetComponent<SpriteRenderer> ().color = new Color (67/255.0f, 218/255.0f, 236/255.0f, 1 - 2 * time);
			} else {
				character.resetAction ();
				this.character.obj.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
				time = 0;
			}
		}else if (character.obtacles == ObtacleKind.ROCK) {
			if ((time += Time.deltaTime) < 0.5f) {
				this.character.obj.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1 - 2 * time);
			} else {
				character.resetAction ();
				this.character.obj.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
				time = 0;
			}
		}
		else
		{
			localscale = this.character.obj.GetComponent<Transform> ().localScale;
		}
	}
}
