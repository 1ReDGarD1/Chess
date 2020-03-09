using MyChess.Scripts.Composition.Configs;
using MyChess.Scripts.Core.Figure.Dao.Repository;
using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Control.Kind;
using MyChess.Scripts.Core.Game.Control.Repository;
using MyChess.Scripts.Core.Game.Dao.Repository;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Composition.Installer
{
    [CreateAssetMenu(menuName = "MyChess/Config Installer")]
    public sealed class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        #region ConfigInstaller

        [SerializeField]
        private MainConfig _mainConfig;

        private void Awake()
        {
            _mainConfig.CheckNull();
        }

        private void InstallGameDefRepository()
        {
            var gameDefs = _mainConfig.GameDefs.CheckNull();
            Container.Bind<IGameDefRepository>().To<GameDefRepository>().AsSingle().WithArguments(gameDefs).NonLazy();

            foreach (var gameDef in gameDefs)
            {
                Container.QueueForInject(gameDef);
                Container.QueueForInject(gameDef.Validator);
            }
        }

        private void InstallFigureDefRepository()
        {
            var figureDefs = _mainConfig.FigureDefs.CheckNull();
            Container.Bind<IFigureDefRepository>().To<FigureDefRepository>().AsSingle().WithArguments(figureDefs)
                .NonLazy();
            
            foreach (var figureDef in figureDefs)
            {
                Container.QueueForInject(figureDef);

                foreach (var figureMoveTurnRules in figureDef.FigureMoveTurnRules)
                {
                    Container.QueueForInject(figureMoveTurnRules);
                }
                
                foreach (var figurePostTurnLogic in figureDef.FigurePostTurnLogics)
                {
                    Container.QueueForInject(figurePostTurnLogic);
                }
            }
        }
        
        private void InstallGameControl()
        {
            Container.Bind<IGameControlRepository>().To<GameControlRepository>().AsSingle().NonLazy();

            Container.Bind<IGameControl>().To<PlayerGameControl>().AsCached().NonLazy();
            Container.Bind<IGameControl>().To<AiRandomGameControl>().AsCached().NonLazy();
        }

        #endregion

        #region ScriptableObjectInstallerBase

        public override void InstallBindings()
        {
            InstallGameDefRepository();
            InstallFigureDefRepository();
            InstallGameControl();
        }

        #endregion
    }
}