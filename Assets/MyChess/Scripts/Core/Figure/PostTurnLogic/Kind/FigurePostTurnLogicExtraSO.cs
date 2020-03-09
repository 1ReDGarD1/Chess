using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Game.Master;
using MyChess.Scripts.Core.Game.MoveTurnManager;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Core.Figure.PostTurnLogic.Kind
{
    [CreateAssetMenu(menuName = "MyChess/Figure Post Turn Logic/Extra")]
    public sealed class FigurePostTurnLogicExtraSO : BaseFigurePostTurnLogicSO
    {
        #region FigurePostTurnLogicExtraSO

        private IGameMaster GameMaster;
        private IGameMoveTurnManager GameMoveTurnManager;

        [Inject]
        private void Construct(IGameMaster gameMaster, IGameMoveTurnManager gameMoveTurnManager)
        {
            GameMaster = gameMaster.CheckNull();
            GameMoveTurnManager = gameMoveTurnManager.CheckNull();
        }

        #endregion

        #region IFigurePostTurnLogic

        public override bool ActivatePostTurnLogic(IFigureEntity figure)
        {
            //сначала проверяем была срублена фигура на прошлом ходу
            var prevRemovedFigure = GameMoveTurnManager.GetRemovedFigure(figure.PlacedCell);
            if (prevRemovedFigure == null)
            {
                return false;
            }

            //расчитываем возможные ходы по новой
            var moveTurnData = GameMoveTurnManager.CalculateMovesTurn(figure);
            foreach (var data in moveTurnData)
            {
                if (!data.HasRemovedFigure)
                {
                    data.MoveToCell.Status = BoardCellStatus.Empty;
                    continue;
                }

                GameMaster.SetFocusFigure(figure);
                GameMaster.IsBlockFocused = true;
                SwitchTurn(false, false);
                return true;
            }

            return false;
        }

        #endregion
    }
}