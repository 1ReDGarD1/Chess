using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Utility.Dao.Def;

namespace MyChess.Scripts.Core.Game.Control
{
    public interface IGameControl : IDef<GameControlKind>
    {
        #region IGameControl

        void PrepareControl(GameTeam team);
        void ActivateControl();

        #endregion
    }
}