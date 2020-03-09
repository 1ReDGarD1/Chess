using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Figure.Model;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Core.Figure.Creator
{
    public sealed class FigureCreator : IFigureCreator
    {
        #region FigureCreator

        private readonly IFigureModel FigureModel;

        public FigureCreator(IFigureModel figureModel)
        {
            FigureModel = figureModel.CheckNull();
        }

        #endregion

        #region IFigureCreator

        public IFigureEntity Create(IFigureDef figureDef, GameTeam team)
        {
            var figureEntity = new FigureEntity(figureDef, team);
            
            FigureModel.AddFigure(figureEntity);
            return figureEntity;
        }

        #endregion
    }
}