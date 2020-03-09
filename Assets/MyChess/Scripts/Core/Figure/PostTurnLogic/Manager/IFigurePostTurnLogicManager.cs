using MyChess.Scripts.Core.Figure.Entity;

namespace MyChess.Scripts.Core.Figure.PostTurnLogic.Manager
{
    public interface IFigurePostTurnLogicManager
    {
        #region IFigurePostTurnLogicManager

        void ActivateFigurePostTurnLogic(IFigureEntity figureEntity);

        #endregion
    }
}