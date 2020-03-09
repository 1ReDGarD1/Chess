using System;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Board.Cell
{
    public interface IBoardCell
    {
        #region IBoardCell

        event EventHandler<BoardCellStatus> OnChangeStatus;

        int IndexX { get; }
        int IndexY { get; }

        BoardCellCol Col { get; }
        BoardCellRow Row { get; }

        IFigureEntity Figure { get; set; }
        BoardCellStatus Status { get; set; }

        bool IsBusy { get; }

        bool Equals(BoardCellCol col, BoardCellRow row);

        void Clear();

        #endregion
    }
}