using MyChess.Scripts.Display.Foundation.Manager;
using MyChess.Scripts.Display.Foundation.Screen;
using MyChess.Scripts.Display.Game.Board;
using MyChess.Scripts.Utility.Common;
using Zenject;

namespace MyChess.Scripts.Composition.Laucnher.Main
{
    public sealed class MainInitializable : IInitializable
    {
        #region MainInitializable

        private readonly IGuiManager GuiManager;
        private readonly IBoardView BoardView;

        public MainInitializable(IGuiManager guiManager, IBoardView boardView)
        {
            GuiManager = guiManager.CheckNull();
            BoardView = boardView.CheckNull();
        }

        #endregion

        #region IInitializable

        public void Initialize()
        {
            BoardView.Hide();
            
            GuiManager.ShowScreen(UiScreenKind.MainMenu);
        }

        #endregion
    }
}