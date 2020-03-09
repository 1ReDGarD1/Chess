using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Controller;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Figure.Model;
using NSubstitute;
using NUnit.Framework;

namespace MyChess.Tests.EditMode
{
    public class FigureControllerTests
    {
        #region Helper methods

        private IFigureController CreateFigureController()
        {
            var figureModel = Substitute.For<IFigureModel>();

            return new FigureController(figureModel);
        }

        #endregion

        #region PlaceFigure_SubscribeEventPlacedAndRemoveFigure_FigurePlaced

        [Test]
        public void PlaceFigure_SubscribeEventPlacedAndRemoveFigure_FigurePlaced()
        {
            var curFigure = Substitute.For<IFigureEntity>();
            var curCell = Substitute.For<IBoardCell>();

            var figureController = CreateFigureController();
            figureController.OnMovedFigure += (sender, placedFigureEventArgs) =>
            {
                var figure = placedFigureEventArgs.Figure;
                var cell = placedFigureEventArgs.Cell;

                Assert.IsNotNull(figure, "figure != null");
                Assert.IsNotNull(cell, "cell != null");
                Assert.IsTrue(curFigure == figure, "curFigure == figure");
                Assert.IsTrue(curCell == cell, "curCell == cell");
            };

            figureController.OnRemovedFigure += (sender, entity) => { Assert.Fail("remove figure event"); };

            figureController.MoveFigure(curFigure, curCell);
        }

        #endregion

        #region RemoveFigure_SubscribeEventRemoveFigure_FigureRemoved

        [Test]
        public void RemoveFigure_SubscribeEventRemoveFigure_FigureRemoved()
        {
            var figureController = CreateFigureController();

            var newFigure = Substitute.For<IFigureEntity>();
            newFigure.Team.Returns(GameTeam.White);

            var prevFigure = Substitute.For<IFigureEntity>();
            prevFigure.Team.Returns(GameTeam.Black);

            var curCell = Substitute.For<IBoardCell>();
            curCell.IsBusy.Returns(true);
            curCell.Figure.Returns(prevFigure);

            figureController.OnRemovedFigure += (sender, entity) =>
            {
                Assert.IsNotNull(entity, "entity != null");
                Assert.IsTrue(prevFigure == entity, "prevFigure == entity");
            };

            figureController.MoveFigure(newFigure, curCell);
        }

        #endregion
    }
}