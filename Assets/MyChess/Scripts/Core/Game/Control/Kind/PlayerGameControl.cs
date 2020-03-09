using MyChess.Scripts.Core.Enum;

namespace MyChess.Scripts.Core.Game.Control.Kind
{
    public sealed class PlayerGameControl : IGameControl
    {
        #region IGameControl

        public void PrepareControl(GameTeam team)
        {
        }

        public void ActivateControl()
        {
        }

        #endregion

        #region IDef

        public GameControlKind Id => GameControlKind.Player;

        #endregion
    }
}