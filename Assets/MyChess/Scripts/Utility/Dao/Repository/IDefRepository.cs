using MyChess.Scripts.Utility.Dao.Def;

namespace MyChess.Scripts.Utility.Dao.Repository
{
    public interface IDefRepository<out TDef, in TKey>
        where TDef : IDef<TKey>
    {
        #region IDefRepository

        TDef GetDef(TKey id);

        #endregion
    }
}