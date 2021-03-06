using HW1___QuadraticEquation;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HW1___Unit_Tests
{
    [TestFixture]
    public class QuadraticEquationTests
    {
        [Test]
        public void TestEquationReturnsNoRoots()
        {
            //Написать тест, который проверяет, что для уравнения x^2 + 1 = 0 корней нет(возвращается пустой массив)
            QuadraticEquation equation = new QuadraticEquation(1, 0, 1);
            List<double> result = equation.Solve();
            Assert.IsTrue(result.Count == 0);
        }

        [Test]
        public void TestEquationReturnsOneRoot()
        {
            //Написать тест, который проверяет, что для уравнения x^2-1 = 0 есть два корня кратности 1 (x1=1, x2=-1)
            QuadraticEquation equation = new QuadraticEquation(1, 0, -1);
            List<double> result = equation.Solve();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Contains(1) && result.Contains(-1));

        }

        [Test]
        public void TestEquationReturnsTwoRoots()
        {
            //Написать тест, который проверяет, что для уравнения x^2+2x+1 = 0 есть один корень кратности 2 (x1= x2 = -1).
            QuadraticEquation equation = new QuadraticEquation(1, 2, 1);
            List<double> result = equation.Solve();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.IsTrue(result[0] == -1);
        }


        [Test]
        public void TestFirstCoefficientCannotBeZero()
        {
            //Написать тест, который проверяет, что коэффициент a не может быть равен 0. В этом случае solve выбрасывает исключение. 
            QuadraticEquation equation = new QuadraticEquation(0, 1, 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => equation.Solve());
        }

        [Test]
        public void TestDiscriminantLessThanEpsilon()
        {
            //С учетом того, что дискриминант тоже нельзя сравнивать с 0 через знак равенства,
            //подобрать такие коэффициенты квадратного уравнения для случая одного корня кратности два,
            //чтобы дискриминант был отличный от нуля, но меньше заданного эпсилон.

            double a = 1, c = 0;
            double discriminant = double.Epsilon / 2;
            double b = Math.Sqrt(discriminant);

            QuadraticEquation equation = new QuadraticEquation(a, b, c);
            List<double> result = equation.Solve();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.Contains(0));
        }

        public void TestNanReturnsException()
        {
            //Посмотреть какие еще значения могут принимать числа типа double,
            //кроме числовых и написать тест с их использованием на все коэффициенты. solve должен выбрасывать исключение.

            QuadraticEquation equation;
            double[] nans = new double[] { double.NegativeInfinity, double.PositiveInfinity, double.NaN };

            foreach (double nan in nans)
            {
                equation = new QuadraticEquation(nan, 1, 1);
                Assert.Throws<ArgumentOutOfRangeException>(() => equation.Solve());

                equation = new QuadraticEquation(1, nan, 1);
                Assert.Throws<ArgumentOutOfRangeException>(() => equation.Solve());

                equation = new QuadraticEquation(1, 1, nan);
                Assert.Throws<ArgumentOutOfRangeException>(() => equation.Solve());
            }
        }
    }
}
