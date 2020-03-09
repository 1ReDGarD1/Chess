using System.Collections.Generic;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Dao.Def;

namespace MyChess.Scripts.Core.Game.Observer.Configurator
{
    public interface IGameConfigurator
    {
        #region IGameConfigurator

        IGameDef GameDef { get; }

        IDictionary<GameTeam, IGameControl> ControlsByTeam { get; }

        #endregion
    }
}