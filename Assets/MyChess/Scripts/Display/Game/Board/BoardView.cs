using System;
using System.Collections.Generic;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Display.Foundation.View;
using MyChess.Scripts.Display.Game.Board.Cell;
using MyChess.Scripts.Utility.Common;
using UnityEngine;

namespace MyChess.Scripts.Display.Game.Board
{
    [DisallowMultipleComponent]
    public sealed class BoardView : BaseViewElement, IBoardView
    {
        #region BoardView

        private IBoardCellView[] CellViewsArray { get; set; }

        private void Awake()
        {
            CellViewsArray = GetComponentsInChildren<IBoardCellView>();
        }

        public override string ToString() => $"BoardView cellViews:\n{CellViewsArray.ToString(",\n")}";

        #endregion

        #region IBoardView

        public IEnumerable<IBoardCellView> CellViews => CellViewsArray;

        public IBoardCellView GetCellView(IBoardCell cell)
        {
            return Array.Find(CellViewsArray, view => view.Equals(cell));
        }

        #endregion
    }
}