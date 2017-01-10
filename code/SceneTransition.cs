using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
	
		this.transform.GetComponent<SpriteRenderer> ().sortingOrder = 100;

		this.transform.GetComponent<Transform> ().position = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if ((time += Time.deltaTime) < 1) {
			float rate = Mathf.Pow (time, 1.2f);
			this.transform.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1 - rate);
		} else {
			this.transform.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
			this.transform.GetComponent<SpriteRenderer> ().sortingOrder = 0;
		}
		
	}
}
