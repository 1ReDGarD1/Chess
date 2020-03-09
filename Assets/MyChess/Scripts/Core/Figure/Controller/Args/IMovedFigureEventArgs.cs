using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Figure.Controller.Args
{
    public interface IMovedFigureEventArgs
    {
        #region IMovedFigureEventArgs

        IFigureEntity Figure { get; }

        IBoardCell Cell { get; }

        #endregion
    }
}