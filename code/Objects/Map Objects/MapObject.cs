using System;
using UnityEngine;
using System.Collections;

namespace ObjectHierachy
{
	public abstract class MapObject
	{

		protected int x = -1;
		protected int y = -1;

		public Transform obj;

		protected Map map;

		private Stack pointStack = new Stack ();

		public MapObject ()
		{
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

		public int index
		{
			get;
			set;
		}

		public void setPosition()
		{
			position = map.get (x, y).getposition ();
			map.get (x, y).OnObject = this;
			pointStack.Push (new Point (x, y));
		}

		public void setPosition(int x, int y)
		{
			map.get (this.x, this.y).OnObject = null;

			this.x = x;
			this.y = y;
			position = map.get (x, y).getposition ();
			map.get (this.x, this.y).OnObject = this;
			pointStack.Push (new Point (x, y));
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

