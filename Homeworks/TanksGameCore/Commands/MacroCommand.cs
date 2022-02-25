using System;
using System.Collections.Generic;

namespace Tanks_Game_Core
{
	public class MacroCommand : ICommand
	{
		private ICommand[] commands;
		private List<ICommand> executedCommands;
		public int CommandsCount => commands.Length;

		public MacroCommand(ICommand[] cmds)
		{
			this.commands = cmds;
			executedCommands = new List<ICommand>();
		}

		public void Execute()
		{
			foreach (ICommand command in commands)
			{
				try
				{
					command.Execute();
					executedCommands.Add(command);
				}
				catch (Exception e)
				{
					throw new CommandException(command, e);
				}
			}
		}

		public void Undo()
		{
			for (int i = executedCommands.Count - 1; i >= 0; i--)
				commands[i].Undo();
		}
	}
}