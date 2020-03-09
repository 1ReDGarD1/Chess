using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Controller;
using MyChess.Scripts.Core.Figure.Creator;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace MyChess.Scripts.Core.Figure.PostTurnLogic.Kind
{
    [CreateAssetMenu(menuName = "MyChess/Figure Post Turn Logic/Transform")]
    public sealed class FigurePostTurnLogicTransformSO : BaseFigurePostTurnLogicSO
    {
        #region FigurePostTurnLogicTransformSO

        [SerializeField]
        private FigureDefSO[] _figureDefsToTransform;

        [SerializeField]
        private BoardCellRow _blackLastRow;

        [SerializeField]
        private BoardCellRow _whiteLastRow;

        private IFigureCreator FigureCreator;
        private IFigureController FigureController;

        [Inject]
        private void Construct(IFigureCreator figureCreator, IFigureController figureController)
        {
            _figureDefsToTransform.CheckNull();
            Assert.IsTrue(_blackLastRow != BoardCellRow.None);
            Assert.IsTrue(_whiteLastRow != BoardCellRow.None);

            FigureCreator = figureCreator.CheckNull();
            FigureController = figureController.CheckNull();
        }

        private bool IsFigurePlacedOnRow(IFigureEntity figure)
        {
            var friendlyRow = figure.Team == GameTeam.White ? _whiteLastRow : _blackLastRow;
            return figure.PlacedCell.Row == friendlyRow;
        }

        private void TransformFigure(IFigureEntity figure, IFigureDef figureDef)
        {
            var cell = figure.PlacedCell;
            var team = figure.Team;

            FigureController.RemoveFigure(figure);

            var newTransformFigure = FigureCreator.Create(figureDef, team);
            FigureController.MoveFigure(newTransformFigure, cell);
        }

        #endregion

        #region IFigurePostTurnLogic

        public override bool ActivatePostTurnLogic(IFigureEntity figure)
        {
            if (!IsFigurePlacedOnRow(figure))
            {
                return false;
            }

            var rndFigureDef = _figureDefsToTransform.GetRandom();
            TransformFigure(figure, rndFigureDef);
            
            SwitchTurn(true, true);
            return true;
        }

        #endregion
    }
}