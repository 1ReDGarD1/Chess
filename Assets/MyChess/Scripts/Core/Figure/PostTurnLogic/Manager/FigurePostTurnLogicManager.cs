using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.SwitcherTurn;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Core.Figure.PostTurnLogic.Manager
{
    public sealed class FigurePostTurnLogicManager : IFigurePostTurnLogicManager
    {
        #region FigurePostTurnLogicManager

        private readonly IGameSwitcherTurn SwitcherTurn;

        public FigurePostTurnLogicManager(IGameSwitcherTurn switcherTurn)
        {
            SwitcherTurn = switcherTurn.CheckNull();
        }

        #endregion

        #region IFigurePostTurnLogicManager

        public void ActivateFigurePostTurnLogic(IFigureEntity figureEntity)
        {
            foreach (var figurePostTurnLogic in figureEntity.Def.FigurePostTurnLogics)
            {
                var isActivated = figurePostTurnLogic.ActivatePostTurnLogic(figureEntity);
                if (isActivated)
                {
                    return;
                }
            }
            
            SwitcherTurn.SwitchTurn(true, true);
        }

        #endregion
    }
}