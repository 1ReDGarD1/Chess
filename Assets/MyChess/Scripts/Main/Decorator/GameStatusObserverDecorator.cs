using MyChess.Scripts.Core.Game.Observer;
using MyChess.Scripts.Core.Game.Observer.Configurator.Data;
using MyChess.Scripts.Display.Foundation.Manager;
using MyChess.Scripts.Display.Foundation.Screen;
using MyChess.Scripts.Display.Game.Board;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Main.Decorator
{
    public sealed class GameStatusObserverDecorator : IGameStatusObserver
    {
        #region GameStatusObserverDecorator

        private readonly IGameStatusObserver GameStatusObserver;
        private readonly IBoardView BoardView;
        private readonly IGuiManager GuiManager;

        public GameStatusObserverDecorator(IGameStatusObserver gameStatusObserver, 
            IBoardView boardView,
            IGuiManager guiManager)
        {
            GameStatusObserver = gameStatusObserver.CheckNull();
            BoardView = boardView.CheckNull();
            GuiManager = guiManager.CheckNull();
        }

        #endregion

        #region IGameStatusObserver

        public void StartGame(IGameConfiguratorData configuratorData)
        {
            GameStatusObserver.StartGame(configuratorData);

            BoardView.Show();
            GuiManager.ShowScreen(UiScreenKind.Game);
        }

        public void EndGame()
        {
            GameStatusObserver.EndGame();

            BoardView.Hide();
            GuiManager.ShowScreen(UiScreenKind.MainMenu);
        }

        public void RestartGame()
        {
            GameStatusObserver.RestartGame();
        }

        #endregion
    }
}