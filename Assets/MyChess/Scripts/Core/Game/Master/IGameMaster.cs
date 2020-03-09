using System;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Game.Master
{
    public interface IGameMaster
    {
        #region IGameMaster

        event EventHandler OnCompleteGame;

        bool IsBlockFocused { get; set; }

        bool SetFocusFigure(IFigureEntity figure);
        bool SetAndActivateFocusFigure(IFigureEntity figure);
        
        bool MoveFocusFigure(IBoardCell moveToCell);

        #endregion
    }
}