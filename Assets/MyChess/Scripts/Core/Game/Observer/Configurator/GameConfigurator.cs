using System.Collections.Generic;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Dao.Def;

namespace MyChess.Scripts.Core.Game.Observer.Configurator
{
    public struct GameConfigurator : IGameConfigurator
    {
        #region GameConfigurator

        public GameConfigurator(IGameDef gameDef, IDictionary<GameTeam, IGameControl> controlByTeam)
        {
            GameDef = gameDef;
            ControlsByTeam = controlByTeam;
        }

        #endregion

        #region IGameConfigurator

        public IGameDef GameDef { get; }
        public IDictionary<GameTeam, IGameControl> ControlsByTeam { get; }

        #endregion
    }
}