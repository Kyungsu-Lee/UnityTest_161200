using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public Sprite[] img;
	int index = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.GetComponent<SpriteRenderer> ().sprite = img [(index++/6) % img.Length];
	}
}
