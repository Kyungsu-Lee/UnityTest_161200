using System;
using UnityEngine;
using System.Collections;

namespace ObjectHierachy
{
	public abstract class MapObject
	{
		public static ArrayList ALLOBJECT = new ArrayList ();

		protected int x = -1;
		protected int y = -1;

		public Transform obj;

		protected Map map;

		public Point StartPoint {
			get;
			set;
		}

		public Stack pointStack = new Stack ();

		delegate void PositionAction();
		PositionAction positionAction = () => "void action".ToString();

		public MapObject ()
		{
			ALLOBJECT.Add (this);
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

		public Block onBlock()
		{
			return Map.instance.get (x, y);
		}

		public int index
		{
			get;
			set;
		}

		public virtual void setPosition()
		{
			position = map.get (x, y).getposition ();
			map.get (x, y).OnObject = this;
			pointStack.Push (new Point (x, y));
			positionAction ();
		}

		public void locateAt(int x, int y)
		{
			if(this.x > -1 && this.y > -1)
				map.get (this.x, this.y).OnObject = null;
			this.x = x;
			this.y = y;
			obj.GetComponent<Transform> ().position = map.get (x, y).getposition ();
			map.get (x, y).OnObject = this;
			pointStack.Push (new Point (x, y));
		}

		public void toStartPoint()
		{
			locateAt (this.StartPoint.x, this.StartPoint.y);
		}

		public void connectMap(Map map)
		{
			this.map = map;
		}

		public override string ToString ()
		{
			return this.obj.name.ToString ();
		}
	}

}

