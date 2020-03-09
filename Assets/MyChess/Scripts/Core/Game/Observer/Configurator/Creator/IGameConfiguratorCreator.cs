using MyChess.Scripts.Core.Game.Observer.Configurator.Data;

namespace MyChess.Scripts.Core.Game.Observer.Configurator.Creator
{
    public interface IGameConfiguratorCreator
    {
        #region IGameConfiguratorCreator

        IGameConfigurator Create(IGameConfiguratorData configuratorData);

        #endregion
    }
}