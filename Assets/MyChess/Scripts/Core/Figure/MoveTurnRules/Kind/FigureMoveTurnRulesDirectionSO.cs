using System.Collections.Generic;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;
using UnityEngine;

namespace MyChess.Scripts.Core.Figure.MoveTurnRules.Kind
{
    [CreateAssetMenu(menuName = "MyChess/Figure Turn Rules/Direction")]
    public sealed class FigureMoveTurnRulesDirectionSO : BaseFigureMoveTurnRulesSO
    {
        #region FigureMoveTurnRulesDirectionSO

        private static readonly int[] DeltaIndexes = {-1, 1};

        #endregion

        #region IFigureMoveTurnRules

        public override ICollection<IGameMoveTurnData> CalculateMoveTurnData(IFigureEntity movableFigure)
        {
            var placedCell = movableFigure.PlacedCell;
            var curIndexX = placedCell.IndexX;
            var curIndexY = placedCell.IndexY;

            var moveTurnData = new List<IGameMoveTurnData>();
            for (var i = 0; i < 2; i++)
            {
                foreach (var deltaIndex in DeltaIndexes)
                {
                    var newIndexX = curIndexX;
                    var newIndexY = curIndexY;
                    IGameMoveTurnData lastMoveTurnData;
                    do
                    {
                        if (i == 0) newIndexX += deltaIndex;
                        else newIndexY += deltaIndex;

                        lastMoveTurnData = CreateMoveTurnData(newIndexX, newIndexY);

                        if (lastMoveTurnData.IsEmpty) continue;
                        moveTurnData.Add(lastMoveTurnData);
                        if (lastMoveTurnData.HasRemovedFigure) break;
                    } while (!lastMoveTurnData.IsEmpty);
                }
            }

            return moveTurnData;
        }

        #endregion
    }
}