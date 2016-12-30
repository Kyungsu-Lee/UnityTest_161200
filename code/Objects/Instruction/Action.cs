using System;

namespace Instruction
{
	public class Action : Instruction	//for move, jump, break
	{
		public Action (INSTRUCTION instruction)
		{
			if(instruction == INSTRUCTION.MOVE || instruction == INSTRUCTION.BREAK || instruction == INSTRUCTION.JUMP)
				this.instruction = instruction;
		}

		public Action(String instruction)
		{
			this.instruction = convert (instruction);
		}
			
			
		public override bool nextValid ()
		{
			return (instruction == INSTRUCTION.MOVE && next is Direction) || 
				(instruction != INSTRUCTION.MOVE && (next == null || next is Direction || next is Action));
		} 
	}
}

