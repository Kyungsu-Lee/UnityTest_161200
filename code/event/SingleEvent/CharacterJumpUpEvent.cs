using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class CharacterJumpUpEvent : MonoBehaviour {

	public static Vector3 initPotision;
	public static Vector3 endPosition;

	float time = 0;
	float due_time = 0.65f;
	float rate = 0.7f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Resource.character.Jump) {
			float x = Resource.character.obj.GetComponent<Transform> ().position.x;

			if (time < due_time) {
				time += Time.deltaTime;
				Resource.character.obj.GetComponent<Transform> ().position = 
				new Vector3 (
					x,
						initPotision.y + Mathf.Abs (4 * rate * (x - initPotision.x) * (x - endPosition.x) / ((endPosition.x - initPotision.x) * (endPosition.x - initPotision.x))),
					initPotision.z
				);
			} else {
				Resource.character.obj.GetComponent<Transform> ().position = 
					new Vector3 (
					endPosition.x,
					endPosition.y,
					endPosition.z
				);
			}

			int n = Map.instance.size;

			for(int i=0; i<n; i++)
				for(int j=0; j<n; j++)
					if(Mathf.Abs(Map.instance.get(i,j).obj.GetComponent<Transform>().position.x - x) < Map.instance.unitSize/2 
						&& Map.instance.get(i,j).obj.GetComponent<Transform>().position.y - Resource.character.obj.GetComponent<Transform>().position.y < 0 
						&& Mathf.Abs(Map.instance.get(i,j).obj.GetComponent<Transform>().position.y - Resource.character.obj.GetComponent<Transform>().position.y) > Map.instance.unitSize/2)
						Map.instance.get(i,j).changeColor(Resource.character.color);

		} else {
			Resource.character.Jump = false;
			time = 0;
		}
	}
}
