using System;

namespace Tanks_Game_Core
{
    public interface ICommand
	{
		public void Execute();
		public void Undo();
	}
}
