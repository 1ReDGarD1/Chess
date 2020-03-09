using System;
using MyChess.Scripts.Core.Board.Cell;
using UnityEngine;

namespace MyChess.Scripts.Display.Game.Board.Cell
{
    public interface IBoardCellView
    {
        #region IBoardCellView

        event EventHandler<IBoardCell> OnClick;

        IBoardCell Cell { set; }

        Vector3 Position { get; }

        bool Equals(IBoardCell cell);

        #endregion
    }
}