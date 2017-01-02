using System;

namespace Instruction
{
	public class Direction : Instruction
	{
		public Direction (INSTRUCTION instruction)
		{
			if(INSTRUCTION.UP <= instruction && instruction <= INSTRUCTION.RIGHT)
				this.instruction = instruction;
		}

		public Direction(String instruction)
		{
			this.instruction = convert (instruction);
		}
			

		public override bool nextValid ()
		{
			return (before is Action) && (next is Number);
		} 
	}
}

