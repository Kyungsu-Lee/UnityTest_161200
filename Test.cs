using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (time < 30)
			time += Time.deltaTime;

		
		this.transform.GetComponent<Camera> ().orthographicSize = time;
	}
}
