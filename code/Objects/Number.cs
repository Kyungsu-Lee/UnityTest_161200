using System;

namespace Instruction
{
	public class Number : Instruction
	{
		public Number (INSTRUCTION instruction)
		{
			if(INSTRUCTION.ONE <= instruction && instruction <= INSTRUCTION.FIVE)
				this.instruction = instruction;
		}

		public Number(String instruction)
		{
			this.instruction = convert (instruction);
		}



		public override bool nextValid ()
		{
			return (before is Direction);
		} 

		public int count()
		{
			if (instruction == INSTRUCTION.ONE)
				return 1;
			else if (instruction == INSTRUCTION.TWO)
				return 2;
			else if (instruction == INSTRUCTION.THREE)
				return 3;
			else if (instruction == INSTRUCTION.FOUR)
				return 4;
			else if (instruction == INSTRUCTION.FIVE)
				return 5;
			else
				return 0;
		}
	}
}

