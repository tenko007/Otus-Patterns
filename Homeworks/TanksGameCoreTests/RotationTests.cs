using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;
using Tanks_Game_Core;

namespace Tanks_Game_Core___Tests
{
    [TestFixture]
    public class RotationTests
    {
        [Test]
        public void TestRotateGameObjectChangesRotation()
        {

            GameObject tank = new GameObject();
            tank.AddComponent(new Transform());

            Transform tankTransform = tank.GetComponent<Transform>();
            tankTransform.Rotation = new Vector3(12, 5, 0);
            Vector3 RotationAngle = new Vector3(-7, 3, 0);

            ICommand rotateCommand = new RotateCommand(tank, RotationAngle);
            rotateCommand.Execute();

            Assert.That(tankTransform.Rotation, Is.EqualTo(new Vector3(5, 8, 0)));
        }

        [Test]
        public void TestMoveGameObjectWithNoTransformReturnsException()
        {
            // Попытка повернуть объект, у которого невозможно прочитать текущий угол поворота в пространстве, приводит к ошибке

            GameObject tank = new GameObject();

            Transform tankTransform = tank.GetComponent<Transform>();
            Vector3 RotationAngle = new Vector3(-7, 3, 0);

            ICommand rotateCommand = new RotateCommand(tank, RotationAngle);

            Assert.Throws<NullReferenceException>(() => rotateCommand.Execute());
            Assert.Throws<NullReferenceException>(() => tankTransform.Rotation = new Vector3(12, 5, 0));
        }

        [Test]
        public void TestMoveGameObjectWithNanPositionReturnsException()
        {
            // Попытка изменить угол поворота объекта на нечисловое значение приводит к ошибке

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
                RotateCommand rotateCommand = new RotateCommand(tank, nanVector);
                Assert.Throws<ArgumentOutOfRangeException>(() => rotateCommand.Execute());
                Assert.Throws<ArgumentOutOfRangeException>(() => tankTransform.Rotation = nanVector);
            }
        }
    }
}
