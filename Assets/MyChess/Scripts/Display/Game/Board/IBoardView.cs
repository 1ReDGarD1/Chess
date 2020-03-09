using System.Collections.Generic;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Display.Foundation.View;
using MyChess.Scripts.Display.Game.Board.Cell;

namespace MyChess.Scripts.Display.Game.Board
{
    public interface IBoardView : IViewElement
    {
        #region IBoardView

        IEnumerable<IBoardCellView> CellViews { get; }

        IBoardCellView GetCellView(IBoardCell cell);

        #endregion
    }
}