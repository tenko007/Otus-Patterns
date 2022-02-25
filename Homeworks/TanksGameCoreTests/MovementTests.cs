using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;
using Tanks_Game_Core;

namespace Tanks_Game_Core___Tests
{
    [TestFixture]
    public class MovementTests
    {
        [Test]
        public void TestMoveGameObjectChangesPosition()
        {
            // Для объекта, находящегося в точке (12, 5) и движущегося со скоростью (-7, 3) движение меняет положение объекта на (5, 8)

            GameObject tank = new GameObject();
            tank.AddComponent(new Transform());

            Transform tankTransform = tank.GetComponent<Transform>();
            tankTransform.Position = new Vector3(12, 5, 0);
            Vector3 velocity = new Vector3(-7, 3, 0);

            ICommand moveCommand = new MoveCommand(tankTransform, velocity);
            moveCommand.Execute();

            Assert.That(tankTransform.Position, Is.EqualTo(new Vector3(5, 8, 0)));
        }

        [Test]
        public void TestMoveGameObjectWithNoTransformReturnsException()
        {
            // Попытка сдвинуть объект, у которого невозможно прочитать положение в пространстве, приводит к ошибке

            GameObject tank = new GameObject();

            Transform tankTransform = tank.GetComponent<Transform>();
            Vector3 velocity = new Vector3(-7, 3, 0);

            ICommand moveCommand = new MoveCommand(tankTransform, velocity);

            Assert.Throws<NullReferenceException>(() => moveCommand.Execute());
            Assert.Throws<NullReferenceException>(() => tankTransform.Position = new Vector3(12, 5, 0));
        }

        [Test]
        public void TestMoveGameObjectWithNanPositionReturnsException()
        {
            // Попытка изменить положение объекта на нечисловое значение приводит к ошибке

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
                MoveCommand moveCommand = new MoveCommand(tankTransform, nanVector);
                Assert.Throws<ArgumentOutOfRangeException>(() => moveCommand.Execute());
                Assert.Throws<ArgumentOutOfRangeException>(() => tankTransform.Position = nanVector);
            }
        }
    }
}
