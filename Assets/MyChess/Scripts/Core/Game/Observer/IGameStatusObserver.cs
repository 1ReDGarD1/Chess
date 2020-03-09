using MyChess.Scripts.Core.Game.Observer.Configurator.Data;

namespace MyChess.Scripts.Core.Game.Observer
{
    public interface IGameStatusObserver
    {
        #region IGameStatusObserver

        void StartGame(IGameConfiguratorData configuratorData);

        void EndGame();

        void RestartGame();

        #endregion
    }
}