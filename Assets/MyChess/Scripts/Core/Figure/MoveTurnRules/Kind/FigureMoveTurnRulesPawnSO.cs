using System.Collections.Generic;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace MyChess.Scripts.Core.Figure.MoveTurnRules.Kind
{
    [CreateAssetMenu(menuName = "MyChess/Figure Turn Rules/Pawn")]
    public sealed class FigureMoveTurnRulesPawnSO : BaseFigureMoveTurnRulesSO
    {
        #region FigureMoveTurnRulesPawnSO

        [SerializeField]
        private BoardCellRow _blackLastRow;

        [SerializeField]
        private BoardCellRow _whiteLastRow;

        [Inject]
        public void Construct()
        {
            Assert.IsTrue(_blackLastRow != BoardCellRow.None);
            Assert.IsTrue(_whiteLastRow != BoardCellRow.None);
        }

        private bool IsFigurePlacedOnRow(IFigureEntity figure)
        {
            var friendlyRow = figure.Team == GameTeam.White ? _whiteLastRow : _blackLastRow;
            return figure.PlacedCell.Row == friendlyRow;
        }

        #endregion

        #region IFigureMoveTurnRules

        public override ICollection<IGameMoveTurnData> CalculateMoveTurnData(IFigureEntity movableFigure)
        {
            var placedCell = movableFigure.PlacedCell;
            var team = movableFigure.Team;
            var delta = 0;
            var moveTurnData = new List<IGameMoveTurnData>();

            void CreateNextMoveTurnData()
            {
                delta += team == GameTeam.White ? -1 : 1;

                var data = CreateMoveTurnData(placedCell.IndexX + delta, placedCell.IndexY);
                if (!data.IsEmpty)
                {
                    moveTurnData.Add(data);
                }
            }

            CreateNextMoveTurnData();

            if (IsFigurePlacedOnRow(movableFigure))
            {
                CreateNextMoveTurnData();
            }

            return moveTurnData;
        }

        #endregion
    }
}