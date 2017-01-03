using UnityEngine;
using System.Collections;
using ObjectHierachy;

public class RingEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float rate = Character.clearedCharacter / (float)(Character.Count);
		Debug.Log(rate.ToString("0.00"));
		this.transform.GetComponent<SpriteRenderer> ().color = new Color (rate, rate, rate, 1);
	}
}
