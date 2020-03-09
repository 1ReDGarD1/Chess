using MyChess.Scripts.Core.Figure.Entity;
using UnityEngine;

namespace MyChess.Scripts.Display.Game.Figure.View
{
    public interface IFigureView
    {
        #region IFigureView

        IFigureEntity Entity { get; }

        Vector3 Position { set; }

        #endregion
    }
}