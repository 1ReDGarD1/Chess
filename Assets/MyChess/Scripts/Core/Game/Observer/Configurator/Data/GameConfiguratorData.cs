using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Dao.Def;

namespace MyChess.Scripts.Core.Game.Observer.Configurator.Data
{
    public struct GameConfiguratorData : IGameConfiguratorData
    {
        #region GameConfiguratorData

        public GameConfiguratorData(IGameDef gameDef,
            GameControlKind whiteGameControl,
            GameControlKind blackGameControl)
        {
            GameDef = gameDef;
            WhiteGameControl = whiteGameControl;
            BlackGameControl = blackGameControl;
        }

        #endregion

        #region IGameConfiguratorData

        public IGameDef GameDef { get; }
        public GameControlKind WhiteGameControl { get; }
        public GameControlKind BlackGameControl { get; }

        #endregion
    }
}