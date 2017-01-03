using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;

public class btnEvent : MonoBehaviour {

	public GameObject[] btns;
	public GameObject square;

	Character character;
	INSTRUCTION direction;

	bool MOVE		= false;
	bool MOVEUP 	= false;
	bool MOVEDOWN 	= false;
	bool MOVERIGHT 	= false;
	bool MOVELEFT 	= false;

	bool _INSTRUCTION	= false;

	public GameObject popup;


	// Use this for initialization
	void Start () {

		character = Resource.character;

		character.speed = 100f;

	}
	
	// Update is called once per frame
	void Update () {


		//move character
		if (MOVE && character.checkDistance (Map.instance.get (0, 0).length () / character.speed * 100 / 99) && character.leftPoint.Count >= 0) {

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
		else if (MOVE && character.leftPoint.Count > 0) 
		{
			character.setPosition ();
			Point p = character.leftPoint.Dequeue() as Point;
			character.setwithErrorCheck (p.x, p.y);
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
		character.speed = 20f;

		if (Resource.instruction == null)
			Resource.instruction = new Instructions ();

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

			Debug.Log (Resource.instruction.ToString ());
		}
			
		/*
		if (!Resource.instruction.checkValid ()) {
			failEvent ();
			Resource.instruction = new Instructions ();
		}
		*/
	}

	public void checkMoveDirection()
	{
		MOVEUP 		= (direction == INSTRUCTION.UP);
		MOVEDOWN 	= (direction == INSTRUCTION.DOWN);
		MOVERIGHT 	= (direction == INSTRUCTION.RIGHT);
		MOVELEFT 	= (direction == INSTRUCTION.LEFT);
	}

	public void checkInstruction()
	{
		if (Resource.instruction == null) {
			_INSTRUCTION = false;
			Resource.instruction = new Instructions ();
			return;
		}

		if (!Resource.instruction.checkValid ()) 
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

		// just enter the switch
		if (_tmp == null) {
			Resource.instruction = new Instructions ();
			_INSTRUCTION = false;
			return;
		}

		// input instructions
		Instruction.Instruction _trim = new Instructions ();

		do {
			_trim.make (_tmp);
			_tmp = _tmp.next;

		} while (_tmp != null && !(_tmp is Action)); 


		character.move (out direction, out MOVE, _trim);
		checkMoveDirection ();

		if (direction != INSTRUCTION.NULL)
			Resource.currentDirection = direction;
		
		Resource.instruction = _tmp;
		_INSTRUCTION = !MOVE;

	}

	public void failEvent()
	{
		square.GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
		popup.GetComponent<Transform> ().position = new Vector3 (0, 0.7f, 0);

		Invoke ("White", 0.5f);
	}

	public void White()
	{
		square.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
		popup.GetComponent<Transform> ().position = new Vector3 (100, 100, 0);

	}
}
