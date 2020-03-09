using System.Collections.Generic;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.MoveTurnManager.Data;
using MyChess.Scripts.Core.Game.Observer.Components;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Core.Game.MoveTurnManager
{
    public sealed class GameMoveTurnManager : IGameMoveTurnManager, IGameComponentCompleted
    {
        #region GameMoveTurnManager

        private readonly IDictionary<IBoardCell, IGameMoveTurnData> MoveTurnData =
            new Dictionary<IBoardCell, IGameMoveTurnData>();

        public override string ToString() => MoveTurnData.ToString(",\n");

        private void Clear() => MoveTurnData.Clear();

        #endregion

        #region IGameMoveTurnManager

        public IEnumerable<IGameMoveTurnData> CalculateMovesTurn(IFigureEntity movableFigure)
        {
            Clear();

            foreach (var figureMoveTurnRules in movableFigure.Def.FigureMoveTurnRules)
            {
                var moveTurnData = figureMoveTurnRules.CalculateMoveTurnData(movableFigure);
                foreach (var data in moveTurnData)
                {
                    MoveTurnData.Add(data.MoveToCell, data);
                }
            }

            return MoveTurnData.Values;
        }

        public IFigureEntity GetRemovedFigure(IBoardCell moveToCell)
        {
            MoveTurnData.TryGetValue(moveToCell, out var data);
            return data?.RemovedFigure;
        }

        #endregion

        #region IGameComponentCompleted

        public void GameComplete() => Clear();

        #endregion
    }
}