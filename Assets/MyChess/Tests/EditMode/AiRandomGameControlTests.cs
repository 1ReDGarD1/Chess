using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Figure.Model;
using MyChess.Scripts.Core.Game.Control.Kind;
using MyChess.Scripts.Core.Game.Master;
using MyChess.Scripts.Core.Game.SwitcherTurn;
using NSubstitute;
using NUnit.Framework;

namespace MyChess.Tests.EditMode
{
    public class AiRandomGameControlTests
    {
        #region ActivateControl_MovedFigureToCell_CellHasFigure

        [Test]
        public void ActivateControl_MovedFigureToCell_CellHasFigure()
        {
            var team = GameTeam.White;

            var figure = Substitute.For<IFigureEntity>();
            figure.Team.Returns(team);

            var placedCell = Substitute.For<IBoardCell>();
            placedCell.Status.Returns(BoardCellStatus.AvailableForMove);

            var boardModel = Substitute.For<IBoardModel>();
            boardModel.Cells.Returns(new[] {placedCell});

            var figureModel = Substitute.For<IFigureModel>();
            figureModel.Figures.Returns(new[] {figure});

            var gameMaster = Substitute.For<IGameMaster>();
            gameMaster.SetAndActivateFocusFigure(default).ReturnsForAnyArgs(callInfo => true);
            gameMaster.MoveFocusFigure(default).ReturnsForAnyArgs(callInfo =>
            {
                placedCell.Figure = figure;
                return true;
            });

            var gameSwitcherTurn = Substitute.For<IGameSwitcherTurn>();

            var aiRandomGameControl = new AiRandomGameControl(boardModel, figureModel, gameMaster, gameSwitcherTurn);
            aiRandomGameControl.PrepareControl(team);
            aiRandomGameControl.ActivateControl();

            Assert.IsTrue(placedCell.Figure == figure, "placedCell.Figure != figure");
        }

        #endregion
    }
}