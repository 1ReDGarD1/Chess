using MyChess.Scripts.Core.Game.Control;
using MyChess.Scripts.Core.Game.Dao.Def;
using MyChess.Scripts.Core.Game.Observer;
using MyChess.Scripts.Core.Game.Observer.Configurator.Data;
using MyChess.Scripts.Display.Foundation.View;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MyChess.Scripts.Display.Gui.MainMenu.GameMode
{
    [DisallowMultipleComponent]
    public sealed class GameModeButton : BaseViewElement
    {
        #region GameModeButton

        [SerializeField]
        private Button _button;

        [SerializeField]
        private GameDefSO _gameDef;

        [SerializeField]
        private GameControlKind _whiteControlKind;

        [SerializeField]
        private GameControlKind _blackControlKind;

        private IGameStatusObserver GameStatusObserver;

        private void Awake()
        {
            _button.CheckNull();
            _gameDef.CheckNull();

            _button.onClick.AddListener(OnButtonClickHandler);
        }

        [Inject]
        private void Construct(IGameStatusObserver gameStatusObserver)
        {
            GameStatusObserver = gameStatusObserver.CheckNull();
        }

        private void OnButtonClickHandler()
        {
            var configuratorData = new GameConfiguratorData(_gameDef, _whiteControlKind, _blackControlKind);
            GameStatusObserver.StartGame(configuratorData);
        }

        #endregion
    }
}