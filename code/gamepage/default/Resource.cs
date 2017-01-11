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
		public static Vector3[] starPosition;

		public static INSTRUCTION currentDirection;
		public static bool instructionInput = false;

		public static ArrayList COLORS = new ArrayList ();

		public static bool canClear = true;
		public static bool movStar = false;
		public static bool[] movRuby;

		public static UnityEngine.GameObject[] characters;
		public static GameObject[] stars;
		public static GameObject ring;

		public static int stage;
		public static Color clearedColor;

		public static Sprite deadCharacter;

		public static Sprite[][] Accessories;

		public static void clear()
		{
			character = null;
			starPosition = null;
			canClear = true;
			movStar = false;
			movRuby = null;
			characters = null;
			stars = null;
			ring = null;
			MapObject.ALLOBJECT = new ArrayList();
			Character.characters = new ArrayList ();
			Accessory.accessory = new ArrayList ();
			CharacterErrorEvent.error_brk = false;
			CharacterErrorEvent.error_jmp = false;
			CharacterErrorEvent.error_mov = false;
			instructionInput = false;
			CharacterJumpUpEvent.start = false;
		}

		public static string previousScene = "";
}
}
