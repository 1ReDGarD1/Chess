using System.Collections.Generic;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;
using UnityEngine;

namespace MyChess.Scripts.Core.Figure.MoveTurnRules.Kind
{
    [CreateAssetMenu(menuName = "MyChess/Figure Turn Rules/Diagonally")]
    public sealed class FigureMoveTurnRulesDiagonallySO : BaseFigureMoveTurnRulesSO
    {
        #region FigureMoveTurnRulesDiagonallySO

        private static readonly int[] DeltaIndexesRightTop = {-1, 1};
        private static readonly int[] DeltaIndexesRightDown = {1, 1};
        private static readonly int[] DeltaIndexesLeftTop = {-1, -1};
        private static readonly int[] DeltaIndexesLeftDown = {1, -1};

        private IEnumerable<IGameMoveTurnData> GetMoveTurnData(IBoardCell cell, IList<int> deltaIndexes)
        {
            var newIndexX = cell.IndexX;
            var newIndexY = cell.IndexY;
            IGameMoveTurnData lastMoveTurnData;
            do
            {
                newIndexX += deltaIndexes[0];
                newIndexY += deltaIndexes[1];

                lastMoveTurnData = CreateMoveTurnData(newIndexX, newIndexY);

                if (lastMoveTurnData.IsEmpty) continue;
                yield return lastMoveTurnData;
                if (lastMoveTurnData.HasRemovedFigure) break;
            } while (!lastMoveTurnData.IsEmpty);
        }

        #endregion

        #region IFigureMoveTurnRules

        public override ICollection<IGameMoveTurnData> CalculateMoveTurnData(IFigureEntity movableFigure)
        {
            var placedCell = movableFigure.PlacedCell;
            
            var moveTurnData = new List<IGameMoveTurnData>();
            moveTurnData.AddRange(GetMoveTurnData(placedCell, DeltaIndexesRightTop));
            moveTurnData.AddRange(GetMoveTurnData(placedCell, DeltaIndexesRightDown));
            moveTurnData.AddRange(GetMoveTurnData(placedCell, DeltaIndexesLeftTop));
            moveTurnData.AddRange(GetMoveTurnData(placedCell, DeltaIndexesLeftDown));
            return moveTurnData;
        }

        #endregion
    }
}