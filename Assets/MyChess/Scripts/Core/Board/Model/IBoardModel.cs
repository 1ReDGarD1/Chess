using System.Collections.Generic;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Enum;

namespace MyChess.Scripts.Core.Board.Model
{
    public interface IBoardModel
    {
        #region IBoardModel

        IEnumerable<IBoardCell> Cells { get; }

        void SetCells(IBoardCell[,] cells);

        IBoardCell GetCell(BoardCellCol col, BoardCellRow row);
        IBoardCell GetCell(int indexX, int indexY);

        #endregion
    }
}