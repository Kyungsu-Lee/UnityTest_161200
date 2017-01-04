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
	float removeInterval = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Resource.movStar) {

			if(removeTime < 0)
			this.transform.GetComponent<Transform> ().position = new Vector3 (0.407f, -3.453f, 0);
			else if(removeTime < removeInterval)
				this.transform.GetComponent<Transform> ().position = new Vector3 (100, 100, 100);
			else if(removeTime < removeInterval * 2)
				this.transform.GetComponent<Transform> ().position = new Vector3 (0.407f, -3.453f, 0);
			else if(removeTime < removeInterval * 3)
				this.transform.GetComponent<Transform> ().position = new Vector3 (100, 100, 100);
			else if(removeTime < removeInterval * 4)
				this.transform.GetComponent<Transform> ().position = new Vector3 (0.407f, -3.453f, 0);
			


			if (removeTime < removeInterval * 5)
				removeTime += Time.deltaTime;
			else {
				removeTime = 0;
				Resource.movStar = false;
			}
		}
		else
			this.transform.GetComponent<Transform> ().position = new Vector3 (100, 100, 100);
		

			

		Debug.Log (removeTime);

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
}
