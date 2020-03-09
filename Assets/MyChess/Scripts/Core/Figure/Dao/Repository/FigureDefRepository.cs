using System.Collections.Generic;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Utility.Dao.Repository;

namespace MyChess.Scripts.Core.Figure.Dao.Repository
{
    public sealed class FigureDefRepository : BaseDefRepository<IFigureDef>, IFigureDefRepository
    {
        #region FigureDefRepository

        public FigureDefRepository(IEnumerable<IFigureDef> defs) : base(defs)
        {
        }

        #endregion
    }
}