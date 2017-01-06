using UnityEngine;
using System.Collections;
using ObjectHierachy;

public class BadCharacter : MonoBehaviour {

	public Sprite[] img;
	float i=0; 
	float speed = 7f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		foreach (MapObject b in MapObject.ALLOBJECT)
			if (b.obj != null && b.obj.transform.Equals (this.transform)) 
			{
				if (!(b as ObjectHierachy.BadCharacter).Die) {
					i += Time.deltaTime;
					this.transform.GetComponent<SpriteRenderer> ().sprite = img [(int)Mathf.Floor((i++)/speed)%img.Length];
				}
			}


	}
}
