using System;
using UnityEngine;

namespace ObjectHierachy
{
	public delegate void BlockAction(Block block);

	public class Map
	{
		public static Map instance;
		private Block[][] blocks;

		public int size = 0;
		public float unitSize = 0;

		public BlockAction blockAction = ((block) => {});


		//property
		private float border {
			get;
			set;
		}
			
		public float Length
		{
			get { return (size - 1) * border + size * unitSize; }
		}

		// methods for Map
		public Map (Block block, int numOfBlocks, float totalSize, float border)
		{
			this.size = numOfBlocks;
			this.border = border;

			blocks = new Block[numOfBlocks][];
			for (int i = 0; i < numOfBlocks; i++)
				blocks [i] = new Block[numOfBlocks];


			for (int i = 0; i < numOfBlocks; i++)
				for (int j = 0; j < numOfBlocks; j++) {
					Block _tmp = block.makeBlock ();
					//_tmp.localscale = new Vector3 (size / (n * _tmp.localscale.x + (n - 1) / 80.0f), size / (n * _tmp.localscale.x + (n - 1) / 80.0f), _tmp.localscale.z);
					_tmp.localscale = new Vector3 ( totalSize/( (1+border) * numOfBlocks - border), totalSize/( (1+border) * numOfBlocks - border), _tmp.localscale.z);
					_tmp.canOn = true;
					blocks [i] [j] = _tmp;
				}

			unitSize = totalSize / ((1 + border) * numOfBlocks - border);

			instance = this;
		}

		public void setPosition(float x, float y)
		{

			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					blocks [i] [j].setPosition (x + blocks[0][0].length()*(border + 1)*i, y + blocks[0][0].length()*(border + 1)*j);
		}

		public void setPositionAtCenter(float x, float y)
		{
				setPosition (x + unitSize/2 - Length/2, y + unitSize/2 - Length/2 );
		}

		public Block get(int x, int y)
		{
			return blocks [x] [y];
		}

		public Block get(Point p)
		{
			return get (p.x, p.y);
		}

		public bool checkBound(int x, int y)
		{
			return (0 <= x && x < size && 0 <= y && y < size) && get(x,y).canOn;
		}

		public bool checkBound(Point p)
		{
			return checkBound (p.x, p.y);
		}

		public bool checkBoundWithIndex(int index, int x, int y)
		{
			return checkBound(x, y) && (index == get(x,y).index) && get(x,y).canOn;
		}

		public bool checkObtcle(int x, int y)
		{
			return (get (x, y).OnObject == null) || (get(x,y).OnObject != null && get(x,y).OnObject is Accessory);
		}

		/// <summary>
		/// Gets the length of a block.
		/// </summary>
		/// <value>The unitlength.</value>
		public float Unitlength
		{
			get { return blocks [0] [0].localscale.x; }
		}

		public void allBlockAction()
		{
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					blockAction (get (i, j));
		}

		public Vector3 positionParse(Point p)
		{
			return get (p.x, p.y).obj.GetComponent<Transform> ().position;
		}

	}
}

