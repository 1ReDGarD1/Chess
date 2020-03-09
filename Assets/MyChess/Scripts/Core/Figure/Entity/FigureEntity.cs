using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Dao.Def;

namespace MyChess.Scripts.Core.Figure.Entity
{
    public sealed class FigureEntity : IFigureEntity
    {
        #region Figure

        public FigureEntity(IFigureDef def, GameTeam team)
        {
            Def = def;
            Team = team;
        }

        public override string ToString() => $"Figure, def:{Def}, team:{Team}";

        #endregion

        #region IFigureEntity

        public IFigureDef Def { get; }
        public GameTeam Team { get; }
        public IBoardCell PlacedCell { get; set; }

        public void Clear()
        {
            PlacedCell.Clear();
            PlacedCell = null;
        }

        public bool Equals(IFigureEntity figureEntity) => figureEntity == this;

        #endregion
    }
}