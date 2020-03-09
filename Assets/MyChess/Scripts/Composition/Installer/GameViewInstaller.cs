using MyChess.Scripts.Composition.Configs;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Creator;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Display.Game.Board;
using MyChess.Scripts.Display.Game.Figure.Factory;
using MyChess.Scripts.Display.Game.Figure.Factory.Pool;
using MyChess.Scripts.Display.Game.Figure.View;
using MyChess.Scripts.Main.Decorator;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Composition.Installer
{
    [DisallowMultipleComponent]
    public sealed class GameViewInstaller : MonoInstaller
    {
        #region GameViewInstaller

        [SerializeField]
        private MainConfig _mainConfig;

        [SerializeField]
        private BoardView _boardView;

        [SerializeField]
        private Transform _poolParent;

        private void Awake()
        {
            _mainConfig.CheckNull();
            _boardView.CheckNull();
            _poolParent.CheckNull();
        }

        private void InstallFigureViewPool(IFigureDef figureDef, GameTeam figureTeam, GameObject figurePrefab)
        {
            Container.BindMemoryPool<FigureView, FigureViewPool>()
                .WithInitialSize(figureDef.PrefabInitialSize)
                .WithFactoryArguments(figureDef, figureTeam)
                .FromComponentInNewPrefab(figurePrefab)
                .UnderTransform(_poolParent)
                .NonLazy();
        }

        #endregion

        #region MonoInstaller

        public override void InstallBindings()
        {
            Container.Bind<IBoardView>().FromInstance(_boardView).AsSingle().NonLazy();

            Container.Bind<IFigureViewFactory>().To<FigureViewFactory>().AsSingle().NonLazy();

            foreach (var figureDef in _mainConfig.FigureDefs)
            {
                InstallFigureViewPool(figureDef, GameTeam.Black, figureDef.BlackPrefab);
                InstallFigureViewPool(figureDef, GameTeam.White, figureDef.WhitePrefab);
            }
            
            Container.Decorate<IFigureCreator>().With<FigureCreatorDecorator>().AsSingle().NonLazy();
        }

        #endregion
    }
}