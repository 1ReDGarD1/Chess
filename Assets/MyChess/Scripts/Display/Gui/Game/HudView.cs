using System;
using MyChess.Scripts.Core.Game.Master;
using MyChess.Scripts.Core.Game.Observer;
using MyChess.Scripts.Display.Foundation.View;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MyChess.Scripts.Display.Gui.Game
{
    [DisallowMultipleComponent]
    public sealed class HudView : BaseViewElement
    {
        #region HudView

        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private Button _restartButton;

        private IGameStatusObserver GameStatusObserver;
        private IGameMaster GameMaster;

        private void Awake()
        {
            _exitButton.CheckNull();
            _restartButton.CheckNull();

            _exitButton.onClick.AddListener(OnExitClickHandler);
            _restartButton.onClick.AddListener(OnRestartClickHandler);
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

        private void OnExitClickHandler()
        {
            GameStatusObserver.EndGame();
        }

        private void OnRestartClickHandler()
        {
            GameStatusObserver.RestartGame();
        }

        private void OnCompleteGameHandler(object sender, EventArgs eventArgs)
        {
            Hide();
        }

        #endregion
    }
}