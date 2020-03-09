using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Figure.MoveTurnRules;
using MyChess.Scripts.Core.Game.MoveTurnManager;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;
using NSubstitute;
using NUnit.Framework;

namespace MyChess.Tests.EditMode
{
    public class GameMoveTurnManagerTests
    {
        #region CalculateMovesTurn_ConfigurationMoveTurnData_CheckCorrectlyRemovedFigure

        [Test]
        public void CalculateMovesTurn_ConfigurationMoveTurnData_CheckCorrectlyRemovedFigure()
        {
            //create moveTurnData's
            var cell1 = Substitute.For<IBoardCell>();

            var moveTurnData1 = Substitute.For<IGameMoveTurnData>();
            moveTurnData1.MoveToCell.Returns(cell1);
            moveTurnData1.RemovedFigure.Returns(default(IFigureEntity));

            var cell2 = Substitute.For<IBoardCell>();
            var figure = Substitute.For<IFigureEntity>();
            var moveTurnData2 = Substitute.For<IGameMoveTurnData>();
            moveTurnData2.MoveToCell.Returns(cell2);
            moveTurnData2.RemovedFigure.Returns(figure);

            var figureMoveTurnRules = Substitute.For<IFigureMoveTurnRules>();
            figureMoveTurnRules.CalculateMoveTurnData(default).ReturnsForAnyArgs(new[] {moveTurnData1, moveTurnData2});

            //create entity
            var figureDef = Substitute.For<IFigureDef>();
            figureDef.FigureMoveTurnRules.Returns(new[] {figureMoveTurnRules});

            var movableFigure = Substitute.For<IFigureEntity>();
            movableFigure.Def.Returns(figureDef);

            var moveTurnManager = new GameMoveTurnManager();
            moveTurnManager.CalculateMovesTurn(movableFigure);

            //assert
            Assert.IsNull(moveTurnManager.GetRemovedFigure(cell1), "moveTurnManager.GetRemovedFigure(cell) != null");
            Assert.IsTrue(moveTurnManager.GetRemovedFigure(cell2) == figure,
                "moveTurnManager.GetRemovedFigure(cell2) == figure");
        }

        #endregion
    }
}