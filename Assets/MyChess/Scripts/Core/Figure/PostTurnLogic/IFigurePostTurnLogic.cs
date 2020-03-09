using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Figure.PostTurnLogic
{
    public interface IFigurePostTurnLogic
    {
        #region IFigurePostTurnLogic
        
        bool ActivatePostTurnLogic(IFigureEntity figure);

        #endregion
    }
}