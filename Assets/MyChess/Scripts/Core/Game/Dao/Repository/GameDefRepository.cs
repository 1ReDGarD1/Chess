using System.Collections.Generic;
using MyChess.Scripts.Core.Game.Dao.Def;
using MyChess.Scripts.Utility.Dao.Repository;

namespace MyChess.Scripts.Core.Game.Dao.Repository
{
    public sealed class GameDefRepository : BaseDefRepository<IGameDef>, IGameDefRepository
    {
        #region GameDefRepository

        public GameDefRepository(IEnumerable<IGameDef> defs) : base(defs)
        {
        }

        #endregion
    }
}