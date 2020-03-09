using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Dao.Def;

namespace MyChess.Scripts.Core.Game.Observer.Configurator.Data
{
    public interface IGameConfiguratorData
    {
        #region IGameConfiguratorData

        IGameDef GameDef { get; }

        GameControlKind WhiteGameControl { get; }
        GameControlKind BlackGameControl { get; }

        #endregion
    }
}