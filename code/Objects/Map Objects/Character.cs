using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Instruction;
using System.Threading;

namespace ObjectHierachy
{
	public delegate void ACTION();

	public class Character : MapObject
	{
		public static ArrayList characters = new ArrayList();

		public delegate void failedInstruction();
		public failedInstruction fails = faultInstruction;

		public Queue leftPoint = new Queue ();

		public ACTION BeforeAction;

		public ACTION AfterAction;


		public Character (Transform obj)
		{
			this.obj = obj;
			characters.Add (this);

			BeforeAction = beforeAction;
			AfterAction = afterAction;
			this.Mov = false;

			this.initScale = obj.GetComponent<Transform> ().localScale;
		}

		public float speed {
			get;
			set;
		}

		public static int Count {
			get { return characters.Count; }
		}

		public bool cleared {
			get;
			set;
		}

		public bool Mov {
			get;
			set;
		}

		public static int clearedCharacter
		{
			get 
			{
				int count = 0;

				foreach (Character c in characters)
					if (c.cleared)
						count++;

				return count;
			}
		}

		public Accessory Match {
			get;
			set;
		}

		public Color color
		{
			get {
				return ((Color)Resource.COLORS [index-1]);
			}
		}

		public bool Jump {
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

		public bool checkDistance(Block block, float delta)
		{
			return Vector3.Distance (block.getposition (), position) > delta;
		} 

		public Character makeCharacter()
		{
			Transform _tmp = MonoBehaviour.Instantiate (this.obj);
			return new Character (_tmp);
		}

		public void move(out INSTRUCTION direction, out bool MOVE, Instruction.Instruction instruction)
		{
			direction = INSTRUCTION.NULL;	// just for initialize
			Instruction.Instruction _tmp = instruction;
			MOVE = true;

			if (_tmp.instruction == INSTRUCTION.NULL)
				_tmp = _tmp.next;

			if (_tmp != null) 
			{
				int count = 0;

				if (_tmp.instruction == INSTRUCTION.MOVE) {
					this.speed = 15f;
					direction = _tmp.next.instruction;
					count = ((Number)_tmp.next.next).count ();
					_tmp = _tmp.next.next.next;

					int _x = x;
					int _y = y;

					for (int i = 0; i < count; i++) {
						
						if (direction == INSTRUCTION.LEFT) {
							_x--;
						} else if (direction == INSTRUCTION.UP) {
							_y++;
						} else if (direction == INSTRUCTION.DOWN) {
							_y--;
						} else if (direction == INSTRUCTION.RIGHT) {
							_x++;
						}

						leftPoint.Enqueue (new Point (_x, _y));
					}

					Point p = leftPoint.Dequeue () as Point;
					setwithErrorCheck (p.x, p.y);
				} 
				else if (_tmp.instruction == INSTRUCTION.JUMP) 
				{
					this.speed = 15f;
					this.Jump = true;
					direction = _tmp.next.instruction;
					count = ((Number)_tmp.next.next).count ();
					_tmp = _tmp.next.next.next;

					int _x = x;
					int _y = y;

					for (int i = 0; i < count; i++) {

						if (direction == INSTRUCTION.LEFT) {
							_x -= 2;
						} else if (direction == INSTRUCTION.UP) {
							_y += 2;
						} else if (direction == INSTRUCTION.DOWN) {
							_y -= 2;
						} else if (direction == INSTRUCTION.RIGHT) {
							_x += 2;
						}

						leftPoint.Enqueue (new Point (_x, _y));
					}

					Point p = leftPoint.Dequeue () as Point;
					setwithErrorCheck (p.x, p.y);
					
				} else if (_tmp.instruction == INSTRUCTION.BREAK) {
					this.speed = 15f;
					direction = _tmp.next.instruction;
					count = ((Number)_tmp.next.next).count ();
					_tmp = _tmp.next.next.next;

					
					int _x = x;
					int _y = y;


					for (int i = 0; i < count; i++) {

						if (direction == INSTRUCTION.LEFT) {
							_x--;
						} else if (direction == INSTRUCTION.UP) {
							_y++;
						} else if (direction == INSTRUCTION.DOWN) {
							_y--;
						} else if (direction == INSTRUCTION.RIGHT) {
							_x++;
						}

						if (map.get (_x, _y).OnObject != null && map.get (_x, _y).OnObject is ObjectHierachy.BadCharacter) {
							leftPoint.Enqueue (new Point (_x, _y));
							map.get (_x, _y).OnObject.position = new Vector3 (-100, -100, -100);
							map.get (_x, _y).OnObject = null;
						}
						else
							break;
					}
						

					if (leftPoint.Count > 0) {
						Point p = leftPoint.Dequeue () as Point;
						setwithErrorCheck (p.x, p.y);
					}
				
				}
			}

		}

		private void set(int x, int y)
		{
			this.x = x;
			this.y = y;
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

		public void makeColorChange()
		{
			map.get (x, y).changeColor (this.color);
		}

		public void setwithErrorCheck (int x, int y)
		{
			BeforeAction ();

			if (checkBound (x, y))
				boundExceptionAction ();
			else {
				map.get (this.x, this.y).OnObject = null;
				set (x, y);
				CharacterJumpUpEvent.endPosition = map.get (x, y).obj.GetComponent<Transform>().position;
			}
		}

		public bool checkBound(int x, int y)
		{
			return!(Map.instance.checkBound (x, y) && Map.instance.checkObtcle (x, y));
		}

		public void boundExceptionAction()
		{
			Point p = pointStack.Peek () as Point;
			set (p.x, p.y);
			leftPoint.Clear();
		}

		public override void setPosition ()
		{
			AfterAction ();
			base.setPosition ();
		}

		public void beforeAction()
		{
			CharacterJumpUpEvent.initPotision = this.position;

			//if(map.get(x,y).index == index)
				map.get (x, y).changeColor (this.color);

			this.Mov = true;
		}

		public void afterAction()
		{
			//if (map.get (x, y).index == index) {
			map.get (this.x, this.y).changeColor (this.color);
			map.get (this.x, this.y).canOn = false;

			//}

			if (this.onBlock ().OnObject != null && this.onBlock ().OnObject is Accessory && this.onBlock ().index == this.index && Resource.canClear) 
			{

				this.cleared = true;
				//Resource.movStar = true;
				Resource.clearedColor = this.color;
				Resource.movRuby[index] = true;


				foreach (Character c in Character.characters)
					if (!c.cleared) {
						activate (c);
						Debug.Log (c.ToString ());
						break;
					}
			}
			else if (this.onBlock ().OnObject != null && this.onBlock ().OnObject is Accessory )
			{
				//Jump = false;
				Mov = false;

				Map.instance.blockAction += changColors;
				Map.instance.allBlockAction ();
				this.toStartPoint ();
				foreach (Accessory a in Accessory.accessory)
					if (!a.Match.cleared)
						a.toStartPoint ();
				activate (this);
				Map.instance.blockAction -= changColors;
			}

			this.Mov = false;
			//map.get (this.x, this.y).OnObject = null;
		}

		private void changColors(Block block)
		{
			if (block.obj.GetComponent<SpriteRenderer>().color.Equals(this.color)) {
				block.changeColor (Color.white);
				block.canOn = true;
			}

			this.pointStack.Clear ();
			Resource.canClear = true;
		}

		public string stackTrace()
		{
			string stack = "";
			foreach (Point p in pointStack)
				stack += p.ToString () + ", ";
			string queue = "";
			foreach (Point p in leftPoint)
				queue += p.ToString () + ", ";

			return ToString () + " stack : " + stack + " queue : " + queue + " Point : " + new Point (x, y).ToString ();
		}

		public override string ToString ()
		{
			return string.Format ("[Character: {0}, {1}]", this.x, this.y);
		}

		public void activate(Character c)
		{
			Resource.character = c;
			c.onBlock ().changeColor ();
		}

		public void removeStar()
		{
			for (int i = 0; i < Resource.stars.Length; i++)
				Resource.stars [i].GetComponent<Transform> ().position = new Vector3 (100, 100, 100);
		}


	}


}

