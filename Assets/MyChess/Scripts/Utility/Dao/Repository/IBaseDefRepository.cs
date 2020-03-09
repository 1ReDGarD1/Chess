using MyChess.Scripts.Utility.Dao.Def;

namespace MyChess.Scripts.Utility.Dao.Repository
{
    public interface IBaseDefRepository<out TDef> : IDefRepository<TDef, string>
        where TDef : IBaseDef
    {
    }
}