using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;

public class RubyEvent : MonoBehaviour {

	//float x, y;
	int index;

	float time;
	float speed;

	Vector3 ringPosition;
	Vector3	initScale;
	Vector3 initPosition;

	// Use this for initialization
	void Start () {
		//x = this.transform.GetComponent<Transform> ().position.x;
		//y = this.transform.GetComponent<Transform> ().position.y;

		foreach (Character c in Character.characters) {
			if (c != null && c.Match != null && c.Match.obj != null && c.Match.obj.transform.Equals (this.transform)) {
				this.index = c.index;
				c.Match.initScale = this.transform.GetComponent<Transform> ().localScale;
				break;
			}
		}

		time = 0;
		speed = 5.0f;

		ringPosition = Resource.ring.GetComponent<Transform> ().position;

		initScale = this.transform.GetComponent<Transform> ().localScale;
		initPosition = this.transform.GetComponent<Transform> ().position;


	}
	
	// Update is called once per frame
	void Update () {

		if (Resource.movRuby == null)
			return;
		

		if(Resource.movRuby[index]){
			if (Vector3.Distance (ringPosition, this.transform.GetComponent<Transform> ().position) > 0.1f) {
				if (Vector3.Distance (ringPosition, this.transform.GetComponent<Transform> ().position) > 0.1f) {
					this.transform.GetComponent<Transform> ().position = 
						new Vector3 (
						this.transform.GetComponent<Transform> ().position.x - time * (this.transform.GetComponent<Transform> ().position.x - ringPosition.x),
						this.transform.GetComponent<Transform> ().position.y - time * (this.transform.GetComponent<Transform> ().position.y - ringPosition.y),
						this.transform.GetComponent<Transform> ().position.z
					);
					

				}

				//from 1f to 0f
				float rate = Mathf.Abs (Vector3.Distance (ringPosition, this.transform.GetComponent<Transform> ().position) / Vector3.Distance (ringPosition, initPosition));

				rate = Mathf.Pow (rate, 0.3f);

				this.transform.GetComponent<Transform> ().localScale = 
					new Vector3 (
						initScale.x * rate, 
						initScale.y * rate,
						initScale.z * rate
					);


			} 
			else if(time > 1/speed)
			{
				time = 0;
				this.transform.GetComponent<Transform> ().localScale = new Vector3 (0, 0, 0);
				Resource.movRuby[index] = false;
				Resource.movStar = true;
			}

		}
		else 
		{
			time = 0;
		}

		time += Time.deltaTime/speed;
	}
}
