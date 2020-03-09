using MyChess.Scripts.Core.Board.Model;

namespace MyChess.Scripts.Core.Board.Creator
{
    public interface IBoardCreator
    {
        #region IBoardCreator

        void CreateCells(IBoardModel boardModel);

        #endregion
    }
}