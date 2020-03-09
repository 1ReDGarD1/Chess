using MyChess.Scripts.Core.Game.Observer;
using MyChess.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Main
{
    public sealed class KeyboardControl : MonoBehaviour
    {
        #region KeyboardControl

        private IGameStatusObserver GameStatusObserver;

        [Inject]
        private void Construct(IGameStatusObserver gameStatusObserver)
        {
            GameStatusObserver = gameStatusObserver.CheckNull();
        }
        
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.R))
            {
                return;
            }
            
            GameStatusObserver.RestartGame();
        }

        #endregion
    }
}