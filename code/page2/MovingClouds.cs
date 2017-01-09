using UnityEngine;
using System.Collections;
using Instruction;
using UnityEngine.SceneManagement;

public class MovingClouds : MonoBehaviour {

	float bounds;
	float speed;
	float startPosition;
	bool flag = true;

	// Use this for initialization
	void Start () {
		startPosition = this.transform.GetComponent<Transform> ().position.x;
		speed = 0.015f;
		bounds = Random.Range(20, 35)/10.0f;
		flag = Random.Range (0, 100) % 2 == 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (flag) {
			this.transform.GetComponent<Transform> ().position = 
				new Vector3 (
				this.transform.GetComponent<Transform> ().position.x + speed,
				this.transform.GetComponent<Transform> ().position.y,
				this.transform.GetComponent<Transform> ().position.z
			);
		} else {
			this.transform.GetComponent<Transform> ().position = 
				new Vector3 (
					this.transform.GetComponent<Transform> ().position.x - speed,
					this.transform.GetComponent<Transform> ().position.y,
					this.transform.GetComponent<Transform> ().position.z
				);
		}

		if (this.transform.GetComponent<Transform> ().position.x >= startPosition + bounds
		   || this.transform.GetComponent<Transform> ().position.x <= startPosition - bounds) 
		{
			flag = !flag;
		}
	}

	void OnMouseDown()
	{
		
	}

	void OnMouseUp()
	{
		
	}
}
