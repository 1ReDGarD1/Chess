using System.Collections.Generic;
using MyChess.Scripts.Utility.Dao.Repository;

namespace MyChess.Scripts.Core.Game.Control.Repository
{
    public sealed class GameControlRepository : DefRepository<IGameControl, GameControlKind>, IGameControlRepository
    {
        #region GameControlRepository

        public GameControlRepository(IEnumerable<IGameControl> defs) : base(defs)
        {
        }

        #endregion
    }
}