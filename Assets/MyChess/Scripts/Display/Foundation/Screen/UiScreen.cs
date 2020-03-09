using System.Collections.Generic;
using MyChess.Scripts.Display.Foundation.View;
using UnityEngine;

namespace MyChess.Scripts.Display.Foundation.Screen
{
    [DisallowMultipleComponent]
    public sealed class UiScreen : BaseViewElement, IUiScreen
    {
        #region UiScreen

        [SerializeField]
        private UiScreenKind _uiScreenKind;

        [SerializeField]
        private BaseViewElement[] _defaultUiElements;

        [SerializeField]
        private BaseViewElement[] _otherUiElements;

        #endregion

        #region IUiScreen

        public IEnumerable<IViewElement> DefaultUiElements => _defaultUiElements;
        public IEnumerable<IViewElement> OtherUiElements => _otherUiElements;

        #endregion

        #region IDef

        public UiScreenKind Id => _uiScreenKind;

        #endregion
    }
}