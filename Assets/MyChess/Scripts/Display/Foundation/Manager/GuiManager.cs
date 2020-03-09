using MyChess.Scripts.Display.Foundation.Screen;
using MyChess.Scripts.Display.Foundation.Screen.Repository;
using MyChess.Scripts.Utility.Common;

namespace MyChess.Scripts.Display.Foundation.Manager
{
    public sealed class GuiManager : IGuiManager
    {
        #region GuiManager

        private readonly IUiScreenRepository UiScreenRepository;

        private IUiScreen _curScreen;

        public GuiManager(IUiScreenRepository uiScreenRepository)
        {
            UiScreenRepository = uiScreenRepository.CheckNull();
        }

        private IUiScreen GetScreen(UiScreenKind screenKind)
        {
            return UiScreenRepository.GetDef(screenKind);
        }

        #endregion

        #region IGuiManager

        public void ShowScreen(UiScreenKind screenKind)
        {
            _curScreen?.Hide();

            _curScreen = GetScreen(screenKind);
            _curScreen.Show();

            foreach (var defaultElement in _curScreen.OtherUiElements)
            {
                defaultElement.Hide();
            }

            foreach (var defaultElement in _curScreen.DefaultUiElements)
            {
                defaultElement.Show();
            }
        }

        public void HideScreen(UiScreenKind screenKind) => GetScreen(screenKind).Hide();

        #endregion
    }
}