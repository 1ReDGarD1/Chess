using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.SwitcherTurn;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Core.Figure.PostTurnLogic
{
    public abstract class BaseFigurePostTurnLogicSO : ScriptableObject, IFigurePostTurnLogic
    {
        #region BaseFigurePostTurnLogicSO

        private IGameSwitcherTurn SwitcherTurn;

        [Inject]
        private void Construct(IGameSwitcherTurn switcherTurn)
        {
            SwitcherTurn = switcherTurn.CheckNull();
        }

        protected void SwitchTurn(bool switchTeam, bool needPrepareControl)
        {
            SwitcherTurn.SwitchTurn(switchTeam, needPrepareControl);
        }

        #endregion

        #region IFigurePostTurnLogic

        public abstract bool ActivatePostTurnLogic(IFigureEntity figure);

        #endregion
    }
}