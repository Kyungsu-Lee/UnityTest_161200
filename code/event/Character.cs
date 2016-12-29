using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Instruction;

namespace ObjectHierachy
{
	public class Character
	{
		public static ArrayList characters = new ArrayList();

		public delegate void failedInstruction();
		public failedInstruction fails = faultInstruction;

		private Transform obj;

		private Map map;
		private int x;
		private int y;

		public Character (Transform obj)
		{
			this.obj = obj;
			characters.Add (this);
		}


		public Vector3 locaScale
		{
			get { return obj.GetComponent<Transform> ().localScale; }
			set { obj.GetComponent<Transform> ().localScale = value; }
		}

		public void connectMap(Map map)
		{
			this.map = map;
		}


		public void locateAt(int x, int y)
		{
			this.x = x;
			this.y = y;
			obj.GetComponent<Transform> ().position = map.get (x, y).getposition ();
		}


		public void move(Instruction.Instruction instruction)
		{
			Instruction.Instruction _tmp = instruction.next;

			if (!instruction.checkValid ()) {
				fails ();
				return;
			}

			while (_tmp != null) {

				Debug.Log (_tmp.instruction.ToString ());

				INSTRUCTION direction;
				int count = 0;


				if (_tmp.instruction == INSTRUCTION.MOVE) 
				{
					direction = _tmp.next.instruction;
					count = ((Number)_tmp.next.next).count ();
					_tmp = _tmp.next.next.next;


					for (int i = 0; i < count; i++) 
					{
						int _x = x;
						int _y = y;


						if (direction == INSTRUCTION.LEFT) {
							x--;
						}

						else if (direction == INSTRUCTION.UP) {
							y++;
						} else if (direction == INSTRUCTION.DOWN) {
							y--;
						} else if (direction == INSTRUCTION.RIGHT) {
							x++;
						}

						if (!map.checkBound (x, y)) {
							x = _x;
							y = _y;
						}

						this.locateAt (x,y);
						map.get (x, y).changColor ();
					}

				} else if (_tmp.instruction == INSTRUCTION.JUMP) {
				} else if (_tmp.instruction == INSTRUCTION.BREAK) {
				}
			}

		}


		private static void faultInstruction()
		{
			Debug.Log ("failed");
		}
	}
}

