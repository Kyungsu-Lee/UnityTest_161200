using System;
using UnityEngine;

namespace ObjectHierachy
{
	public class Accessory : MapObject
	{
		public Accessory (Transform obj)
		{
			this.obj = obj;
		}

		public Obtacle createObtacle()
		{
			Transform _tmp = MonoBehaviour.Instantiate (this.obj);
			return new Obtacle (_tmp);
		}
	}
}

