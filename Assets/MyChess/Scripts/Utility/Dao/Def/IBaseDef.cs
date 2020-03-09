namespace MyChess.Scripts.Utility.Dao.Def
{
    public interface IBaseDef : IDef<string>
    {
        #region IBaseDef

        bool Equals(IDef<string> def);

        #endregion
    }
}