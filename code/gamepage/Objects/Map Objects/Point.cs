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

		public Point(Point p)
		{
			this.x = p.x;
			this.y = p.y;
		}

		public override string ToString ()
		{
			return string.Format ("[Point: x={0}, y={1}]", x, y);
		}

		public static Point operator+(Point p, Point q)
		{
			return new Point (p.x + q.x, p.y + q.y);
		}

		public static Point operator-(Point p, Point q)
		{
			return new Point (p.x - q.x, p.y - q.y);
		}

		public static Point operator*(int n, Point p)
		{
			return new Point (p.x * n, p.y * n);
		}

		public Point unitPoint()
		{
			if (x != 0 && y != 0)
				return new Point (x / Math.Abs(x), y / Math.Abs(y));
			else if (x != 0)
				return new Point (x / Math.Abs(x), 0);
			else if (y != 0)
				return new Point (0, y / Math.Abs(y));
			else
				return new Point (0, 0);
		}

		public override bool Equals (object obj)
		{
			if (!(obj is Point))
				return false;

			Point p = obj as Point;

			return (this.x == p.x) && (this.y == p.y);
		}
	}
}

