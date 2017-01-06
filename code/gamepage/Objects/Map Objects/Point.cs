using System;

namespace ObjectHierachy
{
	public class Point
	{
		public int x {
			get;
			set;
		}

		public int y {
			get;
			set;
		}

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override string ToString ()
		{
			return string.Format ("[Point: x={0}, y={1}]", x, y);
		}
	}
}

