using System.Collections.Generic;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Core.Figure.Model
{
    public sealed class FigureModel : IFigureModel, IGameComponentCompleted
    {
        #region FigureModel

        private List<IFigureEntity> FiguresList { get; } = new List<IFigureEntity>();

        public override string ToString() => $"FigureModel figureEntities:\n{FiguresList.ToString(",\n")}";

        #endregion

        #region IFigureModel

        public IEnumerable<IFigureEntity> Figures => FiguresList;

        public void AddFigure(IFigureEntity figure)
        {
            FiguresList.Add(figure);
        }

        public void RemoveFigure(IFigureEntity figure)
        {
            figure.Clear();
            FiguresList.Remove(figure);
        }

        #endregion

        #region IGameComponentCompleted

        public void GameComplete()
        {
            FiguresList.ForEach(figure => figure.Clear());
            FiguresList.Clear();
        }

        #endregion
    }
}