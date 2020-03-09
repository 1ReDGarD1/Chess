using System.Collections.Generic;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Control.Repository;
using MyChess.Scripts.Core.Game.Observer.Configurator.Data;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Core.Game.Observer.Configurator.Creator
{
    public sealed class GameConfiguratorCreator : IGameConfiguratorCreator
    {
        #region GameConfiguratorCreator

        private readonly IGameControlRepository GameControlRepository;

        public GameConfiguratorCreator(IGameControlRepository gameControlRepository)
        {
            GameControlRepository = gameControlRepository.CheckNull();
        }

        #endregion

        #region IGameConfiguratorCreator

        public IGameConfigurator Create(IGameConfiguratorData configuratorData)
        {
            var controlByTeam = new Dictionary<GameTeam, IGameControl>
            {
                {
                    GameTeam.White, GameControlRepository.GetDef(configuratorData.WhiteGameControl)
                },
                {
                    GameTeam.Black, GameControlRepository.GetDef(configuratorData.BlackGameControl)
                }
            };

            return new GameConfigurator(configuratorData.GameDef, controlByTeam);
        }

        #endregion
    }
}