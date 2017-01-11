using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Instruction;
using System.Threading;

namespace ObjectHierachy
{
	public enum Action
	{
		MOVE, JUMP, BREAK, STOP
	}

	public class CharacterStatus
	{
		private Queue pointQueue;
		private Stack pointStack;
		private Stack pointCursorStack;

		public Point CurrentPositionPoint {
			get;
			set;
		}

		public Vector3 CurrentPositionVector {
			get;
			set;
		}

		public Action action {
			get;
			set;
		}

		public Point NextPositionPoint
		{
			get{
				return pointQueue.Peek () as Point;
			}
		}

		public Instruction.INSTRUCTION direction {
			get;
			set;
		}

		/// <summary>
		/// Gets the queue which has next points.
		/// </summary>
		/// <value>The point queue.</value>
		public Queue PointQueue
		{
			get{ return this.pointQueue; }
		}

		/// <summary>
		/// Gets the stack which has previous points.
		/// </summary>
		/// <value>The point stack.</value>
		public Stack PointStack
		{
			get { return this.pointStack; }
		}

		public Stack PointCursorStack
		{
			get { return this.pointCursorStack; }
		}

		public Vector3 NextPositionVector
		{
			get {
				return Map.instance.positionParse (pointQueue.Peek () as Point);
			}
		}

		public CharacterStatus()
		{
			this.pointQueue = new Queue ();
			this.pointStack = new Stack ();
			this.pointCursorStack = new Stack ();
			this.action = Action.STOP;
		}

		public void clear()
		{
			this.pointQueue.Clear ();
			this.pointStack.Clear ();
			this.action = Action.STOP;
		}

		public override string ToString ()
		{
			return 
				"action : " + action.ToString () + "\n" +
			"direction : " + direction.ToString () + "\n";
		}
	}
}

