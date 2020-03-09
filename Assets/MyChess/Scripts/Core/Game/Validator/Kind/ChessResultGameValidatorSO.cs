using System.Collections.Generic;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Figure.Model;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Core.Game.Validator.Kind
{
    [CreateAssetMenu(menuName = "MyChess/Result Game Validator/Chess")]
    public sealed class ChessResultGameValidatorSO : BaseResultGameValidatorSO
    {
        #region ChessResultGameValidatorSO

        [SerializeField]
        private FigureDefSO _victimFigureDef;

        private IFigureModel FigureModel;

        [Inject]
        private void Construct(IFigureModel figureModel)
        {
            _victimFigureDef.CheckNull();

            FigureModel = figureModel.CheckNull();
        }

        #endregion

        #region IResultGameValidator

        public override bool ValidateResult()
        {
            var countByTeam = new Dictionary<GameTeam, int> {{GameTeam.Black, 0}, {GameTeam.White, 0}};

            foreach (var figureEntity in FigureModel.Figures)
            {
                if (figureEntity.Def.Equals(_victimFigureDef))
                {
                    countByTeam[figureEntity.Team] += 1;
                }
            }

            return countByTeam[GameTeam.Black] > 0 && countByTeam[GameTeam.White] > 0;
        }

        #endregion
    }
}