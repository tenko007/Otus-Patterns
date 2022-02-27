using System.Numerics;

namespace Tanks_Game_Core
{
    public class MoveCommand : ICommand
	{
		public readonly GameObject GameObject;
		public readonly Vector3 Direction;

		private Transform transform;

        public MoveCommand(GameObject gameObject, Vector3 direction)
		{
			this.GameObject = gameObject;
			this.Direction = direction;
			this.transform = gameObject.GetComponent<Transform>();
		}

		public void Execute()
		{
			transform.Position += Direction;
		}

        public void Undo()
        {
			transform.Position -= Direction;
		}
    }
}
