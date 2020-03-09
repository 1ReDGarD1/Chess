using System;
using MyChess.Scripts.Core.Board;
using MyChess.Scripts.Core.Board.Creator;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Figure.Controller;
using MyChess.Scripts.Core.Figure.Creator;
using MyChess.Scripts.Core.Figure.Model;
using MyChess.Scripts.Core.Figure.PostTurnLogic.Manager;
using MyChess.Scripts.Core.Game.Master;
using MyChess.Scripts.Core.Game.Model;
using MyChess.Scripts.Core.Game.MoveTurnManager;
using MyChess.Scripts.Core.Game.Observer;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Core.Game.Observer.Configurator.Creator;
using MyChess.Scripts.Core.Game.SwitcherTurn;
using MyChess.Scripts.Display.Game.Board.Model;
using MyChess.Scripts.Display.Game.Figure.Model;
using MyChess.Scripts.Main.Presenter;
using Zenject;

namespace MyChess.Scripts.Composition.Installer
{
    public sealed class CoreInstaller : Installer<CoreInstaller>
    {
        #region CoreInstaller

        private static readonly Type GameComponentStartingType = typeof(IGameComponentStarting);
        private static readonly Type GameComponentCompletedType = typeof(IGameComponentCompleted);
        private static readonly Type GameComponentInitializableType = typeof(IGameComponentInitializable);

        private void InstallModels()
        {
            Container.Bind(typeof(IGameModel), GameComponentCompletedType, GameComponentInitializableType)
                .To<GameModel>().AsSingle().NonLazy();
            Container.Bind(typeof(IBoardModel), GameComponentCompletedType).To<BoardModel>().AsSingle().NonLazy();
            Container.Bind(typeof(IFigureModel), GameComponentCompletedType).To<FigureModel>().AsSingle()
                .NonLazy();
            Container.Bind<IBoardViewModel>().To<BoardViewModel>().AsSingle().NonLazy();
            Container.Bind<IFigureViewModel>().To<FigureViewModel>().AsSingle().NonLazy();
        }

        private void InstallCreators()
        {
            Container.Bind<IBoardCreator>().To<BoardCreator>().AsSingle().NonLazy();
            Container.Bind<IFigureCreator>().To<FigureCreator>().AsSingle().NonLazy();
            Container.Bind<IGameConfiguratorCreator>().To<GameConfiguratorCreator>().AsSingle().NonLazy();
        }

        private void InstallGameEntity()
        {
            Container.Bind<IFigureController>().To<FigureController>().AsSingle().NonLazy();
            Container.Bind<IGameSwitcherTurn>().To<GameSwitcherTurn>().AsSingle().NonLazy();
            Container.Bind(typeof(IGameMaster), GameComponentStartingType).To<GameMaster>().AsSingle().NonLazy();
            Container.Bind<IGameStatusObserver>().To<GameStatusObserver>().AsSingle().NonLazy();
            Container.Bind<IFigurePostTurnLogicManager>().To<FigurePostTurnLogicManager>().AsSingle().NonLazy();
            Container.Bind(typeof(IGameMoveTurnManager), GameComponentCompletedType).To<GameMoveTurnManager>()
                .AsSingle().NonLazy();
        }

        private void InstallPresenters()
        {
            Container.Bind(GameComponentInitializableType).To<BoardPreparation>().AsSingle().NonLazy();
            Container.Bind(GameComponentStartingType, GameComponentCompletedType).To<GamePresenter>().AsCached()
                .NonLazy();
            Container.Bind(GameComponentStartingType, GameComponentCompletedType).To<FigurePresenter>().AsCached()
                .NonLazy();
        }

        #endregion

        #region MonoInstaller

        public override void InstallBindings()
        {
            InstallModels();
            InstallCreators();
            InstallGameEntity();
            InstallPresenters();
        }

        #endregion
    }
}