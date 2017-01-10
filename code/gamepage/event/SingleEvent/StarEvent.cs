using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class StarEvent : MonoBehaviour {
	
	float time = 0;
	bool timeCheck = true;
	float angle = 30;
	float timeInterval = 0.15f;

	float removeTime = 0;
	float removeInterval = 0.15f;

	float x;
	float y;

	// Use this for initialization
	void Start () {
	
		for (int i = 0; i < Resource.stars.Length; i++)
			if (this.transform.Equals (Resource.stars [i].transform)) {
				this.x = Resource.starPosition [i].x;
				this.y = Resource.starPosition [i].y; 
			}

		removeInterval = Random.Range (20, 35) / 100f;
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.GetComponent<SpriteRenderer> ().color = Resource.clearedColor;

		if (Resource.movStar) {

			if (removeTime < removeInterval)
				this.transform.GetComponent<Transform> ().position = new Vector3 (x, y, 0);
			else if (removeTime < 2 * removeInterval)
				this.transform.GetComponent<Transform> ().position = new Vector3 (100, 100, 0);
			else if (removeTime < 3 * removeInterval)
				this.transform.GetComponent<Transform> ().position = new Vector3 (x, y, 0);
			else if (removeTime < 4 * removeInterval)
				this.transform.GetComponent<Transform> ().position = new Vector3 (100, 100, 0);
			else if (removeTime < 5 * removeInterval)
				this.transform.GetComponent<Transform> ().position = new Vector3 (x, y, 0);
			else if (removeTime < 6 * removeInterval)
				this.transform.GetComponent<Transform> ().position = new Vector3 (100, 100, 0);
			else {
				Resource.movStar = false;
				removeTime = 0;
			}


			removeTime += Time.deltaTime;
		} else {
			removeTime = 0;
			this.transform.GetComponent<Transform> ().position = new Vector3 (100, 100, 0);
			removeInterval = Random.Range (20, 35) / 100f;
			/*
			foreach (Character c in Character.characters)
				if (!c.cleared) {
					activate (c);
					Debug.Log (c.ToString ());
					break;
				}
				*/
		}

		

			

		//Debug.Log (removeTime);

		if (timeCheck && time >= timeInterval) {
			angle = Random.Range(20, 40);
		} else if(time >= timeInterval)
			angle = Random.Range(-40, -20);

		if (time < timeInterval)
			time += Time.deltaTime;
		else {
			time = 0;
			timeCheck = !timeCheck;
		}

		this.transform.GetComponent<Transform> ().Rotate(new Vector3 (0, 0, angle));
		angle = 0;

	}

	public void activate(Character c)
	{
		Resource.character = c;
		c.onBlock ().changeColor (c.Color);
	}
}
