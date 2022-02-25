namespace Tanks_Game_Core
{
    class MacroCommand : ICommand
	{
		ICommand[] commands;

		public MacroCommand(ICommand[] cmds)
		{
			this.commands = cmds;
		}

		public void Execute()
		{
			foreach (ICommand command in commands)
			{
				command.Execute();
			}
		}

        public void Undo()
        {
			for (int i = commands.Length - 1; i >= 0; i--) 
			{
				commands[i].Undo();
			}
		}
    }
}
