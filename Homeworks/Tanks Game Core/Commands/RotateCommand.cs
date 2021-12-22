
using System.Numerics;

namespace Tanks_Game_Core
{
    public class RotateCommand : ICommand
	{
		public readonly IRotatable Rotable;
		public readonly Vector3 RotateAngle;

		public RotateCommand(IRotatable rotable, Vector3 rotateAngle)
		{
			this.Rotable = rotable;
			this.RotateAngle = rotateAngle;
		}

        public void Execute()
        {
            Rotable.Rotation += RotateAngle;
        }

        public void Undo()
        {
            Rotable.Rotation -= RotateAngle;
        }
    }
}
