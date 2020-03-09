using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Game.Model;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Core.Game.SwitcherTurn
{
    public sealed class GameSwitcherTurn : IGameSwitcherTurn
    {
        #region GameSwitcherTurn

        private readonly IGameModel GameModel;

        public GameSwitcherTurn(IGameModel gameModel)
        {
            GameModel = gameModel.CheckNull();
        }

        #endregion

        #region IGameSwitcherTurn

        public void SwitchTurn(bool switchTeam, bool needPrepareControl)
        {
            var team = GameModel.CurTeamTurn;
            if (switchTeam)
            {
                team = team == GameTeam.White ? GameTeam.Black : GameTeam.White;
                GameModel.CurTeamTurn = team;
            }

            var curControl = GameModel.GetControl(team);

            if (needPrepareControl)
            {
                curControl.PrepareControl(team);
            }

            curControl.ActivateControl();
        }

        #endregion
    }
}