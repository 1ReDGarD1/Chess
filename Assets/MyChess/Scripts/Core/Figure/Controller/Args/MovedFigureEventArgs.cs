using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Core.Figure.Controller.Args
{
    public struct MovedFigureEventArgs : IMovedFigureEventArgs
    {
        #region MovedFigureEventArgs

        public MovedFigureEventArgs(IFigureEntity figureEntity, IBoardCell boardCell)
        {
            Figure = figureEntity.CheckNull();
            Cell = boardCell.CheckNull();
        }

        #endregion

        #region IMovedFigureEventArgs

        public IFigureEntity Figure { get; }
        public IBoardCell Cell { get; }

        #endregion
    }
}