using System.Collections.Generic;
using MyChess.Scripts.Display.Foundation.View;
using MyChess.Scripts.Utility.Dao.Def;

namespace MyChess.Scripts.Display.Foundation.Screen
{
    public interface IUiScreen : IViewElement, IDef<UiScreenKind>
    {
        #region IUiScreen

        IEnumerable<IViewElement> DefaultUiElements { get; }
        IEnumerable<IViewElement> OtherUiElements { get; }

        #endregion
    }
}