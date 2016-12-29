using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Instruction;
using System.Threading;

namespace ObjectHierachy
{
	public class Character
	{
		public static ArrayList characters = new ArrayList();

		public delegate void failedInstruction();
		public failedInstruction fails = faultInstruction;

		public Transform obj;

		private Map map;
		public int x;
		public int y;

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

		public Vector3 position
		{
			get { return obj.GetComponent<Transform> ().position; }
			set { obj.GetComponent<Transform> ().position = value; }
		}

		public float speed {
			get;
			set;
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



		private static void faultInstruction()
		{
			Debug.Log ("failed");
		}

		public bool checkDistance(float delta)
		{
			return Vector3.Distance (Map.instance.get (x, y).getposition (), position) > delta;
		}

		public void move(out INSTRUCTION direction, Instruction.Instruction instruction)
		{
			
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

						if (!Map.instance.checkBound (x, y)) {
							x = _x;
							y = _y;
						}

					}
				} 
				else if(_tmp.instruction == INSTRUCTION.JUMP)
				{
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

						if (!Map.instance.checkBound (x, y)) {
							x = _x;
							y = _y;
						}
					}
					
				}
			}
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

		public void setPosition()
		{
			position = map.get (x, y).getposition ();
		}
	}
}

