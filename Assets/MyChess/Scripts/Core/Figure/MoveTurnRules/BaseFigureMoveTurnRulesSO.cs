using System.Collections.Generic;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.Model;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Core.Figure.MoveTurnRules
{
    public abstract class BaseFigureMoveTurnRulesSO : ScriptableObject, IFigureMoveTurnRules
    {
        #region BaseFigureMoveTurnRulesSO

        protected IGameModel GameModel;
        protected IBoardModel BoardModel;

        [Inject]
        public void Construct(IBoardModel boardModel, IGameModel gameModel)
        {
            BoardModel = boardModel.CheckNull();
            GameModel = gameModel.CheckNull();
        }

        private bool CheckCanMove(IBoardCell moveToCell)
        {
            if (moveToCell == null)
            {
                return false;
            }

            if (moveToCell.IsBusy)
            {
                if (moveToCell.Figure.Team == GameModel.CurTeamTurn)
                {
                    return false;
                }
            }
            else if (moveToCell.Status == BoardCellStatus.AvailableForMove)
            {
                return false;
            }

            return true;
        }

        protected IEnumerable<IGameMoveTurnData> CreateMoveTurnData(IBoardCell cell, ICollection<int> deltaIndexes1,
            ICollection<int> deltaIndexes2)
        {
            var curIndexX = cell.IndexX;
            var curIndexY = cell.IndexY;

            foreach (var deltaIndexX in deltaIndexes1)
            {
                foreach (var deltaIndexY in deltaIndexes2)
                {
                    var newIndexX = curIndexX + deltaIndexX;
                    var newIndexY = curIndexY + deltaIndexY;

                    var data = CreateMoveTurnData(newIndexX, newIndexY);
                    if (!data.IsEmpty) yield return data;
                }
            }
        }

        protected IGameMoveTurnData CreateMoveTurnData(int indexX, int indexY)
        {
            var moveToCell = BoardModel.GetCell(indexX, indexY);

            if (!CheckCanMove(moveToCell))
            {
                return GameMoveTurnData.Empty;
            }

            moveToCell.Status = BoardCellStatus.AvailableForMove;

            var removedFigure = moveToCell.IsBusy ? moveToCell.Figure : default;

            return new GameMoveTurnData(moveToCell, removedFigure);
        }

        #endregion

        #region IFigureMoveTurnRules

        public abstract ICollection<IGameMoveTurnData> CalculateMoveTurnData(IFigureEntity movableFigure);

        #endregion
    }
}