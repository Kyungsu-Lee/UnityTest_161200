using UnityEngine;
using System.Collections;

public class BadCharacter : MonoBehaviour {

	public Sprite[] img;
	float i=0; 
	float speed = 7f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		i += Time.deltaTime;
		this.transform.GetComponent<SpriteRenderer> ().sprite = img [(int)Mathf.Floor((i++)/speed)%img.Length];
	}
}
