using System;
using UnityEngine;
using System.Collections;

namespace ObjectHierachy
{


	public class Accessory : MapObject
	{
		public static ArrayList accessory = new ArrayList();

		public Character Match {
			get;
			set;
		}

		public static int Count {
			get { return accessory.Count; }
		}

		public Accessory (Transform obj)
		{
			this.obj = obj;
			accessory.Add (this);
		}

		public Obtacle createObtacle()
		{
			Transform _tmp = MonoBehaviour.Instantiate (this.obj);
			return new Obtacle (_tmp);
		}


	}
}

