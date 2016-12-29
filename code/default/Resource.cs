using UnityEngine;
using Instruction;
using System.Collections;

namespace Instruction
{
public static class Resource {

		public static Instruction instruction = new Instructions();

		public delegate void FAILEVENT();

		public static FAILEVENT failEvent = null;
}
}
