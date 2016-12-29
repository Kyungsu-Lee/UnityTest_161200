using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class btnEvent : MonoBehaviour {

	public GameObject[] btns;

	Character character;
	INSTRUCTION direction;

	bool MOVE		= false;
	bool MOVEUP 	= false;
	bool MOVEDOWN 	= false;
	bool MOVERIGHT 	= false;
	bool MOVELEFT 	= false;

	bool _INSTRUCTION	= false;

	// Use this for initialization
	void Start () {

		character = Resource.character;

		character.speed = 7f;
	}
	
	// Update is called once per frame
	void Update () {


		//move character
		if (MOVE && character.checkDistance (Map.instance.get (0, 0).length () / character.speed * 100 / 99)) {

			if (MOVEUP) {
				character.moveUp ();
			} else if (MOVEDOWN) {
				character.moveDown ();
			} else if (MOVERIGHT) {
				character.moveRight ();
			} else if (MOVELEFT) {
				character.moveLeft ();
			}

		} 
		else if (MOVE)
		{
			character.setPosition ();

			MOVE 		= false;
			MOVEUP 		= false;
			MOVEDOWN 	= false;
			MOVERIGHT 	= false;
			MOVELEFT 	= false;


			_INSTRUCTION = true;
		}

		//instruction check
		if (_INSTRUCTION) {
			checkInstruction ();
		}

	}

	public void OnMouseUp()
	{
		character = Resource.character;
		character.speed = 7f;


		if (this.transform.Equals (btns [0].transform))
			Resource.instruction.move ();
		else if (this.transform.Equals (btns [1].transform))
			Resource.instruction.jump ();
		else if (this.transform.Equals (btns [2].transform))
			Resource.instruction.breaks ();
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
			_INSTRUCTION = true;
		}
			
	}

	public void checkMoveDirection()
	{
		MOVEUP 		= (direction == INSTRUCTION.UP);
		MOVEDOWN 	= (direction == INSTRUCTION.DOWN);
		MOVERIGHT 	= (direction == INSTRUCTION.RIGHT);
		MOVELEFT 	= (direction == INSTRUCTION.LEFT);
		MOVE 		= true;
	}

	public void checkInstruction()
	{

		if (Resource.instruction == null || !Resource.instruction.checkValid ()) 
		{
			Resource.instruction = new Instructions ();
			Resource.failEvent += failEvent;
			Resource.failEvent ();
			Resource.failEvent -= failEvent;
			_INSTRUCTION = false;

			return;
		}

		Instruction.Instruction _tmp = Resource.instruction;
		if(_tmp.instruction == INSTRUCTION.NULL)
			_tmp = _tmp.next;

		Instruction.Instruction _trim = new Instructions ();
		_trim.make (_tmp);
		_tmp = _tmp.next;

		while (_tmp != null && !(_tmp is Action)) {
			_trim.make (_tmp);
			_tmp = _tmp.next;
		}
		Debug.Log (_trim.ToString ());
		character.move (out direction, _trim);
		checkMoveDirection ();

		Resource.instruction = _tmp;
		_INSTRUCTION = false;


	}

	public void failEvent()
	{
		Debug.Log ("failed");
	}
}
