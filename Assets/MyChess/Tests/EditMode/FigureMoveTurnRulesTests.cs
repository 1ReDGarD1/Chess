using System;
using System.Linq;
using MyChess.Scripts.Core.Board.Cell;
using MyChess.Scripts.Core.Board.Creator;
using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Enum;
using MyChess.Scripts.Core.Figure.Entity;
using MyChess.Scripts.Core.Figure.MoveTurnRules;
using MyChess.Scripts.Core.Figure.MoveTurnRules.Kind;
using MyChess.Scripts.Core.Game.Model;
using MyChess.Scripts.Editor;
using NSubstitute;
using NUnit.Framework;
using Object = UnityEngine.Object;

namespace MyChess.Tests.EditMode
{
    public class FigureMoveTurnRulesTests
    {
        #region FigureMoveTurnRulesTests

        private readonly BoardCellCol CellCol = BoardCellCol.ColD;
        private readonly BoardCellRow CellRow = BoardCellRow.Row4;
        private readonly GameTeam Team = GameTeam.White;

        private IBoardModel BoardModel;
        private IGameModel GameModel;

        private IBoardCell _mainCell;
        private IFigureEntity _mainFigure;

        [SetUp]
        public void SetUp()
        {
            BoardModel = new BoardModel();

            var boardCreator = new BoardCreator();
            boardCreator.CreateCells(BoardModel);

            GameModel = Substitute.For<IGameModel>();
            GameModel.CurTeamTurn.Returns(Team);

            //create figure and cell
            _mainFigure = Substitute.For<IFigureEntity>();
            _mainFigure.Team.Returns(Team);

            _mainCell = BoardModel.GetCell(CellCol, CellRow);
            _mainFigure.PlacedCell.Returns(_mainCell);
        }

        private void CheckAvailableCell(BoardCellCol col, BoardCellRow row)
        {
            var cell = BoardModel.GetCell(col, row);
            Assert.IsTrue(cell.Status == BoardCellStatus.AvailableForMove);
        }

        private void ResetCellsStatus()
        {
            foreach (var cell in BoardModel.Cells)
            {
                cell.Clear();
            }

            _mainCell.Figure = _mainFigure;
        }

        private void IterateFigureMoveTurnRules<T>(Action actionChecker) where T : Object
        {
            ResetCellsStatus();

            foreach (var figureMoveTurnRules in AssetUtils.FindAllAssets<T>())
            {
                if (figureMoveTurnRules is BaseFigureMoveTurnRulesSO baseFigureMoveTurnRules)
                {
                    baseFigureMoveTurnRules.Construct(BoardModel, GameModel);
                    baseFigureMoveTurnRules.CalculateMoveTurnData(_mainFigure);

                    actionChecker.Invoke();
                }
                else
                {
                    Assert.Fail($"FigureMoveTurnRules:{figureMoveTurnRules} can't cast to BaseFigureMoveTurnRulesSO");
                }
            }
        }

        #endregion

        #region CalculateMoveTurnData_CreateFigureMoveTurnRulesDiagonally_NecessaryCellsAvailable

        [Test]
        public void CalculateMoveTurnData_CreateFigureMoveTurnRulesDiagonally_NecessaryCellsAvailable()
        {
            IterateFigureMoveTurnRules<FigureMoveTurnRulesDiagonallySO>(() =>
            {
                CheckAvailableCell(BoardCellCol.ColC, BoardCellRow.Row3);
                CheckAvailableCell(BoardCellCol.ColB, BoardCellRow.Row2);
                CheckAvailableCell(BoardCellCol.ColE, BoardCellRow.Row5);
                CheckAvailableCell(BoardCellCol.ColF, BoardCellRow.Row6);
                CheckAvailableCell(BoardCellCol.ColC, BoardCellRow.Row5);
                CheckAvailableCell(BoardCellCol.ColB, BoardCellRow.Row6);
                CheckAvailableCell(BoardCellCol.ColF, BoardCellRow.Row2);
            });
        }

        #endregion

        #region CalculateMoveTurnData_CreateFigureMoveTurnRulesDirection_NecessaryCellsAvailable

        [Test]
        public void CalculateMoveTurnData_CreateFigureMoveTurnRulesDirection_NecessaryCellsAvailable()
        {
            IterateFigureMoveTurnRules<FigureMoveTurnRulesDirectionSO>(() =>
            {
                CheckAvailableCell(BoardCellCol.ColD, BoardCellRow.Row3);
                CheckAvailableCell(BoardCellCol.ColD, BoardCellRow.Row2);
                CheckAvailableCell(BoardCellCol.ColD, BoardCellRow.Row5);
                CheckAvailableCell(BoardCellCol.ColD, BoardCellRow.Row6);

                CheckAvailableCell(BoardCellCol.ColC, BoardCellRow.Row4);
                CheckAvailableCell(BoardCellCol.ColB, BoardCellRow.Row4);
                CheckAvailableCell(BoardCellCol.ColE, BoardCellRow.Row4);
                CheckAvailableCell(BoardCellCol.ColF, BoardCellRow.Row4);
            });
        }

        #endregion

        #region CalculateMoveTurnData_CreateFigureMoveTurnRulesKnight_NecessaryCellsAvailable

        [Test]
        public void CalculateMoveTurnData_CreateFigureMoveTurnRulesKnight_NecessaryCellsAvailable()
        {
            IterateFigureMoveTurnRules<FigureMoveTurnRulesKnightSO>(() =>
            {
                CheckAvailableCell(BoardCellCol.ColB, BoardCellRow.Row5);
                CheckAvailableCell(BoardCellCol.ColB, BoardCellRow.Row3);
                CheckAvailableCell(BoardCellCol.ColF, BoardCellRow.Row5);
                CheckAvailableCell(BoardCellCol.ColF, BoardCellRow.Row3);
            });
        }

        #endregion

        #region CalculateMoveTurnData_CreateFigureMoveTurnRulesNearest_NecessaryCellsAvailable

        [Test]
        public void CalculateMoveTurnData_CreateFigureMoveTurnRulesNearest_NecessaryCellsAvailable()
        {
            IterateFigureMoveTurnRules<FigureMoveTurnRulesNearestSO>(() =>
            {
                CheckAvailableCell(BoardCellCol.ColC, BoardCellRow.Row5);
                CheckAvailableCell(BoardCellCol.ColD, BoardCellRow.Row5);
                CheckAvailableCell(BoardCellCol.ColE, BoardCellRow.Row5);
                CheckAvailableCell(BoardCellCol.ColE, BoardCellRow.Row4);
                CheckAvailableCell(BoardCellCol.ColE, BoardCellRow.Row3);
                CheckAvailableCell(BoardCellCol.ColD, BoardCellRow.Row3);
                CheckAvailableCell(BoardCellCol.ColC, BoardCellRow.Row4);
            });
        }

        #endregion

        #region CalculateMoveTurnData_CreateFigureMoveTurnRulesPawn_NecessaryCellsAvailable

        [Test]
        public void CalculateMoveTurnData_CreateFigureMoveTurnRulesPawn_NecessaryCellsAvailable()
        {
            IterateFigureMoveTurnRules<FigureMoveTurnRulesPawnSO>(() =>
            {
                CheckAvailableCell(BoardCellCol.ColD, BoardCellRow.Row5);
            });
        }

        #endregion

        #region CalculateMoveTurnData_CreateFigureMoveTurnRulesChecker_NecessaryCellsAvailable

        [Test]
        public void CalculateMoveTurnData_CreateFigureMoveTurnRulesChecker_NecessaryCellsAvailable()
        {
            IterateFigureMoveTurnRules<FigureMoveTurnRulesCheckerSO>(() =>
            {
                CheckAvailableCell(BoardCellCol.ColC, BoardCellRow.Row5);
                CheckAvailableCell(BoardCellCol.ColE, BoardCellRow.Row5);
            });
        }

        #endregion
    }
}