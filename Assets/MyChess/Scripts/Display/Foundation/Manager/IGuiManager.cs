using MyChess.Scripts.Display.Foundation.Screen;

namespace MyChess.Scripts.Display.Foundation.Manager
{
    public interface IGuiManager
    {
        #region IGuiManager

        void ShowScreen(UiScreenKind screenKind);
        void HideScreen(UiScreenKind screenKind);

        #endregion
    }
}