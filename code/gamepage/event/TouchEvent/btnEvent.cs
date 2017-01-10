using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class btnEvent : MonoBehaviour {

	public GameObject[] btns;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseUp()
	{
		if (Resource.instruction == null)
			Resource.instruction = new Instructions ();

		if (this.transform.Equals (btns [0].transform)) {
			Resource.instruction.move ();
		} else if (this.transform.Equals (btns [1].transform)) {
			Resource.instruction.jump ();
		} else if (this.transform.Equals (btns [2].transform)) {
			Resource.instruction.breaks ();
		}
		else if (this.transform.Equals (btns [3].transform))
			Resource.instruction.up ();
		else if (this.transform.Equals (btns [4].transform))
			Resource.instruction.left ();
		else if (this.transform.Equals (btns [5].transform))
			Resource.instruction.down ();
		else if (this.transform.Equals (btns [6].transform))
			Resource.instruction.right ();
		else if (this.transform.Equals (btns [7].transform))
			Resource.instruction.one ();
		else if (this.transform.Equals (btns [8].transform))
			Resource.instruction.two ();
		else if (this.transform.Equals (btns [9].transform))
			Resource.instruction.three ();
		else if (this.transform.Equals (btns [10].transform))
			Resource.instruction.four ();
		else if (this.transform.Equals (btns [11].transform))
			Resource.instruction.five ();
		else if (this.transform.Equals (btns [12].transform)) {
			Resource.instructionInput = true;

			Debug.Log (Resource.instruction.ToString ());
		}
	}

}
