using UnityEngine;
using System.Collections;
using Instruction;

public class Hide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Resource.stage == 300) {
			for (int i = 3; i < 12; i++) {
				GameObject.Find ("stage_circle_" + i).GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				GameObject.Find ("circle_clear (" + i + ")").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
			}

			GameObject.Find ("p4_line").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);

			for (int i = 0; i < 3; i++) {
				GameObject.Find ("stage_circle_" + i).GetComponent<Transform> ().position
			= new Vector3 (
					GameObject.Find ("stage_circle_" + i).GetComponent<Transform> ().position.x,
					0,
					GameObject.Find ("stage_circle_" + i).GetComponent<Transform> ().position.z
				);

				GameObject.Find ("circle_clear (" + i + ")").GetComponent<Transform> ().position
			= new Vector3 (
					GameObject.Find ("circle_clear (" + i + ")").GetComponent<Transform> ().position.x,
					0,
					GameObject.Find ("circle_clear (" + i + ")").GetComponent<Transform> ().position.z
				);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
