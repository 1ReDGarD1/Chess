using System;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Controller.Args;
using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Figure.Controller
{
    public interface IFigureController
    {
        #region IFigureController

        event EventHandler<IMovedFigureEventArgs> OnMovedFigure;
        event EventHandler<IFigureEntity> OnRemovedFigure;

        void MoveFigure(IFigureEntity figure, IBoardCell cell);
        void RemoveFigure(IFigureEntity figure);

        #endregion
    }
}