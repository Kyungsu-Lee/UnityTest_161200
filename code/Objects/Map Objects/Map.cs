using System;
using UnityEngine;

namespace ObjectHierachy
{
	public class Map
	{
		public static Map instance;
		private Block[][] blocks;

		public int size = 0;


		//property
		private float border {
			get;
			set;
		}


		// methods for Map
		public Map (Block block, int n, float size)
		{
			this.size = n;

			blocks = new Block[n][];
			for (int i = 0; i < n; i++)
				blocks [i] = new Block[n];

			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++) {
					Block _tmp = block.makeBlock ();
					_tmp.localscale = new Vector3 (size / (n * _tmp.localscale.x + (n - 1) / 80.0f), size / (n * _tmp.localscale.x + (n - 1) / 80.0f), _tmp.localscale.z);
					blocks [i] [j] = _tmp;
				}

			border = blocks [0] [0].length ()/80.0f;

			instance = this;
		}

		public void setPosition(float x, float y)
		{
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					blocks [i] [j].setPosition (x + (border + blocks[0][0].length())*i, y + (border + blocks[0][0].length())*j);
		}

		public Block get(int x, int y)
		{
			return blocks [x] [y];
		}

		public bool checkBound(int x, int y)
		{
			return (0 <= x && x < size && 0 <= y && y < size);
		}

		public bool checkBoundWithIndex(int index, int x, int y)
		{
			return checkBound(x, y) && (index == get(x,y).index);
		}

		public bool checkObtcle(int x, int y)
		{
			return (get (x, y).OnObject == null) || (get(x,y).OnObject != null && get(x,y).OnObject is Accessory);
		}

		public float Unitlength
		{
			get { return blocks [0] [0].localscale.x; }
		}

	}
}

