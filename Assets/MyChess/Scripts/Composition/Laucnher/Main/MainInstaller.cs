using MyChess.Scripts.Composition.Installer;
using MyChess.Scripts.Core.Game.Observer;
using MyChess.Scripts.Main.Decorator;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Composition.Laucnher.Main
{
    [DisallowMultipleComponent]
    public sealed class MainInstaller : MonoInstaller
    {
        #region MonoInstallerBase

        public override void InstallBindings()
        {
            CoreInstaller.Install(Container);

            Container.Decorate<IGameStatusObserver>().With<GameStatusObserverDecorator>().AsSingle().NonLazy();

            Container.Bind<IInitializable>().To<MainInitializable>().AsSingle().NonLazy();
        }

        #endregion
    }
}