namespace MyChess.Scripts.Utility.Dao.Def
{
    public interface IDef<out TKey>
    {
        #region IDef

        TKey Id { get; }

        #endregion
    }
}