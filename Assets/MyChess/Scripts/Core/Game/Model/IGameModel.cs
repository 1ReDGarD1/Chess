using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Dao.Def;

namespace MyChess.Scripts.Core.Game.Model
{
    public interface IGameModel
    {
        #region IGameModel

        IGameDef GameDef { get; }

        GameTeam CurTeamTurn { get; set; }

        IGameControl GetControl(GameTeam team);

        #endregion
    }
}