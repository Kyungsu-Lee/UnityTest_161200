using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class CharacterJumpUpEvent : MonoBehaviour {

	public static Vector3 initPotision;
	public static Vector3 endPosition;
	public static bool start = false;

	//public GameObject camera;

	float time = 0;
	float rate = 1.2f;
	float scaleRate = 0.1f;
	//float orthSize;
	//float orthrate = 0.015f;

	float x, y;

	// Use this for initialization
	void Start () {
		//orthSize = this.camera.GetComponent<Camera> ().orthographicSize;
		rate *= 3.0f / (Resource.stage / 100);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Resource.character == null || Resource.character.obj == null)
			return;

		float position_x = Resource.character.obj.GetComponent<Transform> ().position.x;
		float position_y = Resource.character.obj.GetComponent<Transform> ().position.y;


		if (Resource.character.characterStatus.action == ObjectHierachy.Action.JUMP && start 
			|| Resource.character.characterStatus.action == ObjectHierachy.Action.BREAK && start) {

			if (Resource.character.characterStatus.action == ObjectHierachy.Action.JUMP) {

				Point p = Resource.character.characterStatus.PointQueue.Peek () as Point;
				Point q;

				if (Resource.character.characterStatus.direction == INSTRUCTION.UP)
					q = new Point (p.x, p.y - 1);
				else if (Resource.character.characterStatus.direction == INSTRUCTION.DOWN)
					q = new Point (p.x, p.y + 1);
				else if (Resource.character.characterStatus.direction == INSTRUCTION.RIGHT)
					q = new Point (p.x - 1, p.y);
				else if (Resource.character.characterStatus.direction == INSTRUCTION.LEFT)
					q = new Point (p.x + 1, p.y);
				else
					return;

				if (!(Map.instance.checkBound (p.x, p.y) && Map.instance.checkBound (q.x, q.y))
				   || Map.instance.get (q.x, q.y).OnObject != null && Map.instance.get (q.x, q.y).OnObject is ObjectHierachy.BadCharacter) {
					//CharacterErrorEvent.position = Resource.character.position;
					CharacterErrorEvent.error_jmp = true;
					return;
				}
			}

			if (!Resource.character.checkDistance(endPosition, 0.1f)) 
			{
				time += Time.deltaTime;
				if (initPotision.x != endPosition.x)
				Resource.character.obj.GetComponent<Transform> ().localScale = 
					new Vector3 (
							x * (Mathf.Abs((4 * scaleRate * (position_x - initPotision.x) * (position_x - endPosition.x) / (Mathf.Pow(initPotision.x - endPosition.x,2)))) + 1),
							y * (Mathf.Abs((4 * scaleRate * (position_x - initPotision.x) * (position_x - endPosition.x) / (Mathf.Pow(initPotision.x - endPosition.x,2)))) + 1),
						Resource.character.obj.GetComponent<Transform>().localScale.z
					);
				else
					Resource.character.obj.GetComponent<Transform> ().localScale = 
					new Vector3 (
							x * (Mathf.Abs((4 * scaleRate * (position_y - initPotision.y) * (position_y - endPosition.y) / (Mathf.Pow((initPotision.y - endPosition.y),2)))) + 1),
							y * (Mathf.Abs((4 * scaleRate * (position_y - initPotision.y) * (position_y - endPosition.y) / (Mathf.Pow((initPotision.y - endPosition.y),2)))) + 1),
						Resource.character.obj.GetComponent<Transform>().localScale.z
					);
				/*
				if(initPotision.x != endPosition.x)
					this.camera.GetComponent<Camera> ().orthographicSize = orthSize *  (Mathf.Abs ((4 * orthrate * (position_x - initPotision.x) * (position_x - endPosition.x) / (Mathf.Pow (initPotision.x - endPosition.x, 2)))) + 1);
				else
					this.camera.GetComponent<Camera> ().orthographicSize = orthSize *  (Mathf.Abs ((4 * orthrate * (position_y - initPotision.y) * (position_y - endPosition.y) / (Mathf.Pow (initPotision.y - endPosition.y, 2)))) + 1);
*/

				if (initPotision.x != endPosition.x)
					Resource.character.obj.GetComponent<Transform> ().position = 
					new Vector3 (
						position_x,
						initPotision.y + (Mathf.Abs ((4 * rate * (position_x - initPotision.x) * (position_x - endPosition.x) / (Mathf.Pow (initPotision.x - endPosition.x, 2))))),
						initPotision.z
					);
				else {
				}
		
			} 
			else{
				//Resource.character.Moving = false;
				time = 0;
			}


			int n = Map.instance.size;

			for(int i=0; i<n; i++)
				for(int j=0; j<n; j++)
					if(Mathf.Abs(Map.instance.get(i,j).obj.GetComponent<Transform>().position.x - position_x) < Map.instance.unitSize/10 
						&& Map.instance.get(i,j).obj.GetComponent<Transform>().position.y - Resource.character.obj.GetComponent<Transform>().position.y < 0 
						&& Mathf.Abs(Map.instance.get(i,j).obj.GetComponent<Transform>().position.y - Resource.character.obj.GetComponent<Transform>().position.y) < Map.instance.unitSize/1.2f
					)
						Map.instance.get(i,j).changeColor(Resource.character.Color);
			

			for(int i=0; i<n; i++)
				for(int j=0; j<n; j++)
					if(Resource.character.checkDistance(Map.instance.get(i,j) , Map.instance.unitSize/10))
						Map.instance.get(i,j).changeColor(Resource.character.Color);

		} else {
			Resource.character.toInitialScale ();
			x = Resource.character.locaScale.x;
			y = Resource.character.locaScale.y;
			time = 0;

		}
	}
}
