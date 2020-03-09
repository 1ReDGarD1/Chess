using System;
using MyChess.Scripts.Core.Game.Observer;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Core.Game.Observer.Configurator;
using MyChess.Scripts.Core.Game.Observer.Configurator.Creator;
using MyChess.Scripts.Core.Game.Observer.Configurator.Data;
using MyChess.Scripts.Display.Foundation.Manager;
using MyChess.Scripts.Display.Game.Board;
using MyChess.Scripts.Main.Decorator;
using NSubstitute;
using NUnit.Framework;

namespace MyChess.Tests.EditMode
{
    public class GameStatusObserverTests
    {
        #region GameStatusObserverTests

        private GameStatusObserver GameStatusObserver;
        private GameStatusObserverDecorator GameStatusObserverDecorator;
        private IGameConfiguratorCreator ConfiguratorCreator;

        private bool _resultCallInitializable;
        private bool _resultCallStarting;
        private bool _resultCallCompleted;

        [SetUp]
        public void SetUp()
        {
            //create components
            var componentInitializable = Substitute.For<IGameComponentInitializable>();
            componentInitializable.WhenForAnyArgs(component => component.GameInitialize(default)).Do(
                callInfo => { _resultCallInitializable = true; }
            );

            var componentStarting = Substitute.For<IGameComponentStarting>();
            componentStarting.WhenForAnyArgs(component => component.GameStarting()).Do(
                callInfo => { _resultCallStarting = true; }
            );

            var componentCompleted = Substitute.For<IGameComponentCompleted>();
            componentCompleted.WhenForAnyArgs(component => component.GameComplete()).Do(
                callInfo => { _resultCallCompleted = true; }
            );

            //create game service
            ConfiguratorCreator = Substitute.For<IGameConfiguratorCreator>();

            GameStatusObserver = new GameStatusObserver(ConfiguratorCreator,
                new[] {componentInitializable},
                new[] {componentStarting},
                new[] {componentCompleted}
            );

            //create game service proxy
            var boardView = Substitute.For<IBoardView>();
            var guiManager = Substitute.For<IGuiManager>();
            GameStatusObserverDecorator = new GameStatusObserverDecorator(GameStatusObserver, boardView, guiManager);
        }

        private void CallActionForGameServices(Action<IGameStatusObserver> action)
        {
            Action<IGameStatusObserver> curAction = gameService =>
            {
                _resultCallInitializable = false;
                _resultCallStarting = false;
                _resultCallCompleted = false;
            };
            curAction += action;

            curAction.Invoke(GameStatusObserver);
            curAction.Invoke(GameStatusObserverDecorator);
        }

        #endregion

        #region StartGame_TrackingCallMethods_MethodsCalled

        [Test]
        public void StartGame_TrackingCallMethods_MethodsInitializableAndStartingCalled()
        {
            CallActionForGameServices(gameService =>
            {
                gameService.StartGame(Substitute.For<IGameConfiguratorData>());

                Assert.IsTrue(_resultCallInitializable, "_resultCallInitializable == false");
                Assert.IsTrue(_resultCallStarting, "_resultCallStarting == false");
            });
        }

        #endregion

        #region EndGame_TrackingCallMethods_MethodsCalled

        [Test]
        public void EndGame_TrackingCallMethods_MethodsCalled()
        {
            CallActionForGameServices(gameService =>
            {
                gameService.EndGame();

                Assert.IsTrue(_resultCallCompleted, "_resultCallCompleted == false");
            });
        }

        #endregion

        #region RestartGame_TrackingCallMethods_MethodsCalled

        [Test]
        public void RestartGame_TrackingCallMethods_MethodsCalled()
        {
            ConfiguratorCreator.Create(default).ReturnsForAnyArgs(Substitute.For<IGameConfigurator>());

            CallActionForGameServices(gameService =>
            {
                gameService.StartGame(Substitute.For<IGameConfiguratorData>());
                gameService.RestartGame();

                Assert.IsTrue(_resultCallCompleted, "_resultCallCompleted == false");
                Assert.IsTrue(_resultCallInitializable, "_resultCallInitializable == false");
                Assert.IsTrue(_resultCallStarting, "_resultCallStarting == false");
            });
        }

        #endregion
    }
}