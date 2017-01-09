using System;
using UnityEngine;

namespace ObjectHierachy
{
	public class UnMovableObtacle : Obtacle
	{


		public UnMovableObtacle ()
		{
		}

		public UnMovableObtacle (Transform obj, ObtacleKind ok)
		{
			this.obj = obj;
			this.obtacleKind = ok;
		}

		public override Obtacle createObtacle ()
		{
			Transform _tmp = MonoBehaviour.Instantiate (this.obj);
			return new UnMovableObtacle (_tmp, this.obtacleKind);
		}

	}
}

