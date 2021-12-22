using System.Numerics;

namespace Tanks_Game_Core
{
    public class MoveCommand : ICommand
	{
		public readonly IMovable Movable;
		public readonly Vector3 Direction;

        public MoveCommand(IMovable movable, Vector3 direction)
		{
			this.Movable = movable;
			this.Direction = direction;
		}

		public void Execute()
		{
			Movable.Position += Direction;
		}

        public void Undo()
        {
			Movable.Position -= Direction;
		}
    }
}
