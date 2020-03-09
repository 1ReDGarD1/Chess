using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Controller;
using MyChess.Scripts.Core.Figure.Controller.Args;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Display.Game.Board.Model;
using MyChess.Scripts.Display.Game.Figure.Factory;
using MyChess.Scripts.Display.Game.Figure.Model;
using MyChess.Scripts.Display.Game.Figure.View;
using MyChess.Scripts.Utility.Common;
using UnityEngine;

namespace MyChess.Scripts.Main.Presenter
{
    public sealed class FigurePresenter : IGameComponentStarting, IGameComponentCompleted
    {
        #region FigurePresenter

        private readonly IBoardViewModel BoardViewModel;
        private readonly IFigureController FigureController;
        private readonly IFigureViewModel FigureViewModel;
        private readonly IFigureViewFactory FigureViewFactory;

        public FigurePresenter(IBoardViewModel boardViewModel,
            IFigureController figureController,
            IFigureViewModel figureViewModel,
            IFigureViewFactory figureViewFactory)
        {
            BoardViewModel = boardViewModel.CheckNull();
            FigureController = figureController.CheckNull();
            FigureViewModel = figureViewModel.CheckNull();
            FigureViewFactory = figureViewFactory.CheckNull();
        }

        private void PrePositioning()
        {
            foreach (var figureViewByEntity in FigureViewModel.ViewsByEntity)
            {
                var figureEntity = figureViewByEntity.Key;
                var figureView = figureViewByEntity.Value;

                var placedCell = figureEntity.PlacedCell;
                SetPosition(figureView, placedCell);
            }
        }

        private void OnMovedFigureHandler(object sender, IMovedFigureEventArgs movedFigureEventArgs)
        {
            var curFigureView = movedFigureEventArgs.Figure;
            var figureView = FigureViewModel.GetView(curFigureView);

            SetPosition(figureView, movedFigureEventArgs.Cell);
        }

        private void OnRemovedFigureHandler(object sender, IFigureEntity figure)
        {
            var figureView = FigureViewModel.GetView(figure);

            FigureViewFactory.Despawn(figureView);
            FigureViewModel.RemoveView(figure);
        }

        private void SetPosition(IFigureView figureView, IBoardCell cell)
        {
            var cellView = BoardViewModel.GetView(cell);
            figureView.Position = cellView.Position;
        }

        #endregion

        #region IGameComponentStarting

        public void GameStarting()
        {
            PrePositioning();

            FigureController.OnMovedFigure += OnMovedFigureHandler;
            FigureController.OnRemovedFigure += OnRemovedFigureHandler;
        }

        #endregion

        #region IGameComponentCompleted

        public void GameComplete()
        {
            FigureController.OnMovedFigure -= OnMovedFigureHandler;
            FigureController.OnRemovedFigure -= OnRemovedFigureHandler;

            foreach (var viewByEntity in FigureViewModel.ViewsByEntity)
            {
                var figureView = viewByEntity.Value;
                FigureViewFactory.Despawn(figureView);
            }

            FigureViewModel.Clear();
        }

        #endregion
    }
}