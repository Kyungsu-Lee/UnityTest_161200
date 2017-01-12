using UnityEngine;
using System.Collections;
using ObjectHierachy;
using Instruction;

public class BadCharacter : MonoBehaviour {

	public Sprite[] img;
	float i=0; 
	float speed = 7f;

	float startPosition;
	float range_x = 0.3f;
	float b_speed = 0.023f;
	bool flag = true;

	int before = 950;

	float _time = 0;

	// Use this for initialization
	void Start () {
		startPosition = this.transform.GetComponent<Transform> ().position.x;
		range_x *= (3.0f/(Resource.stage/100));
		b_speed *= (3.0f/(Resource.stage/100));

		int r = (int)Mathf.Pow (-1, Random.Range (0, 100));

		//if (Random.Range (0, 100) % 2 == 0)
		this.transform.GetComponent<Transform> ().localScale 
			= new Vector3 (
			r * this.transform.GetComponent<Transform> ().localScale.x,
			this.transform.GetComponent<Transform> ().localScale.y,
			this.transform.GetComponent<Transform> ().localScale.z)
				;

		if (r < 0)
			flag = false;
	}
	
	// Update is called once per frame
	void Update () {



		foreach (MapObject b in MapObject.ALLOBJECT)
			if (b.obj != null && b.obj.transform.Equals (this.transform)) 
			{
				if (!(b as ObjectHierachy.BadCharacter).Die) {
					i += Time.deltaTime;
					this.transform.GetComponent<SpriteRenderer> ().sprite = img [(int)Mathf.Floor ((i++) / speed) % img.Length];


					int current = before > 900 ? Random.Range (890, 1000) : Random.Range (0, 910);

					if (current > 900) {

						before = current;

						if (!flag) {
							this.transform.GetComponent<Transform> ().position = 
								new Vector3 (
								this.transform.GetComponent<Transform> ().position.x + b_speed,
								this.transform.GetComponent<Transform> ().position.y,
								this.transform.GetComponent<Transform> ().position.z
							);


						} else
							this.transform.GetComponent<Transform> ().position = 
								new Vector3 (
								this.transform.GetComponent<Transform> ().position.x - b_speed,
								this.transform.GetComponent<Transform> ().position.y,
								this.transform.GetComponent<Transform> ().position.z
							);



						if (this.transform.GetComponent<Transform> ().position.x >= startPosition + range_x || this.transform.GetComponent<Transform> ().position.x <= startPosition - range_x) {

							flag = !flag;

							//range_x = Random.Range (30, 40) / 100.0f;

							this.transform.GetComponent<Transform> ().localScale = 
								new Vector3 (
								-this.transform.GetComponent<Transform> ().localScale.x,
								this.transform.GetComponent<Transform> ().localScale.y,
								this.transform.GetComponent<Transform> ().localScale.z
							);
						}
					}
				} else {
					if ((_time += Time.deltaTime) < 0.5f) {
					}
					else
						this.transform.GetComponent<SpriteRenderer> ().sprite = Resource.deadCharacter;
				}	
			}
		
	}
}
