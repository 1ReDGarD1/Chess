using System;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Controller.Args;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Figure.Model;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Core.Figure.Controller
{
    public sealed class FigureController : IFigureController
    {
        #region FigureController

        private readonly IFigureModel FigureModel;

        public FigureController(IFigureModel figureModel)
        {
            FigureModel = figureModel.CheckNull();
        }

        #endregion

        #region IFigureController

        public event EventHandler<IMovedFigureEventArgs> OnMovedFigure;
        public event EventHandler<IFigureEntity> OnRemovedFigure;

        public void MoveFigure(IFigureEntity figure, IBoardCell cell)
        {
            figure.PlacedCell?.Clear();
            figure.PlacedCell = cell;

            cell.Figure = figure;

            OnMovedFigure?.Invoke(this, new MovedFigureEventArgs(figure, cell));
        }

        public void RemoveFigure(IFigureEntity figure)
        {
            FigureModel.RemoveFigure(figure);

            OnRemovedFigure?.Invoke(this, figure);
        }

        #endregion
    }
}