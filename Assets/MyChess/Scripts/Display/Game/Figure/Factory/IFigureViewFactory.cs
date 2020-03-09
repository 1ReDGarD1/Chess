using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Display.Game.Figure.Factory.Pool;
using MyChess.Scripts.Display.Game.Figure.View;

namespace MyChess.Scripts.Display.Game.Figure.Factory
{
    public interface IFigureViewFactory
    {
        #region IFigureViewFactory

        void RegisterFigureViewPool(IFigureDef figureDef, GameTeam team, IFigureViewPool figureViewPool);

        IFigureView Spawn(IFigureEntity figure);

        void Despawn(IFigureView figureView);

        #endregion
    }
}