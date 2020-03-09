using System.Collections.Generic;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;

namespace MyChess.Scripts.Core.Figure.MoveTurnRules
{
    public interface IFigureMoveTurnRules
    {
        #region IFigureMoveTurnRules

        ICollection<IGameMoveTurnData> CalculateMoveTurnData(IFigureEntity movableFigure);

        #endregion
    }
}