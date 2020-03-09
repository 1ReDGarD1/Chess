using System.Collections.Generic;
using MyChess.Scripts.Utility.Dao.Def;

namespace MyChess.Scripts.Utility.Dao.Repository
{
    public abstract class BaseDefRepository<TDef> : DefRepository<TDef, string>, IBaseDefRepository<TDef>
        where TDef : IBaseDef
    {
        #region BaseDefRepository

        protected BaseDefRepository(IEnumerable<TDef> defs) : base(defs)
        {
        }

        #endregion
    }
}