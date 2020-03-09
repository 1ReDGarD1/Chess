using System;
using System.Text;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Board.Cell
{
    public sealed class BoardCell : IBoardCell
    {
        #region BoardCell

        private BoardCellStatus _status;

        public BoardCell(BoardCellCol col, BoardCellRow row, int indexX, int indexY)
        {
            Col = col;
            Row = row;
            IndexX = indexX;
            IndexY = indexY;
            Status = BoardCellStatus.Empty;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("Cell");
            stringBuilder.Append($" {Col}, {Row}");
            stringBuilder.Append($", index X:{IndexX} Y:{IndexY}");
            stringBuilder.Append($", isBusy:{IsBusy}");
            stringBuilder.Append($", status:{Status}");
            return stringBuilder.ToString();
        }

        #endregion

        #region IBoardCell

        public event EventHandler<BoardCellStatus> OnChangeStatus;

        public int IndexX { get; }
        public int IndexY { get; }
        
        public BoardCellCol Col { get; }
        public BoardCellRow Row { get; }

        public IFigureEntity Figure { get; set; }

        public BoardCellStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnChangeStatus?.Invoke(this, _status);
            }
        }

        public bool IsBusy => Figure != null;

        public bool Equals(BoardCellCol col, BoardCellRow row)
        {
            return Col == col && Row == row;
        }

        public void Clear()
        {
            Figure = null;
            Status = BoardCellStatus.Empty;
        }

        #endregion
    }
}