using System;
using UnityEngine;

namespace ObjectHierachy
{
	public abstract class Obtacle : MapObject
	{

		public ObtacleKind obtacleKind {
			get;
			set;
		}

		public Obtacle()
		{
			
		}

		public Obtacle (Transform obj)
		{
			this.obj = obj;
		}

		public abstract Obtacle createObtacle();
	}
}

