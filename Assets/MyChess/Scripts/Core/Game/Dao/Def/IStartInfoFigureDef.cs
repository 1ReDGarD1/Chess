using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Dao.Def;

namespace MyChess.Scripts.Core.Game.Dao.Def
{
    public interface IStartInfoFigureDef
    {
        #region IStartInfoFigureDef

        IFigureDef Def { get; }
        GameTeam Team { get; }

        BoardCellCol StartCol { get; }
        BoardCellRow StartRow { get; }

        #endregion
    }
}