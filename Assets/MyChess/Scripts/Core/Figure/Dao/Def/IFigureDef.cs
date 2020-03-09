using System.Collections.Generic;
using MyChess.Scripts.Core.Figure.MoveTurnRules;
using MyChess.Scripts.Core.Figure.PostTurnLogic;
using MyChess.Scripts.Utility.Dao.Def;
using UnityEngine;

namespace MyChess.Scripts.Core.Figure.Dao.Def
{
    public interface IFigureDef : IBaseDef
    {
        #region IFigureDef

        GameObject WhitePrefab { get; }
        GameObject BlackPrefab { get; }

        int PrefabInitialSize { get; }

        IEnumerable<IFigureMoveTurnRules> FigureMoveTurnRules { get; }
        IEnumerable<IFigurePostTurnLogic> FigurePostTurnLogics { get; }

        #endregion
    }
}