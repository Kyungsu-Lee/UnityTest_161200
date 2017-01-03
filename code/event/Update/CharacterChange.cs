using UnityEngine;
using System.Collections;
using ObjectHierachy;

public class CharacterChange : MonoBehaviour {

	public Sprite[] img;
	float i = 0;
	float speed = 7f;
	float length = 0.1f;

	bool mov=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		foreach(Character c in Character.characters)
			if(c.obj.transform.Equals(this.transform) && c.Mov)
				this.transform.GetComponent<SpriteRenderer> ().sprite = img [(int)Mathf.Floor((i++)/speed)%img.Length];

		if (this.transform.GetComponent<Transform> ().position.x > 1.5f || this.transform.GetComponent<Transform> ().position.x < -1.5f)
			mov = !mov;

		//mov = true;
		/*
		if (mov)
			this.transform.GetComponent<Transform> ().position = new Vector3 (this.transform.GetComponent<Transform>().position.x + length, this.transform.GetComponent<Transform>().position.y, this.transform.GetComponent<Transform>().position.z);
		else
			this.transform.GetComponent<Transform> ().position = new Vector3 (this.transform.GetComponent<Transform>().position.x - length, this.transform.GetComponent<Transform>().position.y, this.transform.GetComponent<Transform>().position.z);
		
		float x = this.transform.GetComponent<Transform> ().position.x;

		this.transform.GetComponent<Transform> ().position = new Vector3 (this.transform.GetComponent<Transform> ().position.x, Mathf.Abs(1.0f * (x-1.5f)*(x)*(x+1.5f)) , this.transform.GetComponent<Transform> ().position.z);
	*/
	}
}