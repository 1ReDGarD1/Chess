using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Model;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Core.Game.Validator.Kind
{
    [CreateAssetMenu(menuName = "MyChess/Result Game Validator/Checkers")]
    public sealed class CheckersResultGameValidatorSO : BaseResultGameValidatorSO
    {
        #region CheckersResultGameValidatorSO

        private IFigureModel FigureModel;

        [Inject]
        private void Construct(IFigureModel figureModel)
        {
            FigureModel = figureModel.CheckNull();
        }

        private bool HasTeammateFigures(GameTeam team)
        {
            foreach (var figure in FigureModel.Figures)
            {
                if (figure.Team == team)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region IResultGameValidator

        public override bool ValidateResult()
        {
            return HasTeammateFigures(GameTeam.Black) && HasTeammateFigures(GameTeam.White);
        }

        #endregion
    }
}