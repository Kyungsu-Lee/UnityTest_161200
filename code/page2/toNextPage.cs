using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Instruction;

public class toNextPage : MonoBehaviour {

	// clicked 		: 1
	// unclicked 	: 2
	public Sprite[] img;

	public GameObject screen;
	public GameObject[] objects;

	bool page = false;
	float time;


	// Use this for initialization
	void Start () {
		page = false;
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (page) {

			time += Time.deltaTime;

			screen.GetComponent<SpriteRenderer> ().sortingOrder = 10;

			float rate = Mathf.Pow (time, 0.7f);

			if (time <= 0.8f) {
				screen.transform.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, rate);
				foreach (GameObject o in objects) {
					Vector3 position = o.transform.GetComponent<Transform> ().position;
					//o.transform.GetComponent<Transform> ().position = new Vector3 (position.x, position.y - 3 * rate, position.z);
					o.transform.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1 - rate);
				}
			} else {
				Resource.previousScene = "p2";
				SceneManager.LoadScene ("p3");	
			}
		}
	}

	void OnMouseDown()
	{
		this.transform.GetComponent<SpriteRenderer> ().sprite = img [1];
	}

	void OnMouseUp()
	{
		this.transform.GetComponent<SpriteRenderer> ().sprite = img [0];
		page = true;

	}
}
