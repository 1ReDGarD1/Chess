using System;
using System.Collections.Generic;
using System.Linq;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Core.Board.Model
{
    public sealed class BoardModel : IBoardModel, IGameComponentCompleted
    {
        #region BoardModel

        private IBoardCell[] _cellsList;
        private IBoardCell[,] _cells;

        private int _cellsColRowLength;

        private bool CheckExistCellIndex(int index) => index >= 0 && index < _cellsColRowLength;

        public override string ToString() => $"BoardModel cells:\n{_cellsList.ToString(",\n")}";

        #endregion

        #region IBoardModel

        public IEnumerable<IBoardCell> Cells => _cellsList;

        public void SetCells(IBoardCell[,] cells)
        {
            _cells = cells;

            _cellsColRowLength = cells.GetUpperBound(1) + 1;
            _cellsList = new IBoardCell[_cellsColRowLength * _cellsColRowLength];
            var countIndex = 0;
            for (var i = 0; i < _cellsColRowLength; i++)
            {
                for (var j = 0; j < _cellsColRowLength; j++)
                {
                    var cell = cells[i, j];
                    _cellsList[countIndex++] = cell;
                }
            }
        }

        public IBoardCell GetCell(BoardCellCol col, BoardCellRow row)
        {
            return _cellsList.FirstOrDefault(cell => cell.Equals(col, row));
        }

        public IBoardCell GetCell(int indexX, int indexY)
        {
            if (!CheckExistCellIndex(indexX) || !CheckExistCellIndex(indexY))
            {
                return default;
            }

            var cell = _cells[indexX, indexY];
            return cell;
        }

        #endregion

        #region IGameComponentCompleted

        public void GameComplete()
        {
            _cells = null;
            _cellsColRowLength = 0;

            Array.ForEach(_cellsList, cell => cell.Clear());
            _cellsList = null;
        }

        #endregion
    }
}