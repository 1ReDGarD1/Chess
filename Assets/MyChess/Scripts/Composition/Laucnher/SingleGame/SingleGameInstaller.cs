using MyChess.Scripts.Composition.Installer;
using MyChess.Scripts.Core.Game.Dao.Def;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Composition.Laucnher.SingleGame
{
    [DisallowMultipleComponent]
    public sealed class SingleGameInstaller : MonoInstaller
    {
        #region SingleGameInstaller

        [SerializeField]
        private GameDefSO _gameDef;

        #endregion

        #region MonoInstallerBase

        public override void InstallBindings()
        {
            CoreInstaller.Install(Container);

            IGameDef gameDef = _gameDef;
            Container.Bind<IInitializable>().To<SingleGameInitializable>().AsSingle().WithArguments(gameDef).NonLazy();
        }

        #endregion
    }
}