using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Game.MoveTurnManager.Data
{
    public interface IGameMoveTurnData
    {
        #region IGameMoveTurnData

        IBoardCell MoveToCell { get; }
        IFigureEntity RemovedFigure { get; }

        bool HasRemovedFigure { get; }

        bool IsEmpty { get; }

        #endregion
    }
}