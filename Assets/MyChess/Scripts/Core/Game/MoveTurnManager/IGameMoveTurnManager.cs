using System.Collections.Generic;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;

namespace MyChess.Scripts.Core.Game.MoveTurnManager
{
    public interface IGameMoveTurnManager
    {
        #region IGameMoveTurnManager

        IEnumerable<IGameMoveTurnData> CalculateMovesTurn(IFigureEntity movableFigure);

        IFigureEntity GetRemovedFigure(IBoardCell moveToCell);

        #endregion
    }
}