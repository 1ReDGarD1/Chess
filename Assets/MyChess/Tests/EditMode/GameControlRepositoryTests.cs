using MyChess.Scripts.Core.Board.Model;
using MyChess.Scripts.Core.Figure.Model;
using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Control.Kind;
using MyChess.Scripts.Core.Game.Control.Repository;
using MyChess.Scripts.Core.Game.Master;
using MyChess.Scripts.Core.Game.SwitcherTurn;
using NSubstitute;
using NUnit.Framework;

namespace MyChess.Tests.EditMode
{
    public class GameControlRepositoryTests
    {
        #region GameControlRepositoryTests

        private IGameControlRepository GameControlRepository;

        [SetUp]
        public void SetUp()
        {
            var boardModel = Substitute.For<IBoardModel>();
            var figureModel = Substitute.For<IFigureModel>();
            var gameMaster = Substitute.For<IGameMaster>();
            var gameSwitcherTurn = Substitute.For<IGameSwitcherTurn>();

            var gameControls = new IGameControl[]
            {
                new PlayerGameControl(),
                new AiRandomGameControl(boardModel, figureModel, gameMaster, gameSwitcherTurn)
            };

            GameControlRepository = new GameControlRepository(gameControls);
        }

        #endregion

        #region GetDef_ByGameControlKind_GetGameControlNotNull

        [Test]
        public void GetDef_ByGameControlKind_GetGameControlNotNull([Values] GameControlKind gameControlKind)
        {
            var gameControl = GameControlRepository.GetDef(gameControlKind);
            Assert.IsNotNull(gameControl, $"gameControl == null for {gameControlKind}");
        }

        #endregion
    }
}