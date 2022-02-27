using System;
using System.Numerics;
using NUnit.Framework;
using Tanks_Game_Core;

namespace Tanks_Game_Core___Tests
{
    [TestFixture]
    public class IoCScopesTests
    {
        [SetUp]
        public void SetUp()
        {
            IoC.SetRealization(new IoCContainer());
            IoC.SetScope("default");
        }

        [Test]
        public void ScopeCannotBeNull()
        {
            Assert.Throws<NullReferenceException>(() => IoC.SetScope(null));
        }
        
        [Test]
        public void BindInOneScopeDoesntShowsInAnother()
        {
            // Метод Bind добавляет новую стратегию в IoC-контейнер для конкретного скоупа, в другом скоупе этой стратегии нет.

            IoC.SetScope("UnrealTanks");
            Assert.False(IoC.IsBinded("Move"));
            IoC.Bind("Move", objects => new MoveCommand((GameObject) objects[0], (Vector3) objects[1]));
            Assert.True(IoC.IsBinded("Move"));
            
            IoC.SetScope("FueledTanks");
            Assert.False(IoC.IsBinded("Move"));
        }
        
        [Test]
        public void StrategyInOneScopeDoesntMatchStrategyInAnother()
        {
            // Стратегия в IoC-контейнер для одного скоупа, отличается от соответствующей стратегии в другом скоупе

            GameObject gameObject = new GameObject();
            Vector3 direction = Vector3.One;
            
            IoC.SetScope("UnrealTanks");
            IoC.Bind("Move", objects => new MoveCommand((GameObject) objects[0], (Vector3) objects[1]));
            
            IoC.SetScope("FueledTanks");
            IoC.Bind("Move", objects => new MoveAndBurnFuelCommand((GameObject) objects[0], (Vector3) objects[1]));

            IoC.SetScope("UnrealTanks");
            object MoveCommand = IoC.Resolve<ICommand>("Move", gameObject, direction);
            
            IoC.SetScope("FueledTanks");
            object MoveAndBurnCommand = IoC.Resolve<ICommand>("Move", gameObject, direction);
            
            Assert.That(MoveCommand.GetType(), Is.EqualTo(typeof(MoveCommand)));
            Assert.That(MoveAndBurnCommand.GetType(), Is.EqualTo(typeof(MoveAndBurnFuelCommand)));
        }
    }
}