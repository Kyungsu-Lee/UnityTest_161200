using UnityEngine;
using System.Collections;
using System;

namespace  ObjectHierachy
{

	public static class Instruction
	{
		public const int START 	= 0x00;

		public const int ONE 	= 0x01;
		public const int TWO 	= 0x02;
		public const int THREE	= 0x03;
		public const int FOUR	= 0x04;
		public const int FIVE 	= 0x05;

		public const int UP 	= 0x06;
		public const int DOWN	= 0x07;
		public const int RIGHT	= 0x08;
		public const int LEFT	= 0x09;

		public const int MOVE	= 0x10;
		public const int JUMP	= 0x11;
		public const int BREAK	= 0x12;
	}

}