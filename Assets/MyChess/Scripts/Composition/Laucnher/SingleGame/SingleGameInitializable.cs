using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Dao.Def;
using MyChess.Scripts.Core.Game.Observer;
using MyChess.Scripts.Core.Game.Observer.Configurator.Data;
using MyChess.Scripts.Utility.Common;
using Zenject;

namespace MyChess.Scripts.Composition.Laucnher.SingleGame
{
    public sealed class SingleGameInitializable : IInitializable
    {
        #region SingleGameInitializable

        private readonly IGameStatusObserver GameStatusObserver;

        private readonly IGameDef GameDef;

        public SingleGameInitializable(IGameStatusObserver gameStatusObserver, IGameDef gameDef)
        {
            GameStatusObserver = gameStatusObserver.CheckNull();
            GameDef = gameDef.CheckNull();
        }

        #endregion

        #region IInitializable

        public void Initialize()
        {
            var configuratorData = new GameConfiguratorData(GameDef, GameControlKind.Player, GameControlKind.RandomAi);
            GameStatusObserver.StartGame(configuratorData);
        }

        #endregion
    }
}