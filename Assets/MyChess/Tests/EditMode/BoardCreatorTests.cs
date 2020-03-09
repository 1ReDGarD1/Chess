using MyChess.Scripts.Core.Board.Creator;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Enum;
using NUnit.Framework;

namespace MyChess.Tests.EditMode
{
    public class BoardCreatorTests
    {
        #region CreateCells_CreateStandardCells_GetCellNotNullable

        [Test]
        public void CreateCells_CreateStandardCells_GetCellNotNullable()
        {
            var boardModel = new BoardModel();
            var boardCreator = new BoardCreator();
            boardCreator.CreateCells(boardModel);

            Assert.IsNotNull(boardModel.GetCell(BoardCellCol.ColD, BoardCellRow.Row2), "cell == null");
        }

        #endregion
    }
}