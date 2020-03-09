using System.Collections.Generic;
using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Figure.Model
{
    public interface IFigureModel
    {
        #region IFigureModel
        
        IEnumerable<IFigureEntity> Figures { get; }

        void AddFigure(IFigureEntity figure);
        void RemoveFigure(IFigureEntity figure);

        #endregion
    }
}