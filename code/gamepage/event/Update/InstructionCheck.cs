using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class InstructionCheck : MonoBehaviour {

	Character character;
	public GameObject popup;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		character = Resource.character;

		if (Resource.instructionInput) 
			checkInstruction ();

		
	}

	public void checkInstruction()
	{
		if (Resource.instruction == null) {
			Resource.instructionInput = false;
			Resource.instruction = new Instructions ();
			return;
		}

		if (!Resource.instruction.checkValid ()) 
		{
			Resource.instruction = new Instructions ();
			Resource.failEvent += failEvent;
			Resource.failEvent ();
			Resource.failEvent -= failEvent;
			Resource.instructionInput = false;

			return;
		}

		Instruction.Instruction _tmp = Resource.instruction;
		if(_tmp.instruction == INSTRUCTION.NULL)
			_tmp = _tmp.next;

		// just enter the switch
		if (_tmp == null) {
			Resource.instructionInput = false;
			Resource.instruction = new Instructions ();
			return;
		}

		// input instructions
		Instruction.Instruction _trim = new Instructions ();

		do {
			_trim.make (_tmp);
			_tmp = _tmp.next;

		} while (_tmp != null && !(_tmp is  Instruction.Action)); 

		Resource.instructionInput = false;
		//character.move (out direction, out MOVE, _trim);
		character.changeStatus(_trim);

		Resource.instruction = _tmp;

	}

	public void failEvent()
	{
		popup.GetComponent<Transform> ().position = new Vector3 (0, 0, 0);

		Invoke ("depose", 0.3f);
	}

	public void depose()
	{
		popup.GetComponent<Transform> ().position = new Vector3 (-100, -100, 0);

	}
}
