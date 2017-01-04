using System;
using UnityEngine;

namespace ObjectHierachy
{
	public class BadCharacter : Obtacle
	{
		public BadCharacter()
		{
			
		}

		public BadCharacter (Transform obj)
		{
			this.obj = obj;
		}

		public override Obtacle createObtacle ()
		{
			Transform _tmp = MonoBehaviour.Instantiate (this.obj);
			return new BadCharacter (_tmp);
		}
	}
}

