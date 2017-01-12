using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class CharacterErrorEvent : MonoBehaviour {

	public static bool error_mov = false;
	public static bool error_jmp = false;
	public static bool error_brk = false;

	public static int index;

	float time = 0;

	float bound;
	public static Vector3 position;
	bool flag = true;

	// Use this for initialization
	void Start () {
		bound = Map.instance.unitSize/10;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (error_mov) {
			if ((time += Time.deltaTime) < 1) {
				//action is in CharacterImgChang
			} else {
				time = 0;
				error_mov = false;
				Resource.character.Stop ();
			}
		} else if (error_jmp) {
			if ((time += Time.deltaTime) < 1f) {
				if(!flag)
					Resource.character.obj.GetComponent<Transform> ().position 
					= new Vector3 
						(
							position.x,
							Resource.character.obj.GetComponent<Transform> ().position.y + bound/8,
							position.z
						);
				else
					Resource.character.obj.GetComponent<Transform> ().position 
					= new Vector3 
						(
							position.x,
							Resource.character.obj.GetComponent<Transform> ().position.y - bound/8,
							position.z
						);

				if (Resource.character.obj.GetComponent<Transform> ().position.y >= position.y +  bound
				   || Resource.character.obj.GetComponent<Transform> ().position.y < position.y
				){
					flag = !flag;
				}

				Debug.Log (flag + " " + error_jmp);
				Debug.Log ((Resource.character.obj.GetComponent<Transform> ().position.y).ToString ("0.00") + " >= " + (position.y + bound).ToString("0.00") + " " + position.y.ToString("0.00"));
				
			} else {
				time = 0;
				error_jmp = false;
				Resource.character.fitPosition ();
				Resource.character.characterStatus.PointQueue.Clear ();
				//Resource.character.toStartPoint ();
				Resource.character.Moving = false;
			}
		} else {
			if(Resource.character != null)
				position = Resource.character.obj.GetComponent<Transform> ().position;
		}

	}
}
