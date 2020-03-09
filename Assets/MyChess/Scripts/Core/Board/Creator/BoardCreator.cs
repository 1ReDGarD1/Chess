using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Core.Board.Creator
{
    public sealed class BoardCreator : IBoardCreator
    {
        #region Const

        private static readonly BoardCellCol[] Cols =
        {
            BoardCellCol.ColA,
            BoardCellCol.ColB,
            BoardCellCol.ColC,
            BoardCellCol.ColD,
            BoardCellCol.ColE,
            BoardCellCol.ColF,
            BoardCellCol.ColG,
            BoardCellCol.ColH
        };

        private static readonly BoardCellRow[] Rows =
        {
            BoardCellRow.Row8,
            BoardCellRow.Row7,
            BoardCellRow.Row6,
            BoardCellRow.Row5,
            BoardCellRow.Row4,
            BoardCellRow.Row3,
            BoardCellRow.Row2,
            BoardCellRow.Row1
        };

        private static readonly int MaxColCells = Cols.Length;
        private static readonly int MaxRowCells = Rows.Length;

        #endregion

        #region IBoardCreator

        public void CreateCells(IBoardModel boardModel)
        {
            var cells = new IBoardCell[MaxColCells, MaxRowCells];

            for (var i = 0; i < MaxRowCells; i++)
            {
                for (var j = 0; j < MaxColCells; j++)
                {
                    var col = Cols[j];
                    var row = Rows[i];

                    var cell = new BoardCell(col, row, i, j);
                    cells[i, j] = cell;
                }
            }

            boardModel.SetCells(cells);
        }

        #endregion
    }
}