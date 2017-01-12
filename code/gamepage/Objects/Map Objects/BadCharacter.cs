using System;
using UnityEngine;
using UnityEngine.UI;
using Instruction;

namespace ObjectHierachy
{
	public class BadCharacter : Obtacle
	{
		public bool Die {
			get;
			set;
		}

		public BadCharacter()
		{
			
		}

		public BadCharacter (Transform obj)
		{
			this.obj = obj;
			this.Die = false;
		}

		public override Obtacle createObtacle ()
		{
			Transform _tmp = MonoBehaviour.Instantiate (this.obj);
			return new BadCharacter (_tmp);
		}

		public void die()
		{
			this.Die = true;
			//this.obj.GetComponent<SpriteRenderer> ().sprite = Resource.deadCharacter;
		}
	}
}

