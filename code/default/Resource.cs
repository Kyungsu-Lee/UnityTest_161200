using UnityEngine;
using Instruction;
using System.Collections;
using ObjectHierachy;

namespace Instruction
{
public static class Resource {

		public static Instruction instruction = new Instructions();

		public delegate void FAILEVENT();

		public static FAILEVENT failEvent = null;

		public static Character character;
		public static UnityEngine.GameObject[] characters;
		public static GameObject[] stars;
		public static Vector3[] starPosition;

		public static INSTRUCTION currentDirection;
		public static bool canClear = true;
		public static bool movStar = false;

		public static ArrayList COLORS = new ArrayList ();

}
}
