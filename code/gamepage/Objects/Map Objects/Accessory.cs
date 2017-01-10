using System;
using UnityEngine;
using System.Collections;

namespace ObjectHierachy
{


	public class Accessory : MapObject
	{
		public static ArrayList accessory;
		public Vector3 initScale {
			get;
			set;
		}

		public Character Match {
			get;
			set;
		}

		public static int Count {
			get { return accessory.Count; }
		}

		public Accessory (Transform obj)
		{
			if(accessory == null)
			accessory = new ArrayList ();
			this.obj = obj;
			accessory.Add (this);
		}



	}
}

