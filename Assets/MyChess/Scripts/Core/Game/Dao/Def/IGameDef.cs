using System.Collections.Generic;
using MyChess.Scripts.Core.Game.Validator;
using MyChess.Scripts.Utility.Dao.Def;

namespace MyChess.Scripts.Core.Game.Dao.Def
{
    public interface IGameDef : IBaseDef
    {
        #region IGameDef

        IEnumerable<IStartInfoFigureDef> StartInfoFigureDefs { get; }

        IResultGameValidator Validator { get; }

        #endregion
    }
}