using System;

namespace Tanks_Game_Core
{
    public class ErrorCommand : ICommand
    {
        public void Execute() =>
            throw new Exception();

        public void Undo() { }
    }
}