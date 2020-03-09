using System.Collections.Generic;
using System.Linq;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;
using UnityEngine;

namespace MyChess.Scripts.Core.Figure.MoveTurnRules.Kind
{
    [CreateAssetMenu(menuName = "MyChess/Figure Turn Rules/Checker")]
    public sealed class FigureMoveTurnRulesCheckerSO : BaseFigureMoveTurnRulesSO
    {
        #region FigureMoveTurnRulesCheckerSO

        [SerializeField]
        private int _rangeTurn;

        [SerializeField]
        private bool _canMoveAllDirection;

        private static readonly int[] DeltaIndexesRightTop = {-1, 1};
        private static readonly int[] DeltaIndexesLeftTop = {-1, -1};

        private static readonly int[] DeltaIndexesRightDown = {1, 1};
        private static readonly int[] DeltaIndexesLeftDown = {1, -1};

        private IList<IGameMoveTurnData> CreateMoveTurnData(IBoardCell cell)
        {
            var moveTurnData = new List<IGameMoveTurnData>();

            var team = cell.Figure.Team;
            if (_canMoveAllDirection || team == GameTeam.White)
            {
                moveTurnData.AddRange(CreateMoveTurnData(cell, DeltaIndexesRightTop));
                moveTurnData.AddRange(CreateMoveTurnData(cell, DeltaIndexesLeftTop));
            }

            if (_canMoveAllDirection || team == GameTeam.Black)
            {
                moveTurnData.AddRange(CreateMoveTurnData(cell, DeltaIndexesRightDown));
                moveTurnData.AddRange(CreateMoveTurnData(cell, DeltaIndexesLeftDown));
            }

            return moveTurnData;
        }

        private IEnumerable<IGameMoveTurnData> CreateMoveTurnData(IBoardCell cell, IList<int> deltaIndexes)
        {
            var deltaIndexX = deltaIndexes[0];
            var deltaIndexY = deltaIndexes[1];

            var curIndexX = cell.IndexX;
            var curIndexY = cell.IndexY;

            void IncrementCurIndexes()
            {
                curIndexX += deltaIndexX;
                curIndexY += deltaIndexY;
            }

            var rangeTurnCount = 0;
            do
            {
                IncrementCurIndexes();

                var removedFigure = default(IFigureEntity);

                var moveToCell = BoardModel.GetCell(curIndexX, curIndexY);
                if (moveToCell == null || moveToCell.Status == BoardCellStatus.AvailableForMove)
                {
                    yield break;
                }

                if (moveToCell.IsBusy)
                {
                    var figure = moveToCell.Figure;
                    if (figure.Team == GameModel.CurTeamTurn)
                    {
                        yield break;
                    }

                    //если клетка занята вражеской фигурой
                    var nextCell = BoardModel.GetCell(curIndexX + deltaIndexX, curIndexY + deltaIndexY);
                    if (nextCell != null && !nextCell.IsBusy)
                    {
                        moveToCell = nextCell;
                        removedFigure = figure;

                        rangeTurnCount += _rangeTurn;
                        IncrementCurIndexes();
                    }
                    else yield break;
                }

                moveToCell.Status = BoardCellStatus.AvailableForMove;

                yield return new GameMoveTurnData(moveToCell, removedFigure);
            } while (++rangeTurnCount < _rangeTurn);
        }

        private bool CheckNeededClearForMoveTurnData(IEnumerable<IGameMoveTurnData> moveTurnData)
        {
            return moveTurnData.Any(data => data.HasRemovedFigure);
        }

        private void ClearMoveTurnData(IList<IGameMoveTurnData> moveTurnData)
        {
            for (var i = moveTurnData.Count - 1; i >= 0; i--)
            {
                var data = moveTurnData[i];
                if (data.HasRemovedFigure)
                {
                    continue;
                }

                data.MoveToCell.Status = BoardCellStatus.Empty;
                moveTurnData.RemoveAt(i);
            }
        }

        #endregion

        #region IFigureMoveTurnRules

        public override ICollection<IGameMoveTurnData> CalculateMoveTurnData(IFigureEntity movableFigure)
        {
            var moveTurnData = CreateMoveTurnData(movableFigure.PlacedCell);

            if (CheckNeededClearForMoveTurnData(moveTurnData))
            {
                ClearMoveTurnData(moveTurnData);
            }

            return moveTurnData;
        }

        #endregion
    }
}