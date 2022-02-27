using System.Numerics;

namespace Tanks_Game_Core
{
    public class RotateCommand : ICommand
	{
		public readonly GameObject GameObject;
		public readonly Vector3 RotateAngle;

		private Transform transform;

		public RotateCommand(GameObject gameObject, Vector3 rotateAngle)
		{
			this.GameObject = gameObject;
			this.RotateAngle = rotateAngle;
			this.transform = gameObject.GetComponent<Transform>();
		}

        public void Execute()
        {
            transform.Rotation += RotateAngle;
        }

        public void Undo()
        {
            transform.Rotation -= RotateAngle;
        }
    }
}
