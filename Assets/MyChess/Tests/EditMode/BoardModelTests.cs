using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Enum;
using NUnit.Framework;

namespace MyChess.Tests.EditMode
{
    public class BoardModelTests
    {
        #region BoardModelTests

        private const int CellsLength = 4;
        
        private IBoardModel BoardModel;

        [SetUp]
        public void SetUp()
        {
            var cells = new IBoardCell[,]
            {
                {
                    new BoardCell(BoardCellCol.ColA, BoardCellRow.Row1, 0, 0),
                    new BoardCell(BoardCellCol.ColB, BoardCellRow.Row1, 1, 0)
                },
                {
                    new BoardCell(BoardCellCol.ColC, BoardCellRow.Row2, 0, 1),
                    new BoardCell(BoardCellCol.ColD, BoardCellRow.Row2, 1, 1)
                }
            };

            BoardModel = new BoardModel();
            BoardModel.SetCells(cells);
        }

        #endregion

        #region GetCell_CheckExistingCellNotNull_ExistingCellNotNull

        [Test]
        public void GetCell_CheckExistingCellNotNull_ExistingCellNotNull()
        {
            var existingCell = BoardModel.GetCell(BoardCellCol.ColA, BoardCellRow.Row1);
            Assert.IsNotNull(existingCell, "existingCell != null");
        }

        #endregion

        #region GetCell_CheckNonExistingCellIsNull_NonExistingCellIsNull

        [Test]
        public void GetCell_CheckNonExistingCellIsNull_NonExistingCellIsNull()
        {
            var nonExistingCell = BoardModel.GetCell(BoardCellCol.ColA, BoardCellRow.Row2);
            Assert.IsNull(nonExistingCell, "nonExistingCell == null");
        }

        #endregion

        #region EnumerateCells_CellNotNullAndCountSame

        [Test]
        public void EnumerateCells_CellNotNullAndCountSame()
        {
            var count = 0;
            foreach (var cell in BoardModel.Cells)
            {
                Assert.IsNotNull(cell, "cell != null");
                count++;
            }

            Assert.IsTrue(count == CellsLength, "count == cellsLength");
        }

        #endregion

        #region CallActionForCell_TryingAccessCell_EqualsСonfirmed

        [Test]
        public void CallActionForCell_TryingAccessCell_EqualsСonfirmed()
        {
            var curCell = BoardModel.GetCell(BoardCellCol.ColA, BoardCellRow.Row1);

            var cell = BoardModel.GetCell(0, 0);
            Assert.IsTrue(cell.Equals(curCell), $"not equals for curCell:{curCell}, cell:{cell}");

            cell = BoardModel.GetCell(0, 1);
            Assert.IsTrue(!cell.Equals(curCell), $"equals for curCell:{curCell}, cell:{cell}");
        }

        #endregion
    }
}