using System.Text;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Game.MoveTurnManager.Data
{
    public struct GameMoveTurnData : IGameMoveTurnData
    {
        #region GameMoveTurnData

        public static readonly IGameMoveTurnData Empty = new GameMoveTurnData();

        public GameMoveTurnData(IBoardCell moveToCell, IFigureEntity removedFigure)
        {
            MoveToCell = moveToCell;
            RemovedFigure = removedFigure;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Move to cell:{MoveToCell}");

            var removedFigureText = HasRemovedFigure ? RemovedFigure.ToString() : "isEmpty";
            stringBuilder.Append($", removed figure:{removedFigureText}");

            return stringBuilder.ToString();
        }

        #endregion

        #region IGameMoveTurnData

        public IBoardCell MoveToCell { get; }
        public IFigureEntity RemovedFigure { get; }

        public bool HasRemovedFigure => RemovedFigure != null;
        
        public bool IsEmpty => MoveToCell == null && RemovedFigure == null;

        #endregion
    }
}