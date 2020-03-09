using System.Collections.Generic;
using System.Linq;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Figure.Model;
using MyChess.Scripts.Core.Game.Master;
using MyChess.Scripts.Core.Game.SwitcherTurn;
using MyChess.Scripts.Utility.Common;
using UnityEngine;

namespace MyChess.Scripts.Core.Game.Control.Kind
{
    public sealed class AiRandomGameControl : IGameControl
    {
        #region AiRandomGameControl

        private readonly IBoardModel BoardModel;
        private readonly IFigureModel FigureModel;
        private readonly IGameMaster GameMaster;
        private readonly IGameSwitcherTurn GameSwitcherTurn;

        public AiRandomGameControl(IBoardModel boardModel, 
            IFigureModel figureModel, 
            IGameMaster gameMaster, 
            IGameSwitcherTurn gameSwitcherTurn)
        {
            BoardModel = boardModel.CheckNull();
            FigureModel = figureModel.CheckNull();
            GameMaster = gameMaster.CheckNull();
            GameSwitcherTurn = gameSwitcherTurn.CheckNull();
        }

        private IEnumerable<IFigureEntity> CreateShuffledFigures(GameTeam team)
        {
            var figures = new List<IFigureEntity>();
            foreach (var figure in FigureModel.Figures)
            {
                if (figure.Team == team)
                {
                    figures.Add(figure);
                }
            }

            return figures.Shuffle();
        }

        private void RandomMoveFocusCell()
        {
            var cells = new List<IBoardCell>();
            foreach (var cell in BoardModel.Cells)
            {
                if (cell.Status == BoardCellStatus.AvailableForMove)
                {
                    cells.Add(cell);
                }
            }

            if (!cells.IsEmpty())
            {
                GameMaster.MoveFocusFigure(cells.GetRandom());
                return;
            }

            Debug.LogWarning("Can't find available cells");
            GameSwitcherTurn.SwitchTurn(true, true);
        }

        #endregion

        #region IGameControl

        public void PrepareControl(GameTeam team)
        {
            var figures = CreateShuffledFigures(team);
            foreach (var figure in figures)
            {
                if (!GameMaster.SetAndActivateFocusFigure(figure))
                {
                    continue;
                }

                var hasAvailableCells = BoardModel.Cells.Any(cell => cell.Status == BoardCellStatus.AvailableForMove);
                if (hasAvailableCells)
                {
                    break;
                }
            }
        }

        public void ActivateControl()
        {
            RandomMoveFocusCell();
        }

        #endregion

        #region IDef

        public GameControlKind Id => GameControlKind.RandomAi;

        #endregion
    }
}