using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Controller;
using MyChess.Scripts.Core.Figure.Dao.Def;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Figure.Model;
using MyChess.Scripts.Core.Figure.PostTurnLogic.Manager;
using MyChess.Scripts.Core.Game.Master;
using MyChess.Scripts.Core.Game.Model;
using MyChess.Scripts.Core.Game.MoveTurnManager;
using NSubstitute;
using NUnit.Framework;

namespace MyChess.Tests.EditMode
{
    public class GameMasterTests
    {
        #region GameMasterTests

        private IGameMaster GameMaster;
        private IGameModel GameModel;

        private IFigureEntity _figure;
        private IBoardCell _cell;
        private IBoardCell _moveToCell;

        [SetUp]
        public void SetUp()
        {
            var boardModel = Substitute.For<IBoardModel>();
            GameModel = Substitute.For<IGameModel>();
            var figureModel = Substitute.For<IFigureModel>();
            var figurePostTurnLogicManager = Substitute.For<IFigurePostTurnLogicManager>();
            var gameMoveTurnManager = Substitute.For<IGameMoveTurnManager>();

            var figureController = new FigureController(figureModel);
            GameMaster = new GameMaster(figureController, boardModel, GameModel, figurePostTurnLogicManager,
                gameMoveTurnManager);

            _figure = new FigureEntity(Substitute.For<IFigureDef>(), GameTeam.White);
            _cell = new BoardCell(BoardCellCol.ColA, BoardCellRow.Row1, 0, 0)
            {
                Figure = _figure
            };
            _moveToCell = new BoardCell(BoardCellCol.ColA, BoardCellRow.Row2, 0, 0)
            {
                Status = BoardCellStatus.AvailableForMove
            };
        }

        private void Reset()
        {
            _figure.PlacedCell = _cell;
            GameMaster.IsBlockFocused = false;
        }

        #endregion

        #region SetAndActivateFocusFigure_SettingFocusFigure_CheckFocus

        [Test]
        public void SetAndActivateFocusFigure_SettingFocusFigure_CheckFocus()
        {
            Reset();

            Assert.IsTrue(GameMaster.SetAndActivateFocusFigure(_figure), $"can't focus figure:{_figure}");
            Assert.IsTrue(_cell.Status == BoardCellStatus.HasFocusFigure, $"incorrect cell status:{_cell.Status}");
            Assert.IsTrue(!GameMaster.SetAndActivateFocusFigure(_figure), "twice attempt");
        }

        #endregion

        #region PlaceFocusCell_FocusAndPlaceCell_CellPlaced

        [Test]
        public void MoveFocusFigure_FocusAndMoveFigure_FigureMoved()
        {
            Reset();

            Assert.IsTrue(GameMaster.SetAndActivateFocusFigure(_figure), $"can't focus cell:{_figure}");
            Assert.IsTrue(GameMaster.MoveFocusFigure(_moveToCell), $"attempt place not available cell:{_moveToCell}");
            Assert.IsTrue(_moveToCell.Figure == _figure,
                $"not equal moveble figure:{_moveToCell.Figure}, figure:{_figure}");
        }

        #endregion

        #region OnCompleteGame_SetFocusAndMoveFigure_GameComplete

        [Test]
        public void OnCompleteGame_SetFocusAndMoveFigure_GameComplete()
        {
            Reset();
            GameModel.GameDef.Validator.ValidateResult().Returns(false);

            var isCompleteGame = false;
            GameMaster.OnCompleteGame += (sender, args) => { isCompleteGame = true; };

            GameMaster.SetFocusFigure(_figure);
            GameMaster.MoveFocusFigure(_moveToCell);

            Assert.IsTrue(isCompleteGame, "not completed game");
        }

        #endregion

        #region IsBlockFocused_SetBlockFlag_NotFocusFigure

        [Test]
        public void IsBlockFocused_SetBlockFlag_NotFocusFigure()
        {
            Reset();

            GameMaster.IsBlockFocused = true;
            Assert.IsFalse(GameMaster.SetFocusFigure(_figure), "figure is focused");
        }

        #endregion
    }
}