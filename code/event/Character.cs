using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ObjectHierachy
{
	public class Character
	{
		public static ArrayList characters = new ArrayList();

		private Transform obj;

		public Character (Transform obj)
		{
			this.obj = obj;
			characters.Add (this);
		}

		public void move(Block block)
		{
			obj.GetComponent<Transform> ().position = block.getposition ();
		}

		public Vector3 position {
			get { return obj.GetComponent<Transform> ().position;}
			set { obj.GetComponent<Transform> ().position = value; }
		}

		public Vector3 locaScale
		{
			get { return obj.GetComponent<Transform> ().localScale; }
			set { obj.GetComponent<Transform> ().localScale = value; }
		}
	}
}

