using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Instruction;
using System.Threading;

namespace ObjectHierachy
{
	public delegate void ACTION();

	public enum ObtacleKind
	{
		NULL,
		FIRE, WATER, ROCK,
		BAD
	}



	public class Character : MapObject
	{
		/// <summary>
		/// All characters which are initiated.
		/// </summary>
		public static ArrayList characters;

		private CharacterStatus characterstatus;

		/// <summary>
		/// The action before character moving.
		/// </summary>
		public ACTION before;

		/// <summary>
		/// The action after finishing moving.
		/// </summary>
		public ACTION after;

		/// <summary>
		/// The action between instructions.
		/// </summary>
		public ACTION UnitAction;

		/// <summary>
		/// Gets the character status.
		/// </summary>
		/// <value>The character status.</value>
		public CharacterStatus characterStatus
		{
			get { return this.characterstatus; }
		}

		/// <summary>
		/// Gets or sets the matched accessory.
		/// </summary>
		/// <value>The match.</value>
		public Accessory Match {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this is cleared.
		/// </summary>
		/// <value><c>true</c> if cleared; otherwise, <c>false</c>.</value>
		public bool Cleared {
			get;
			set;
		}

		/// <summary>
		/// Gets the count of characters.
		/// </summary>
		/// <value>The count.</value>
		public static int Count
		{
			get {return characters.Count;}
		}


		/// <summary>
		/// Gets the number of cleared character.
		/// </summary>
		/// <value>The cleared character.</value>
		public static int clearedCharacter
		{
			get 
			{
				int count = 0;

				foreach (Character c in characters)
					if (c.Cleared)
						count++;

				return count;
			}
		}

		/// <summary>
		/// Moving speed of this character.
		/// </summary>
		/// <value>The speed.</value>
		public float Speed {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this character is moving.
		/// </summary>
		/// <value><c>true</c> if moving; otherwise, <c>false</c>.</value>
		public bool Moving
		{
			set {
				if(value == false)
					this.characterstatus.action = Action.STOP;
			}

			get {
				return this.characterstatus.action != Action.STOP;
			}
		}

		public Color Color {
			get { return ((Color)Resource.COLORS [index-1]); }
		}

		public Point currentPosition {
			get { return new Point (x, y); }
			set {
				this.x = value.x;
				this.y = value.y;
			}
		}

		public ObtacleKind obtacles {
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the class. Cannot use this.
		/// </summary>
		private Character()
		{
			
		}

		public Character (Transform obj)
		{
			if (characters == null)
				characters = new ArrayList ();

			if (characterstatus == null)
				characterstatus = new CharacterStatus ();

			this.obj = obj;
			characters.Add (this);
			this.obtacles = ObtacleKind.NULL;

			before += beforeAction;
			after += afterAction;
		}

		private void beforeAction()
		{
			Debug.Log ("before Action");

			if (map.get (currentPosition).OnObject == this)
				map.get (currentPosition).OnObject = null;

			Resource.canClear = (characterstatus.PointQueue.Count == 1);

			//characterstatus.PointStack.Push (new Point(currentPosition));
			//onBlock ().canOn = false;

			if (characterstatus.action == Action.JUMP || characterstatus.action == Action.BREAK) {

				if (map.checkBound (characterstatus.NextPositionPoint)) {
					CharacterJumpUpEvent.initPotision = map.positionParse (currentPosition);
					CharacterJumpUpEvent.endPosition = map.positionParse (characterStatus.NextPositionPoint);
				}
				CharacterJumpUpEvent.start = true;
			}
		}

		public string ToStringQueue()
		{
			string str = "";

			foreach (Point p in characterstatus.PointQueue)
				str += p.ToString () + " ";

			return str;
		}

		public string ToStringStack()
		{
			string str = "";

			foreach (Point p in characterstatus.PointStack)
				str += p.ToString () + " ";

			return str;
		}

		private void afterAction()
		{
			Debug.Log ("After Action");

			if (Map.instance.get (currentPosition).OnObject == null)
				locateAt (currentPosition.x, currentPosition.y);


			onBlock ().changeColor (Color);

			if (onBlock ().OnObject != null && onBlock ().OnObject is Accessory && (onBlock ().OnObject as Accessory).index == index && Resource.canClear) 
			{
				this.Cleared = true;
				Resource.clearedColor = Color;
				Resource.movRuby [index] = true;

				foreach (Character c in Character.characters)
					if (!c.Cleared) {
						c.activate ();
						Debug.Log (c.ToString ());
						break;
					}

				int n = Map.instance.size;

				for (int i = 0; i < n; i++)
					for (int j = 0; j < n; j++)
						if (map.get (i, j).color.Equals (Color))
							map.get (i, j).canOn = false;
				
			} else if (onBlock ().OnObject != null && onBlock ().OnObject is Accessory && (onBlock ().OnObject as Accessory).index != index) {
				toStartPoint ();
			}

			if (characterstatus.PointQueue.Count > 0)
				before ();

			if (onBlock ().OnObject != null && onBlock ().OnObject is ObjectHierachy.BadCharacter) {
				this.obtacles = ObtacleKind.BAD;
				characterstatus.PointQueue.Clear ();
				Moving = false;
			} 

			if (onBlock ().OnObject != null && onBlock ().OnObject is UnMovableObtacle) {
				this.obtacles = (onBlock ().OnObject as UnMovableObtacle).obtacleKind;
				characterstatus.PointQueue.Clear ();
				Moving = false;
			}


			if (characterstatus.action == Action.BREAK) {
			}
		}

		public void Stop()
		{
			Debug.Log ("Stop Action");
			if (characterstatus.PointQueue.Count > 0) {
				currentPosition = characterStatus.PointQueue.Dequeue () as Point;
				characterstatus.PointStack.Push (currentPosition);

				if (characterstatus.PointQueue.Count == 0)
					characterstatus.PointCursorStack.Push (new Point (currentPosition));
			}

			if (characterstatus.PointQueue.Count == 0)
				this.Moving = false;

			if (Resource.instruction != null && Resource.instruction.next != null && characterstatus.PointQueue.Count == 0)
				Resource.instructionInput = true;

			after ();
		}

		public void changeStatus(Instruction.Instruction instruction)
		{
			Instruction.Instruction _tmp = instruction;

			if (_tmp.instruction == INSTRUCTION.NULL)
				_tmp = _tmp.next;


			INSTRUCTION direction = _tmp.next.instruction;
			int count = ((Number)_tmp.next.next).count ();
			characterstatus.direction = direction;



			if (_tmp != null) 
			{
				if (_tmp.instruction == INSTRUCTION.MOVE) {
					this.Speed = 20f;

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


						characterstatus.PointQueue.Enqueue (new Point (_x, _y));
					}

					this.characterStatus.action = Action.MOVE;

						
				} 
				else if (_tmp.instruction == INSTRUCTION.JUMP) 
				{
					this.Speed = 13f;

					int _x = x;
					int _y = y;

					int __x = x;
					int __y = y;

					for (int i = 0; i < count; i++) {

						if (direction == INSTRUCTION.LEFT) {
							_x -= 2;
							__x--;
						} else if (direction == INSTRUCTION.UP) {
							_y += 2;
							__y++;
						} else if (direction == INSTRUCTION.DOWN) {
							_y -= 2;
							__y--;
						} else if (direction == INSTRUCTION.RIGHT) {
							_x += 2;
							__x++;
						}

						characterstatus.PointQueue.Enqueue (new Point (_x, _y));
						characterstatus.action = Action.JUMP;
					}

				} else if (_tmp.instruction == INSTRUCTION.BREAK) {
					this.Speed = 20f;

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
							characterStatus.PointQueue.Enqueue (new Point (_x, _y));
							(map.get (_x, _y).OnObject as BadCharacter).die ();
							map.get (_x, _y).OnObject = this;
							characterstatus.action = Action.BREAK;
						}
						else
							break;
					}

				}

				_tmp = _tmp.next.next.next;
			}

			before ();
		}

		/// <summary>
		/// Checks the distance is close enough.
		/// </summary>
		/// <returns><c>true</c>, if distance was closed, <c>false</c> otherwise.</returns>
		/// <param name="block">Block.</param>
		/// <param name="delta">Delta.</param>
		public bool checkDistance(Block block, float delta)
		{
			return Vector3.Distance (block.getposition (), position) <= delta;
		}

		public bool checkDistance(Point p, float delta)
		{
			return checkDistance (map.get (p.x, p.y), delta);
		}

		public bool checkDistance(Vector3 vector, float delta)
		{
			return Vector3.Distance (vector, position) <= delta;
		}

		/// <summary>
		/// check character is in the next point.
		/// </summary>
		/// <returns><c>true</c>, if next point is close, <c>false</c> otherwise.</returns>
		public bool onNext()
		{
			if (characterstatus.PointQueue == null || characterstatus.PointQueue.Count <= 0)
				return false;

			return checkDistance (characterStatus.NextPositionPoint as Point, Map.instance.Unitlength / Speed * 100 / 99);
		}

		public void moveUp()
		{
			position = new Vector3 (position.x, position.y + map.get (0, 0).length () / Speed, position.z);
		}
		public void moveDown()
		{
				position = new Vector3 (position.x, position.y - map.get (0, 0).length () / Speed, position.z);
		}
		public void moveLeft()
		{
				position = new Vector3 (position.x - map.get (0, 0).length () / Speed, position.y , position.z);
		}

		public void moveRight()
		{
				position = new Vector3 (position.x+  map.get (0, 0).length () / Speed, position.y, position.z);
		}

		public void fitPosition()
		{
			Vector3 vector = map.positionParse (currentPosition);

			obj.GetComponent<Transform> ().position
			= new Vector3 (
				vector.x,
				vector.y,
				vector.z
			);
		}

		public void activate()
		{
			Resource.character = this;
			onBlock ().changeColor (Color);
		}

		public override void toStartPoint ()
		{
			base.toStartPoint ();

			int n = Map.instance.size;

			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++) {


					if (map.get (i, j).color.Equals (this.Color)) {
						map.get (i, j).changeColor (new Color (1, 1, 1, 1));
						map.get (i, j).canOn = true;
					}
				}

			this.activate ();
			this.Cleared = false;
			this.Match.toStartPoint ();
			this.Match.toInitialScale ();
		}

		public void toPoint(Point from, Point to)
		{
			Point p = from - to;

			Debug.Log (from.ToString () + " " + to.ToString ());
			Debug.Log (p.ToString ());

			int count = 0;

			for (int i = 0; !(i * p.unitPoint ()).Equals(p); i++, count++) {

				map.get (to + i * p.unitPoint ()).changeColor(new Color (1, 1, 1, 1));
				if (count > 100)
					break;
			}

			map.get (from).changeColor (new Color (1, 1, 1));

			locateAt (to);
			activate ();
		}
	}


}

