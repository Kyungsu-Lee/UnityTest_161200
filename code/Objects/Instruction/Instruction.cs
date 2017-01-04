using UnityEngine;
using System.Collections;
using System;

namespace Instruction
{
	public enum INSTRUCTION
	{
		ONE, TWO, THREE, FOUR, FIVE,

		UP, DOWN, LEFT, RIGHT,

		MOVE, JUMP, BREAK,

		ACTION, NUMBER, DIRECTION,

		NULL
	}


	public abstract class Instruction
	{

		public Instruction next
		{
			get;
			set;
		}

		public Instruction before
		{
			get;
			set;
		}

		public INSTRUCTION instruction
		{
			get;
			protected set;
		}



		public abstract bool nextValid();


		public bool checkValid()
		{
			Instruction _tmp = this;
			bool flag = true;

			while (_tmp != null && flag)
			{
				flag &= _tmp.nextValid();
				_tmp = _tmp.next;
			}

			return flag;
		}

		public static Instruction operator +(Instruction one, Instruction other)
		{
			Instruction _tmp = one;

			while (_tmp.next != null)
				_tmp = _tmp.next;

			_tmp.next = other;
			other.before = _tmp;

			return one;
		}


		public Instruction make(INSTRUCTION instruction)
		{
			Instruction _tmp;
			INSTRUCTION type = typeCheck(instruction);

			if (type == INSTRUCTION.ACTION)
				_tmp = new Action(instruction);
			else if (type == INSTRUCTION.DIRECTION)
				_tmp = new Direction(instruction);
			else
				_tmp = new Number(instruction);

			return (this + _tmp);
		}

		public Instruction make(String instruction)
		{
			return make(convert(instruction));
		}

		protected INSTRUCTION convert(String instruction)
		{
			instruction.ToLower();

			if (instruction.Equals("move"))
				return INSTRUCTION.MOVE;
			else if (instruction.Equals("jump"))
				return INSTRUCTION.JUMP;
			else if (instruction.Equals("break"))
				return INSTRUCTION.BREAK;
			else if (instruction.Equals("up"))
				return INSTRUCTION.UP;
			else if (instruction.Equals("down"))
				return INSTRUCTION.DOWN;
			else if (instruction.Equals("right"))
				return INSTRUCTION.RIGHT;
			else if (instruction.Equals("left"))
				return INSTRUCTION.LEFT;
			else if (instruction.Equals("one") || instruction.Equals("1"))
				return INSTRUCTION.ONE;
			else if (instruction.Equals("two") || instruction.Equals("2"))
				return INSTRUCTION.TWO;
			else if (instruction.Equals("three") || instruction.Equals("3"))
				return INSTRUCTION.THREE;
			else if (instruction.Equals("four") || instruction.Equals("4"))
				return INSTRUCTION.FOUR;
			else if (instruction.Equals("five") || instruction.Equals("5"))
				return INSTRUCTION.FIVE;
			else
				return INSTRUCTION.NULL;
		}

		public Instruction one()
		{
			return make("1");
		}
		public Instruction two()
		{
			return make("2");
		}
		public Instruction three()
		{
			return make("3");
		}
		public Instruction four()
		{
			return make("4");
		}
		public Instruction five()
		{
			return make("5");
		}
		public Instruction move()
		{
			return make("move");
		}
		public Instruction breaks()
		{
			return make("break");
		}
		public Instruction jump()
		{
			return make("jump");
		}
		public Instruction up()
		{
			return make("up");
		}
		public Instruction down()
		{
			return make("down");
		}
		public Instruction right()
		{
			return make("right");
		}
		public Instruction left()
		{
			return make("left");
		}


		protected INSTRUCTION typeCheck(INSTRUCTION instruction)    // check the type of instruction
		{
			if (INSTRUCTION.ONE <= instruction && instruction <= INSTRUCTION.FIVE)
				return INSTRUCTION.NUMBER;

			else if (INSTRUCTION.MOVE <= instruction && instruction <= INSTRUCTION.BREAK)
				return INSTRUCTION.ACTION;

			else
				return INSTRUCTION.DIRECTION;
		}

		public override string ToString ()
		{
			string str = "";
			Instruction _tmp = this;

			while (_tmp != null) {
				if(!_tmp.instruction.Equals(INSTRUCTION.NULL))
				str += _tmp.instruction.ToString () + " ";
				_tmp = _tmp.next;
			}

			return str;
		}

		public void make(Instruction instruction)
		{
			if (instruction.instruction == INSTRUCTION.MOVE)
				make ("move");
			else if (instruction.instruction == INSTRUCTION.JUMP)
				make ("jump");
			else if (instruction.instruction == INSTRUCTION.BREAK)
				make ("break");
			else if (instruction.instruction == INSTRUCTION.UP)
				make ("up");
			else if (instruction.instruction == INSTRUCTION.JUMP)
				make ("jump");
			else if (instruction.instruction == INSTRUCTION.DOWN)
				make ("down");
			else if (instruction.instruction == INSTRUCTION.RIGHT)
				make ("right");
			else if (instruction.instruction == INSTRUCTION.LEFT)
				make ("left");
			else if (instruction.instruction == INSTRUCTION.ONE)
				make ("one");
			else if (instruction.instruction == INSTRUCTION.TWO)
				make ("two");
			else if (instruction.instruction == INSTRUCTION.THREE)
				make ("three");
			else if (instruction.instruction == INSTRUCTION.FOUR)
				make ("four");
			else if (instruction.instruction == INSTRUCTION.FIVE)
				make ("five");
		}
	}
}