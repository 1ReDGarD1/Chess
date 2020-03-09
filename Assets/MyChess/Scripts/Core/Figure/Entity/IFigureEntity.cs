using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Dao.Def;

namespace MyChess.Scripts.Core.Figure.Entity
{
    public interface IFigureEntity
    {
        #region IFigureEntity
        
        IFigureDef Def { get; }
        GameTeam Team { get; }
        IBoardCell PlacedCell { get; set; }

        void Clear();
        bool Equals(IFigureEntity figureEntity);

        #endregion
    }
}