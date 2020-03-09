using System;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Core.Game.Observer.Configurator;
using MyChess.Scripts.Core.Game.Observer.Configurator.Creator;
using MyChess.Scripts.Core.Game.Observer.Configurator.Data;
using MyChess.Scripts.Utility.Common;
using UnityEngine;

namespace MyChess.Scripts.Core.Game.Observer
{
    public sealed class GameStatusObserver : IGameStatusObserver
    {
        #region GameStatusObserver

        private readonly IGameConfiguratorCreator GameConfiguratorCreator;

        private readonly IGameComponentInitializable[] ComponentsInitializable;
        private readonly IGameComponentStarting[] ComponentsStarting;
        private readonly IGameComponentCompleted[] ComponentsEnding;

        private IGameConfigurator _curConfigurator;

        public GameStatusObserver(IGameConfiguratorCreator gameConfiguratorCreator,
            IGameComponentInitializable[] componentsInitializable,
            IGameComponentStarting[] componentsStarting,
            IGameComponentCompleted[] componentsEnding)
        {
            GameConfiguratorCreator = gameConfiguratorCreator.CheckNull();
            ComponentsInitializable = componentsInitializable.CheckNull();
            ComponentsEnding = componentsEnding.CheckNull();
            ComponentsStarting = componentsStarting.CheckNull();
        }

        private void StartGame(IGameConfigurator gameConfigurator)
        {
            Array.ForEach(ComponentsInitializable, component => component.GameInitialize(gameConfigurator));
            Array.ForEach(ComponentsStarting, component => component.GameStarting());
        }

        #endregion

        #region IGameStatusObserver

        public void StartGame(IGameConfiguratorData configuratorData)
        {
            _curConfigurator = GameConfiguratorCreator.Create(configuratorData);
            StartGame(_curConfigurator);
        }

        public void EndGame()
        {
            Array.ForEach(ComponentsEnding, component => component.GameComplete());
        }

        public void RestartGame()
        {
            if (_curConfigurator == null)
            {
                Debug.LogError("Can't restart game");
                return;
            }

            Debug.LogWarning("Restart game");

            EndGame();
            StartGame(_curConfigurator);
        }

        #endregion
    }
}