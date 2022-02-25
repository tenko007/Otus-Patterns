using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Tanks_Game_Core;

[TestFixture]
public class ChangeVelocityCommandTests
{
    [Test]
    public void ChangeVelocityCommandChangesVelocity()
    {
        // Вызов команды изменяет velocity

        Transform transform = new Transform();
        ChangeVelocityCommand changeVelocityCommand = new ChangeVelocityCommand(transform, Vector3.One);
        
        changeVelocityCommand.Execute();
        Assert.AreEqual(transform.Velocity, Vector3.One);
        
        changeVelocityCommand.Execute();
        Assert.AreEqual(transform.Velocity, Vector3.One * 2);
    }

    [Test]
    public void ChangeVelocityToObjectWithNoTransformReturnsException()
    {
        // Попытка изменить velocity у объекта, у которого невозможно прочитать положение в пространстве, приводит к ошибке

        GameObject tank = new GameObject();

        Transform tankTransform = tank.GetComponent<Transform>();
        Vector3 velocity = new Vector3(-7, 3, 0);

        ICommand changeVelocityCommand = new ChangeVelocityCommand(tankTransform, velocity);

        Assert.Throws<NullReferenceException>(() => changeVelocityCommand.Execute());
        Assert.Throws<NullReferenceException>(() => tankTransform.Velocity = new Vector3(12, 5, 0));
    }

    [Test]
    public void ChangeVelocityToGameObjectWithNanPositionReturnsException()
    {
        // Попытка изменить velocity объекта на нечисловое значение приводит к ошибке

        GameObject tank = new GameObject();
        tank.AddComponent(new Transform());

        Transform tankTransform = tank.GetComponent<Transform>();

        float[] nans = new float[3] { float.NaN, float.PositiveInfinity, float.NegativeInfinity };
        List<Vector3> nanVectors = new List<Vector3>();

        foreach (float nan in nans)
        {
            nanVectors.Add(new Vector3(1, 0, 0) * nan);
            nanVectors.Add(new Vector3(0, 1, 0) * nan);
            nanVectors.Add(new Vector3(0, 0, 1) * nan);
        }

        foreach (Vector3 nanVector in nanVectors)
        {
            var changeVelocityCommand = new ChangeVelocityCommand(tankTransform, nanVector);
            Assert.Throws<ArgumentOutOfRangeException>(() => changeVelocityCommand.Execute());
            Assert.Throws<ArgumentOutOfRangeException>(() => tankTransform.Velocity = nanVector);
        }
    }
}