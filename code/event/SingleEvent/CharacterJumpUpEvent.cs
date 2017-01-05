using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class CharacterJumpUpEvent : MonoBehaviour {

	public static Vector3 initPotision;
	public static Vector3 endPosition;

	float time = 0;
	float due_time = 1f;
	float rate = 0.3f;
	float scaleRate = 0.2f;

	float x, y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float position_x = Resource.character.obj.GetComponent<Transform> ().position.x;


		if (Resource.character.Jump) {


			if ( Vector3.Distance(this.transform.GetComponent<Transform>().position, endPosition) > 0.1f) 
			{
				time += Time.deltaTime;
				Resource.character.obj.GetComponent<Transform> ().localScale = 
					/*new Vector3 (
						x * ((4 * (1 - scaleRate) / (due_time * due_time)) * time * (time - due_time) + 1),
						y * ((4 * (1 - scaleRate) / (due_time * due_time)) * time * (time - due_time) + 1),
						Resource.character.obj.GetComponent<Transform> ().localScale.z
					);
					*/
					new Vector3 (
						x * (Mathf.Abs((4 * scaleRate * (position_x - initPotision.x) * (position_x - endPosition.x) / (initPotision.x * initPotision.x - endPosition.x * endPosition.x))) + 1),
						y * (Mathf.Abs(( 4 * scaleRate * (position_x - initPotision.x) * (position_x - endPosition.x) / (initPotision.x * initPotision.x - endPosition.x * endPosition.x))) + 1),
						Resource.character.obj.GetComponent<Transform>().localScale.z
					);

				if (initPotision.x != endPosition.x)
					Resource.character.obj.GetComponent<Transform> ().position = 
					new Vector3 (
						position_x,
						initPotision.y + Mathf.Abs (4 * rate * (position_x - initPotision.x) * (position_x - endPosition.x) / (initPotision.x * initPotision.x - endPosition.x * endPosition.x)),
						initPotision.z
					);
				else {
				}
			} 
			else{
				Resource.character.Jump = false;
				time = 0;
			}


			int n = Map.instance.size;

			for(int i=0; i<n; i++)
				for(int j=0; j<n; j++)
					if(Mathf.Abs(Map.instance.get(i,j).obj.GetComponent<Transform>().position.x - x) < Map.instance.unitSize/10 
						&& Map.instance.get(i,j).obj.GetComponent<Transform>().position.y - Resource.character.obj.GetComponent<Transform>().position.y < 0 
						&& Mathf.Abs(Map.instance.get(i,j).obj.GetComponent<Transform>().position.y - Resource.character.obj.GetComponent<Transform>().position.y) < Map.instance.unitSize/2)
						Map.instance.get(i,j).changeColor(Resource.character.color);
			

			for(int i=0; i<n; i++)
				for(int j=0; j<n; j++)
					if(!Resource.character.checkDistance(Map.instance.get(i,j) , Map.instance.unitSize/10))
						Map.instance.get(i,j).changeColor(Resource.character.color);

		} else {
			Resource.character.toInitialScale ();
			x = Resource.character.locaScale.x;
			y = Resource.character.locaScale.y;
			time = 0;

		}

		//Debug.Log (time);
	}
}
