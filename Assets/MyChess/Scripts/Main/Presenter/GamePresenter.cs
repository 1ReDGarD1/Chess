using System;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Game.Master;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Display.Game.Board;
using MyChess.Scripts.Display.Game.Board.Model;
using MyChess.Scripts.Utility.Common;
using UnityEngine;

namespace MyChess.Scripts.Main.Presenter
{
    public sealed class GamePresenter : IGameComponentStarting, IGameComponentCompleted
    {
        #region GamePresenter

        private readonly IBoardView BoardView;
        private readonly IGameMaster GameMaster;
        private readonly IBoardModel BoardModel;
        private readonly IBoardViewModel BoardViewModel;

        public GamePresenter(IBoardView boardView,
            IGameMaster gameMaster,
            IBoardModel boardModel,
            IBoardViewModel boardViewModel)
        {
            BoardView = boardView.CheckNull();
            GameMaster = gameMaster.CheckNull();
            BoardModel = boardModel.CheckNull();
            BoardViewModel = boardViewModel.CheckNull();
        }

        private void ConsumeCellView()
        {
            foreach (var cell in BoardModel.Cells)
            {
                var cellView = BoardView.GetCellView(cell);
                cellView.Cell = cell;

                BoardViewModel.AddView(cell, cellView);
            }
        }

        private void OnClickCellView(object sender, IBoardCell cell)
        {
            if (cell.Status == BoardCellStatus.AvailableForMove)
            {
                GameMaster.MoveFocusFigure(cell);
            }
            else if (!GameMaster.IsBlockFocused && cell.IsBusy)
            {
                GameMaster.SetAndActivateFocusFigure(cell.Figure);
            }
        }

        private void UnsubscribeHandlers()
        {
            foreach (var cellView in BoardView.CellViews)
            {
                cellView.OnClick -= OnClickCellView;
            }

            GameMaster.OnCompleteGame -= OnCompleteGameHandler;
        }

        private void OnCompleteGameHandler(object sender, EventArgs eventArgs)
        {
            UnsubscribeHandlers();
        }

        #endregion

        #region IGameComponentStarting

        public void GameStarting()
        {
            ConsumeCellView();

            foreach (var cellView in BoardView.CellViews)
            {
                cellView.OnClick += OnClickCellView;
            }

            GameMaster.OnCompleteGame += OnCompleteGameHandler;
        }

        #endregion

        #region IGameComponentCompleted

        public void GameComplete()
        {
            UnsubscribeHandlers();
        }

        #endregion
    }
}