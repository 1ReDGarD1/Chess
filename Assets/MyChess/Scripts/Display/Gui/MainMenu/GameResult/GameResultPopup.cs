using System;
using MyChess.Scripts.Core.Game.Master;
using MyChess.Scripts.Core.Game.Observer;
using MyChess.Scripts.Display.Foundation.View;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MyChess.Scripts.Display.Gui.MainMenu.GameResult
{
    [DisallowMultipleComponent]
    public sealed class GameResultPopup : BaseViewElement
    {
        #region GameResultPopup

        [SerializeField]
        private Button _exitButton;

        private IGameStatusObserver GameStatusObserver;
        private IGameMaster GameMaster;

        private void Awake()
        {
            _exitButton.CheckNull();
            _exitButton.onClick.AddListener(OnExitClickHandler);
        }

        private void OnDestroy()
        {
            GameMaster.OnCompleteGame -= OnCompleteGameHandler;
        }

        [Inject]
        private void Construct(IGameStatusObserver gameStatusObserver, IGameMaster gameMaster)
        {
            GameStatusObserver = gameStatusObserver.CheckNull();
            GameMaster = gameMaster.CheckNull();

            GameMaster.OnCompleteGame += OnCompleteGameHandler;
        }

        private void OnCompleteGameHandler(object sender, EventArgs eventArgs)
        {
            Show();
        }

        private void OnExitClickHandler()
        {
            GameStatusObserver.EndGame();
        }

        #endregion
    }
}