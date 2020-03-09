using MyChess.Scripts.Core.Figure.Entity;
using UnityEngine;
using Zenject;

namespace MyChess.Scripts.Display.Game.Figure.View
{
    [DisallowMultipleComponent]
    public sealed class FigureView : MonoBehaviour, IFigureView
    {
        #region FigureView

        [Inject]
        private void Construct()
        {
            Position = Vector3.zero;
        }

        public void Init(IFigureEntity entity)
        {
            Entity = entity;
        }

        public override string ToString() => $"FigureView entity:{Entity}";

        #endregion

        #region IFigureView

        public IFigureEntity Entity { get; private set; }
        
        public Vector3 Position
        {
            set => transform.position = value;
        }

        #endregion
    }
}