using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;
using UnityEngine.SceneManagement;

public class RingEvent : MonoBehaviour {

	float time = 0;
	public Sprite[] img;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		foreach (Character c in Character.characters)
			if (c == null)
				Debug.Log ("a");

		float rate = Character.clearedCharacter / (float)(Character.Count);

		if (rate == 1) {
			if (time < 3)
				time += Time.deltaTime;
			else {
				time = 0;
				this.transform.GetComponent<SpriteRenderer> ().sprite = img [Resource.stage];
			}
			}
	}

	void OnMouseUp()
	{
	}
}
