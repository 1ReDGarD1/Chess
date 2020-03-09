using System.Collections.Generic;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;
using UnityEngine;

namespace MyChess.Scripts.Core.Figure.MoveTurnRules.Kind
{
    [CreateAssetMenu(menuName = "MyChess/Figure Turn Rules/Knight")]
    public sealed class FigureMoveTurnRulesKnightSO : BaseFigureMoveTurnRulesSO
    {
        #region FigureMoveTurnRulesKnightSO

        private static readonly int[] DeltaIndexes1 = {2, -2};
        private static readonly int[] DeltaIndexes2 = {1, -1};

        #endregion

        #region IFigureMoveTurnRules

        public override ICollection<IGameMoveTurnData> CalculateMoveTurnData(IFigureEntity movableFigure)
        {
            var placedCell = movableFigure.PlacedCell;
            
            var moveTurnData = new List<IGameMoveTurnData>();
            moveTurnData.AddRange(CreateMoveTurnData(placedCell, DeltaIndexes1, DeltaIndexes2));
            moveTurnData.AddRange(CreateMoveTurnData(placedCell, DeltaIndexes2, DeltaIndexes1));
            return moveTurnData;
        }

        #endregion
    }
}