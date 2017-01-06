using System;

namespace Instruction
{
	public class Instructions : Instruction     //just for init
	{
		public Instructions()
		{
			this.instruction = INSTRUCTION.NULL;
		}

		public override bool nextValid()
		{
			return true;
		}

	}
}

