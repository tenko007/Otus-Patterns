using System.Numerics;
using Tanks_Game_Core;

public class ChangeVelocityCommand : ICommand
{
    public readonly Transform Transform;
    public readonly Vector3 ChangeVelocityVector;

    public ChangeVelocityCommand(Transform transform, Vector3 changeVelocityVector)
    {
        this.Transform = transform;
        this.ChangeVelocityVector = changeVelocityVector;
    }
    
    public void Execute() =>
        Transform.Velocity += ChangeVelocityVector;

    public void Undo() =>
        Transform.Velocity -= ChangeVelocityVector;
}