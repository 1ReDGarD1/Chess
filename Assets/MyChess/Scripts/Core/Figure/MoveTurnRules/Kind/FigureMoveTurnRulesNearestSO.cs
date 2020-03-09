using System.Collections.Generic;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;
using UnityEngine;

namespace MyChess.Scripts.Core.Figure.MoveTurnRules.Kind
{
    [CreateAssetMenu(menuName = "MyChess/Figure Turn Rules/Nearest")]
    public sealed class FigureMoveTurnRulesNearestSO : BaseFigureMoveTurnRulesSO
    {
        #region FigureMoveTurnRulesNearestSO

        private static readonly int[] DeltaIndexes = {-1, 0, 1};

        #endregion

        #region IFigureMoveTurnRules

        public override ICollection<IGameMoveTurnData> CalculateMoveTurnData(IFigureEntity movableFigure)
        {
            var moveTurnData = CreateMoveTurnData(movableFigure.PlacedCell, DeltaIndexes, DeltaIndexes);
            return new List<IGameMoveTurnData>(moveTurnData);
        }

        #endregion
    }
}