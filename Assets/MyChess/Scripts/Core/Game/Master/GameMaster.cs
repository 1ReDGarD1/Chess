using System;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Figure.Controller;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Figure.PostTurnLogic.Manager;
using MyChess.Scripts.Core.Game.Model;
using MyChess.Scripts.Core.Game.MoveTurnManager;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Utility.Common;
using UnityEngine;

namespace MyChess.Scripts.Core.Game.Master
{
    public sealed class GameMaster : IGameMaster, IGameComponentStarting
    {
        #region GameMaster

        private readonly IFigureController FigureController;
        private readonly IBoardModel BoardModel;
        private readonly IGameModel GameModel;
        private readonly IFigurePostTurnLogicManager FigurePostTurnLogicManager;
        private readonly IGameMoveTurnManager GameMoveTurnManager;

        private bool HasFocusFigure => _focusFigure != null;

        private IFigureEntity _focusFigure;

        public GameMaster(IFigureController figureController,
            IBoardModel boardModel,
            IGameModel gameModel,
            IFigurePostTurnLogicManager figurePostTurnLogicManager,
            IGameMoveTurnManager gameMoveTurnManager)
        {
            FigureController = figureController.CheckNull();
            BoardModel = boardModel.CheckNull();
            GameModel = gameModel.CheckNull();
            FigurePostTurnLogicManager = figurePostTurnLogicManager.CheckNull();
            GameMoveTurnManager = gameMoveTurnManager.CheckNull();
        }

        private void ResetAvailableCellsToEmpty()
        {
            foreach (var cell in BoardModel.Cells)
            {
                if (cell.Status == BoardCellStatus.AvailableForMove)
                {
                    ResetCellStatusToEmpty(cell);
                }
            }
        }

        private void ResetCellStatusToEmpty(IBoardCell cell) => cell.Status = BoardCellStatus.Empty;

        private void Reset()
        {
            _focusFigure = null;
            IsBlockFocused = false;
        }

        private void RemoveFigure(IBoardCell moveToCell)
        {
            var removedFigure = GameMoveTurnManager.GetRemovedFigure(moveToCell);
            if (removedFigure != null)
            {
                FigureController.RemoveFigure(removedFigure);
            }
        }

        #endregion

        #region IGameMaster

        public event EventHandler OnCompleteGame;

        public bool IsBlockFocused { get; set; }

        public bool SetFocusFigure(IFigureEntity figure)
        {
            if (IsBlockFocused)
            {
                return false;
            }

            if (figure.Team != GameModel.CurTeamTurn)
            {
                return false;
            }

            if (HasFocusFigure)
            {
                if (_focusFigure.Equals(figure))
                {
                    return false;
                }

                ResetCellStatusToEmpty(_focusFigure.PlacedCell);
            }

            figure.PlacedCell.Status = BoardCellStatus.HasFocusFigure;
            _focusFigure = figure;

            return true;
        }

        public bool SetAndActivateFocusFigure(IFigureEntity figure)
        {
            if (!SetFocusFigure(figure))
            {
                return false;
            }

            ResetAvailableCellsToEmpty();
            GameMoveTurnManager.CalculateMovesTurn(figure);

            return true;
        }

        public bool MoveFocusFigure(IBoardCell moveToCell)
        {
            if (!HasFocusFigure || moveToCell.Status != BoardCellStatus.AvailableForMove)
            {
                return false;
            }

            ResetCellStatusToEmpty(_focusFigure.PlacedCell);
            ResetAvailableCellsToEmpty();

            RemoveFigure(moveToCell);
            FigureController.MoveFigure(_focusFigure, moveToCell);

            if (!GameModel.GameDef.Validator.ValidateResult())
            {
                Debug.LogWarning("Game complete");
                OnCompleteGame?.Invoke(this, EventArgs.Empty);
                return true;
            }

            var figure = _focusFigure;
            Reset();

            FigurePostTurnLogicManager.ActivateFigurePostTurnLogic(figure);
            return true;
        }

        #endregion

        #region IGameComponentStarting

        public void GameStarting() => Reset();

        #endregion
    }
}