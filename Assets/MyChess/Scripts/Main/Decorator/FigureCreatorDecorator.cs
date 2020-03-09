using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Creator;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Display.Game.Figure.Factory;
using MyChess.Scripts.Display.Game.Figure.Model;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Main.Decorator
{
    public sealed class FigureCreatorDecorator : IFigureCreator
    {
        #region FigureCreatorDecorator

        private readonly IFigureCreator FigureCreator;
        private readonly IFigureViewModel FigureViewModel;
        private readonly IFigureViewFactory FigureViewFactory;

        public FigureCreatorDecorator(IFigureCreator figureCreator,
            IFigureViewModel figureViewModel,
            IFigureViewFactory figureViewFactory)
        {
            FigureCreator = figureCreator.CheckNull();
            FigureViewModel = figureViewModel.CheckNull();
            FigureViewFactory = figureViewFactory.CheckNull();
        }

        #endregion

        #region IFigureCreator

        public IFigureEntity Create(IFigureDef figureDef, GameTeam team)
        {
            var figureEntity = FigureCreator.Create(figureDef, team);

            var figureView = FigureViewFactory.Spawn(figureEntity);
            FigureViewModel.AddView(figureEntity, figureView);

            return figureEntity;
        }

        #endregion
    }
}