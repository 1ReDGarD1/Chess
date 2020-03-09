using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Display.Game.Figure.View;
using MyChess.Scripts.Utility.Common;
using Zenject;

namespace MyChess.Scripts.Display.Game.Figure.Factory.Pool
{
    public sealed class FigureViewPool : MonoMemoryPool<IFigureEntity, FigureView>, IFigureViewPool
    {
        #region FigureViewPool

        public FigureViewPool(IFigureViewFactory figureViewFactory, IFigureDef figureDef, GameTeam figureTeam)
        {
            figureViewFactory.CheckNull();
            figureViewFactory.RegisterFigureViewPool(figureDef, figureTeam, this);
        }

        #endregion

        #region MonoMemoryPool

        protected override void Reinitialize(IFigureEntity entity, FigureView view)
        {
            base.Reinitialize(entity, view);

            view.Init(entity);
        }

        #endregion

        #region IFigureViewPool

        void IDespawnableMemoryPool<IFigureView>.Despawn(IFigureView view)
        {
            base.Despawn(view as FigureView);
        }

        IFigureView IMemoryPool<IFigureEntity, IFigureView>.Spawn(IFigureEntity entity)
        {
            return base.Spawn(entity);
        }

        #endregion
    }
}