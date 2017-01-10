using System;
using UnityEngine;
using Instruction;

namespace ObjectHierachy
{
	public class Block
	{
		public Transform obj;
		Color defaultColor = new Color (1f, 1, 1, 1f);
		Color changedColor = Color.green;

		public MapObject OnObject {
			get;
			set;
		}

		public int index {
			get;
			set;
		}

		public bool canOn {
			get;
			set;
		}

		public Color color {
			get { return this.obj.GetComponent<SpriteRenderer> ().color; }
		}

		public Block(Transform obj)
		{
			this.obj = obj;
			obj.GetComponent<SpriteRenderer> ().color = defaultColor;
		}

		public void changeColor(Color color)
		{
			obj.GetComponent<SpriteRenderer> ().color = new Color (color.r, color.g, color.b);
		}

		public Block makeBlock()
		{
			Transform _tmp = MonoBehaviour.Instantiate (obj);
			return new Block (_tmp);
		}

		public void setPosition(float x, float y)
		{
			obj.position = new Vector3 (x, y, obj.position.z);
		}

		public float length()
		{
			return obj.GetComponent<Transform> ().localScale.x;
		}

		public Vector3 getposition()
		{
			return obj.GetComponent<Transform> ().localPosition;
		}

		public Vector3 localscale {
			get { return obj.GetComponent<Transform> ().localScale;}
			set { obj.GetComponent<Transform> ().localScale = value;}
		}


	}
}

