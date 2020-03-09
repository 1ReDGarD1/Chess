namespace MyChess.Scripts.Core.Game.SwitcherTurn
{
    public interface IGameSwitcherTurn
    {
        #region IGameSwitcherTurn

        void SwitchTurn(bool switchTeam, bool needPrepareControl);

        #endregion
    }
}