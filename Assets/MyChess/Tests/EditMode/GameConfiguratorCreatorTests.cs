using MyChess.Scripts.Core.Game.Control.Repository;
using MyChess.Scripts.Core.Game.Observer.Configurator.Creator;
using MyChess.Scripts.Core.Game.Observer.Configurator.Data;
using NSubstitute;
using NUnit.Framework;

namespace MyChess.Tests.EditMode
{
    public class GameConfiguratorCreatorTests
    {
        #region Create_TransferData_GetNotNullConfigurator

        [Test]
        public void Create_TransferData_GetNotNullConfigurator()
        {
            var gameControlRepository = Substitute.For<IGameControlRepository>();
            var configuratorData = Substitute.For<IGameConfiguratorData>();
            var configuratorCreator = new GameConfiguratorCreator(gameControlRepository);
            var gameConfigurator = configuratorCreator.Create(configuratorData);
            Assert.IsNotNull(gameConfigurator, "gameConfigurator != null");
        }

        #endregion
    }
}