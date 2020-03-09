using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Figure.Creator
{
    public interface IFigureCreator
    {
        #region IFigureCreator

        IFigureEntity Create(IFigureDef figureDef, GameTeam team);

        #endregion
    }
}