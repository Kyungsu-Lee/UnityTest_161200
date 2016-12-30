using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Instruction;
using System.Threading;

namespace ObjectHierachy
{
	public class Character : MapObject
	{
		public static ArrayList characters = new ArrayList();

		public delegate void failedInstruction();
		public failedInstruction fails = faultInstruction;


		public Character (Transform obj)
		{
			this.obj = obj;
			characters.Add (this);
		}

		public float speed {
			get;
			set;
		}

		private static void faultInstruction()
		{
			Debug.Log ("failed");
		}

		public bool checkDistance(float delta)
		{
			return Vector3.Distance (Map.instance.get (x, y).getposition (), position) > delta;
		}


		public void move(out INSTRUCTION direction, out bool MOVE, Instruction.Instruction instruction)
		{
			map.get (x, y).OnObject = null;
			MOVE = true;

			direction = INSTRUCTION.NULL;	// just for initialize
			Instruction.Instruction _tmp = instruction;

			if (_tmp.instruction == INSTRUCTION.NULL)
				_tmp = _tmp.next;

			if (_tmp != null) 
			{
				int count = 0;

				if (_tmp.instruction == INSTRUCTION.MOVE) {
					direction = _tmp.next.instruction;
					count = ((Number)_tmp.next.next).count ();
					_tmp = _tmp.next.next.next;

					for (int i = 0; i < count; i++) {
						int _x = x;
						int _y = y;


						if (direction == INSTRUCTION.LEFT) {
							x--;
						} else if (direction == INSTRUCTION.UP) {
							y++;
						} else if (direction == INSTRUCTION.DOWN) {
							y--;
						} else if (direction == INSTRUCTION.RIGHT) {
							x++;
						}

						if (!(Map.instance.checkBound (x, y) && Map.instance.checkObtcle (x, y))) {
							x = _x;
							y = _y;
							break;
						}
					}

				} else if (_tmp.instruction == INSTRUCTION.JUMP) {
					
					direction = _tmp.next.instruction;
					count = 2;

					for (int i = 0; i < count; i++) {
						int _x = x;
						int _y = y;


						if (direction == INSTRUCTION.LEFT) {
							x--;
						} else if (direction == INSTRUCTION.UP) {
							y++;
						} else if (direction == INSTRUCTION.DOWN) {
							y--;
						} else if (direction == INSTRUCTION.RIGHT) {
							x++;
						}

						if (i == 0 && map.get (x, y).OnObject == null) {
							x = _x;
							y = _y;
							MOVE = false;

							break;
						}

						if (!Map.instance.checkBound (x, y)) {
							x = _x;
							y = _y;
						}
					}
					
				} else if (_tmp.instruction == INSTRUCTION.BREAK) {
					MOVE = false;
					direction = _tmp.next.instruction;

					int _x = x;
					int _y = y;


					if (direction == INSTRUCTION.LEFT) {
						_x--;
					} else if (direction == INSTRUCTION.UP) {
						_y++;
					} else if (direction == INSTRUCTION.DOWN) {
						_y--;
					} else if (direction == INSTRUCTION.RIGHT) {
						_x++;
					}

					Debug.Log (_x + " " + _y + " : " + map.get (_x, _y).OnObject);

					if (map.get (_x, _y).OnObject != null) {
						map.get (_x, _y).OnObject.position = new Vector3 (-100, -100, -100);
						map.get (_x, _y).OnObject = null;
					}
				}
			}

			MOVE &= true;
		}


		public void moveUp()
		{
			position = new Vector3 (position.x, position.y + map.get (0, 0).length () / speed, position.z);
		}
		public void moveDown()
		{
			position = new Vector3 (position.x, position.y - map.get (0, 0).length () / speed, position.z);
		}
		public void moveLeft()
		{
			position = new Vector3 (position.x - map.get (0, 0).length () / speed, position.y , position.z);
		}
		public void moveRight()
		{
			position = new Vector3 (position.x+  map.get (0, 0).length () / speed, position.y, position.z);
		}

	}
}

