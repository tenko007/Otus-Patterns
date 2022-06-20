using System.Numerics;

public interface IMovable
{
    Vector3 getPosition();
    Vector3 setPosition(Vector3 newValue);
    Vector3 getVelocity();
    void finish(); 
}