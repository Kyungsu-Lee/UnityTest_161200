using System;
using UnityEngine;

namespace ObjectHierachy
{
	public class Block
	{
		public Transform obj;
		Color defaultColor = new Color (0.25f, 0, 34f, 0.1f);
		Color changedColor = Color.green;

		public MapObject OnObject {
			get;
			set;
		}

		public Block(Transform obj)
		{
			this.obj = obj;
			obj.GetComponent<SpriteRenderer> ().color = defaultColor;
		}

		public void changColor()
		{
			if(obj.GetComponent<SpriteRenderer>().color.Equals(defaultColor))
				obj.GetComponent<SpriteRenderer> ().color = changedColor;
			else
				obj.GetComponent<SpriteRenderer> ().color = defaultColor;
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

